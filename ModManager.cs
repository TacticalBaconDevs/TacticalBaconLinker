using ArmA3SyncImporter;
using ArmA3SyncImporter.model;
using System.Diagnostics;

namespace TacticalBaconLinker
{
    internal class ModManager
    {
        public static List<A3SMod> localMods = new();
        public static List<A3SMod> remoteMods = new();
        public static List<ModMatch> modMatches = new();

        public static void GetModMatches(List<string> localModsPaths, string remoteModsUrl, A3SEvent? selectedRemoteEvent)
        {
            // Abfragen der Mods von lokal und remote
            localMods = localModsPaths.SelectMany(localModsPath => ImporterUtils.GetLocalMods(localModsPath)).ToList();
            remoteMods = selectedRemoteEvent == null ? ImporterUtils.GetRemoteMods(remoteModsUrl) : ImporterUtils.GetRemoteMods(remoteModsUrl, selectedRemoteEvent);

            // ermitteln der ModMatches
            modMatches = remoteMods.SelectMany(remoteMod => GetModMatches(remoteMod, localMods)).Where(x => x != null).ToList();

            // entferne aus den remoteMods alle Mods, welche Matches haben
            remoteMods.RemoveAll(x => modMatches.Any(y => Utils.eq(x.ModName, y.RemoteMod.ModName)));

            // unbekannte ermitteln für Debug Gründe
            List<ModMatch> unbekannteMatches = modMatches.Where(x => x.Mode == "UNBEKANNT").ToList();
            if (unbekannteMatches.Count > 0 && Debugger.IsAttached)
                Debugger.Break();

            // Merge/Split Ergebnisse validieren
            List<ModMatch> removeEntries = new();
            foreach (ModMatch modMatch in modMatches)
            {
                // wenn mehrere Matches mit einem remote Mod, müssen alle zu einem MERGE gemacht werden
                List<ModMatch> multipleMatches = modMatches.Where(x => Utils.eq(x.RemoteMod, modMatch.RemoteMod)).ToList();
                if (multipleMatches.Count >= 2)
                {
                    if (multipleMatches.Any(x => x.Mode == "DIRECT"))
                    {
                        // es werden alle anderen Operationen gelöscht, wenn ein DIRECT dabei ist
                        //multipleMatches.Where(x => x.Mode != "DIRECT").ToList().ForEach(x => removeEntries.Add(x));
                        multipleMatches.Where(x => x.Mode != "DIRECT").ToList().ForEach(x => x.Mode = "SPLIT_COPY");
                    }
                    else
                    {
                        multipleMatches.ForEach(x => x.Mode = "MERGE");
                    }
                }

                // wenn mehrere Matches mit einem lokalen Mod, dann müssen diese zu SPLIT gemacht werden
                multipleMatches = modMatches.Where(x => Utils.eq(x.LocalMod, modMatch.LocalMod)).ToList();
                if (multipleMatches.Count >= 2)
                {
                    if (multipleMatches.Any(x => x.Mode == "DIRECT"))
                    {
                        // es muss eine KOPIE gemacht werden, da sonst eine Referenz auf eine Referenz
                        multipleMatches.Where(x => x.Mode != "DIRECT").ToList().ForEach(x => x.Mode = "SPLIT_COPY");
                    }
                    else
                    {
                        multipleMatches.ForEach(x => x.Mode = "SPLIT");
                    }
                }

                // finde Probleme
                if (modMatch.Mode != "DIRECT" && Utils.eq(modMatch.RemoteMod, modMatch.LocalMod))
                    Debugger.Break();

                multipleMatches = modMatches.Where(x => x.Mode != "DIRECT" && !Utils.eq(modMatch.RemoteMod, modMatch.LocalMod) && Utils.eq(x.RemoteMod, modMatch.LocalMod) && Utils.eq(x.LocalMod, modMatch.RemoteMod) && Utils.eq(x.Mode, modMatch.Mode)).ToList();
                if (multipleMatches.Count > 0 && Debugger.IsAttached)
                {
                    multipleMatches.Add(modMatch);
                    Debugger.Break();
                }
            }
            modMatches.RemoveAll(x => removeEntries.Contains(x));

            modMatches.Sort((x, y) =>
            {
                int value = x.Mode.CompareTo(y.Mode);
                if (value == 0)
                    value = x.LocalMod.ModName.CompareTo(y.LocalMod.ModName);
                if (value == 0)
                    value = x.RemoteMod.ModName.CompareTo(y.RemoteMod.ModName);
                return value;
            });
        }

        private static List<ModMatch> GetModMatches(A3SMod remoteMod, List<A3SMod> localMods)
        {
            List<ModMatch> modMatches = localMods.Select(localMod => GetModMatch(localMod, remoteMod)).Where(x => x != null).ToList();

            modMatches.Sort((x, y) =>
            {
                int value = x.FileMatchRemote == y.FileMatchRemote ? 0 : (x.FileMatchRemote < y.FileMatchRemote ? 1 : -1);
                if (value == 0)
                    value = x.FileMatchLocal == y.FileMatchLocal ? 0 : (x.FileMatchLocal < y.FileMatchLocal ? 1 : -1);
                return value;
            });

            return modMatches.Count > 0 ? modMatches : new();
        }

        private static ModMatch? GetModMatch(A3SMod localMod, A3SMod remoteMod)
        {
            List<A3SPboFile> localMatchedFiles = localMod.Files.Where(file => remoteMod.Files.Any(x => Utils.eq(x.PboName, file.PboName))).ToList();
            List<A3SPboFile> remoteMatchedFiles = remoteMod.Files.Where(file => localMod.Files.Any(x => Utils.eq(x.PboName, file.PboName))).ToList();

            int fileMatches = localMatchedFiles.Count;
            int fileMatchRemote = GetPercent(fileMatches, remoteMod.Files.Count); // fileMatch
            int fileMatchLocal = GetPercent(fileMatches, localMod.Files.Count); // countMatch

            string mode = GetMode(remoteMod, localMod, fileMatchRemote, fileMatchLocal);

            bool validSplit = mode == "SPLIT" && fileMatchRemote > 5 && fileMatchLocal > 0;
            bool validMerge = mode == "MERGE" && fileMatchRemote > 0 && fileMatchLocal > 5;

            if (!validSplit && !validMerge && (fileMatchRemote < 5 || fileMatchLocal < 5))
                return null;

            long savedSize = 0;
            if (fileMatches > 0)
            {
                savedSize = localMatchedFiles.Select(x => x.Size).Aggregate((x, y) => x + y);
                string readSavedSize = Utils.getReadableSize(savedSize);
            }

            return new ModMatch(localMod, remoteMod, mode, fileMatchRemote, fileMatchLocal, savedSize);
        }

        private static int GetPercent(int value, int hundred)
        {
            return (int)Math.Round((double)value / (double)hundred * (double)100);
        }

        private static string GetMode(A3SMod remoteMod, A3SMod localMod, int fileMatchRemote, int fileMatchLocal)
        {
            if (Utils.eq(remoteMod.ModName, localMod.ModName))
                return "DIRECT";

            if (fileMatchRemote >= 80 && fileMatchLocal >= 80)
                return "LINK";

            if (fileMatchRemote > 0 && fileMatchLocal >= 80)
                return "MERGE";

            if (fileMatchRemote >= 80 && fileMatchLocal < 90)
                return "SPLIT";

            // Notfallmodus
            if (fileMatchRemote > 5 && fileMatchLocal > 0)
                return "SPLIT";

            // Notfallmodus
            if (fileMatchRemote > 0 && fileMatchLocal > 5)
                return "MERGE";

            return "UNBEKANNT";
        }

    }
}
