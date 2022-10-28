namespace TacticalBaconLinker
{
    /// <summary>
    /// Stellt Funktionen zum erstellen, löschen und auslesen von symbolischen Links bereit.
    /// </summary>
    public static class SymbolicLink
    {
        /// <summary>
        /// Erstellt einen symbolischen Link.
        /// </summary>
        /// <param name="target">Das Ziel auf das der Link verweißen soll.</param>
        /// <param name="path">Der Pfad des symbolischen Links.</param>
        /// <param name="replaceExisting"><c>True</c>, wenn eine bereits existierende Datei bzw. ein bereits existierender symbolischer Link überschrieben werden soll.</param>
        public static bool CreateSymbolicLink(string path, string target, bool replaceExisting)
        {
            if (replaceExisting)
            {
                if (!DeleteSymbolicLink(path))
                    return false;
            }

            bool result = false;
            if (Directory.Exists(target))
                result = Directory.CreateSymbolicLink(path, target) != null;
            else if (File.Exists(target))
                result = File.CreateSymbolicLink(path, target) != null;

            return result;
        }

        /// <summary>
        /// Löscht einen symbolischen Link.
        /// </summary>
        /// <param name="path">Der Pfad zum symbolischen Link.</param>
        public static bool DeleteSymbolicLink(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                return !Directory.Exists(path);
            }

            if (File.Exists(path))
            {
                File.Delete(path);
                return !File.Exists(path);
            }

            return true;
        }

    }
}
