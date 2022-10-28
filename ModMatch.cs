using ArmA3SyncImporter.model;

namespace TacticalBaconLinker
{
    internal class ModMatch
    {
        public readonly A3SMod LocalMod;
        public readonly A3SMod RemoteMod;
        public string Mode = "UNBEKANNT";
        public readonly int FileMatchRemote = 0;
        public readonly int FileMatchLocal = 0;
        public readonly long SavedSize = 0;

        public ModMatch(A3SMod localMod, A3SMod remoteMod, string mode, int fileMatchRemote, int fileMatchLocal, long savedSize)
        {
            RemoteMod = remoteMod;
            LocalMod = localMod;
            Mode = mode;
            FileMatchRemote = fileMatchRemote;
            FileMatchLocal = fileMatchLocal;
            SavedSize = savedSize;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} -> {2} [f:{3}|cm:{4}]", Mode, LocalMod.ModName, RemoteMod.ModName,
                FileMatchRemote, FileMatchLocal);
        }

    }
}