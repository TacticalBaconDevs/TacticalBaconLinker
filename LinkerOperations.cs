using ArmA3SyncImporter.model;

namespace TacticalBaconLinker
{
    internal class LinkerOperations
    {
        internal static Dictionary<A3SMod, A3SMod> links = new Dictionary<A3SMod, A3SMod>();
        internal static Dictionary<A3SMod, List<A3SMod>> splits = new Dictionary<A3SMod, List<A3SMod>>();
        internal static Dictionary<A3SMod, List<A3SMod>> merge = new Dictionary<A3SMod, List<A3SMod>>();
        internal static Dictionary<A3SMod, A3SMod> copy = new Dictionary<A3SMod, A3SMod>();

        private static void generate()
        {
            links.Clear();
            splits.Clear();
            merge.Clear();
            copy.Clear();

            foreach (ModMatch match in ModManager.modMatches)
            {
                if (match.Mode == "LINK" || (match.Mode == "DIRECT" && !Utils.eq(Utils.PATH_LOCAL_REPO, Utils.PATH_TARGET_REPO)))
                {
                    links.Add(match.LocalMod, match.RemoteMod);
                }

                if (match.Mode == "SPLIT")
                {
                    List<A3SMod> values = splits.GetValueOrDefault(match.LocalMod, new List<A3SMod>());
                    values.Add(match.RemoteMod);
                    splits[match.LocalMod] = values;
                }

                if (match.Mode == "MERGE")
                {
                    List<A3SMod> values = merge.GetValueOrDefault(match.RemoteMod, new List<A3SMod>());
                    values.Add(match.LocalMod);
                    merge[match.RemoteMod] = values;
                }

                if (match.Mode == "SPLIT_COPY")
                {
                    copy.Add(match.LocalMod, match.RemoteMod);
                }
            }
        }

        internal static List<string?> makeOperations()
        {
            List<string?> createdList = new();
            generate();

            foreach (var linksEntry in links)
                createdList.Add(LinkerProgram.link(linksEntry.Key, linksEntry.Value));

            foreach (var splitEntry in splits)
            {
                foreach (var splitValue in splitEntry.Value)
                    createdList.Add(LinkerProgram.split(splitEntry.Key, splitValue));
            }

            foreach (var mergeEntry in merge)
            {
                foreach (var mergeValue in mergeEntry.Value)
                    createdList.Add(LinkerProgram.merge(mergeEntry.Key, mergeValue));
            }

            foreach (var copyEntry in copy)
                createdList.Add(LinkerProgram.splitCopy(copyEntry.Key, copyEntry.Value));

            createdList.RemoveAll(x => x == null);
            return createdList;
        }

    }
}
