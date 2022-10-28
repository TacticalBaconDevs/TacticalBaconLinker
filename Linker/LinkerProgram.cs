using ArmA3SyncImporter.model;

namespace TacticalBaconLinker
{
    class LinkerProgram
    {
        public static string? link(A3SMod echterMod, A3SMod symbolicMod)
        {
            // richtigen Pfad herrausfinden
            string echterModPath = getPath(echterMod.ModName);
            if (echterModPath != "")
            {
                // Pfade setzen
                string symbolicModFinalPath = combine(Utils.PATH_TARGET_REPO, symbolicMod.ModName);
                string echterModFinalPath = combine(echterModPath, echterMod.ModName);

                // Check ob target exestiert
                bool deleted = true;
                if (Directory.Exists(symbolicModFinalPath))
                {
                    try
                    {
                        Directory.Delete(symbolicModFinalPath);
                    }
                    catch (Exception)
                    {
                        deleted = false;
                    }
                }

                // Ordner linken
                if (deleted)
                {
                    SymbolicLink.CreateSymbolicLink(symbolicModFinalPath, echterModFinalPath, false);
                    return symbolicModFinalPath;
                }
            }

            return null;
        }

        public static string? merge(A3SMod finalMod, A3SMod toMergeMod)
        {
            // richtigen Pfad herrausfinden
            string toMergeModPath = getPath(toMergeMod.ModName);
            if (toMergeModPath != "")
            {
                // Pfade setzen und mergeOrdner erstellen
                string finalModAddonPath = combine(combine(Utils.PATH_TARGET_REPO, finalMod.ModName), "addons");
                string toMergeModAddonPath = combine(combine(toMergeModPath, toMergeMod.ModName), "addons");

                if (!Directory.Exists(finalModAddonPath))
                    Directory.CreateDirectory(finalModAddonPath);

                // Dateien mergeLinken
                foreach (var file in toMergeMod.Files)
                {
                    string finalModAddonPathFile = combine(finalModAddonPath, file.PboName);
                    string toMergeModAddonPathFile = combine(toMergeModAddonPath, file.PboName);
                    SymbolicLink.CreateSymbolicLink(finalModAddonPathFile, toMergeModAddonPathFile, true);
                }

                return combine(Utils.PATH_TARGET_REPO, finalMod.ModName);
            }

            return null;
        }

        public static string? split(A3SMod quellMod, A3SMod zielMod)
        {
            // richtigen Pfad herrausfinden
            string topModPath = getPath(quellMod.ModName);
            if (topModPath != "")
            {
                // Pfade setzen und SplitOrdner erstellen
                string zielModAddonPath = combine(combine(Utils.PATH_TARGET_REPO, zielMod.ModName), "addons");
                string quellModAddonPath = combine(combine(topModPath, quellMod.ModName), "addons");

                if (!Directory.Exists(zielModAddonPath))
                    Directory.CreateDirectory(zielModAddonPath);

                // Dateien splitten
                foreach (var file in zielMod.Files)
                {
                    string zielModAddonPathFile = combine(zielModAddonPath, file.PboName);
                    string quellModAddonPathFile = combine(quellModAddonPath, file.PboName);
                    SymbolicLink.CreateSymbolicLink(zielModAddonPathFile, quellModAddonPathFile, true);
                }

                return combine(Utils.PATH_TARGET_REPO, zielMod.ModName);
            }

            return null;
        }

        public static string? splitCopy(A3SMod quellMod, A3SMod zielMod)
        {
            // richtigen Pfad herrausfinden
            string topModPath = getPath(quellMod.ModName);
            if (topModPath != "")
            {
                // Pfade setzen und SplitOrdner erstellen
                string zielModAddonPath = combine(combine(Utils.PATH_TARGET_REPO, zielMod.ModName), "addons");
                string quellModAddonPath = combine(combine(topModPath, quellMod.ModName), "addons");

                if (!Directory.Exists(zielModAddonPath))
                    Directory.CreateDirectory(zielModAddonPath);

                // Dateien splitten
                foreach (var file in zielMod.Files)
                {
                    string zielModAddonPathFile = combine(zielModAddonPath, file.PboName);
                    string quellModAddonPathFile = combine(quellModAddonPath, file.PboName);
                    File.Copy(quellModAddonPathFile, zielModAddonPathFile, true);
                }

                return combine(Utils.PATH_TARGET_REPO, zielMod.ModName);
            }

            return null;
        }

        private static string getPath(string mod) => Utils.getModPath(mod);

        private static string combine(string path1, string path2) => Utils.Combine(path1, path2);

    }
}
