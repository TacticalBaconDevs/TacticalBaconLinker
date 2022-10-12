using ArmA3SyncImporter.model;
using System.Reflection;
using System.Text;

namespace TacticalBaconLinker
{
    internal class Utils
    {
        private static string? PATH_EXE;
        private static string? PATH_VOR_EXE;
        public static string PATH_LOCAL_REPO = "";
        public static string PATH_TARGET_REPO = "";
        private static Dictionary<string, string> settings = new Dictionary<string, string>();

        internal static void initProgram()
        {
            // Set path to appdata path
            string path = getAppPath("");
            Directory.CreateDirectory(path);
            Directory.SetCurrentDirectory(path);

            // Setting loaden
            manageSetting(true);
        }
        internal static void exitProgram()
        {
            manageSetting(false);
        }

        internal static string getAppPath(string path)
        {
            return Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TacticalBaconDevs\TacticalBaconLinker\", path);
        }

        internal static string getModPath(string mod)
        {
            if (PATH_EXE != null && Directory.Exists(Combine(getExePath(), mod)))
                return PATH_EXE;
            if (PATH_VOR_EXE != null && Directory.Exists(Combine(getExePath(true), mod)))
                return PATH_VOR_EXE;
            if (PATH_LOCAL_REPO != null && Directory.Exists(Combine(PATH_LOCAL_REPO, mod)))
                return PATH_LOCAL_REPO;

            return "";
        }

        internal static string getExePath(bool vor = false)
        {
            if (PATH_EXE == null)
            {
                Assembly? assembly = Assembly.GetEntryAssembly();
                PATH_EXE = assembly != null ? Path.GetDirectoryName(assembly.Location) : null;
                if (PATH_EXE == null || PATH_EXE.Length == 0)
                    PATH_EXE = Application.StartupPath;

                if (PATH_EXE != null && PATH_EXE.Length > 0)
                    PATH_VOR_EXE = PATH_EXE.Substring(0, PATH_EXE.LastIndexOf('\\'));
            }

            string? result = vor ? PATH_VOR_EXE : PATH_EXE;
            return result != null ? result : "";
        }

        internal static string getExePath()
        {
            Assembly? assembly = Assembly.GetEntryAssembly();
            string? result = assembly != null ? Path.GetDirectoryName(assembly.Location) : null;
            if (result == null)
                result = Application.StartupPath;

            return result != null ? result : "";
        }

        internal static string Combine(string path1, string path2)
        {
            if (Path.IsPathRooted(path2))
            {
                path2 = path2.TrimStart(Path.DirectorySeparatorChar);
                path2 = path2.TrimStart(Path.AltDirectorySeparatorChar);
            }

            return Path.Combine(path1, path2);
        }

        internal static void manageSetting(bool load = true)
        {
            string settingPath = getAppPath("setting.cfg");

            if (load)
            {
                if (File.Exists(settingPath))
                {
                    foreach (string line in File.ReadAllLines(settingPath))
                    {
                        string[] elements = line.Split("#", 2, StringSplitOptions.TrimEntries);
                        settings.Add(elements[0], elements[1]);
                    }
                }
            }
            else
            {
                File.WriteAllLines(settingPath, settings.Select(x => string.Format("{0}#{1}", x.Key, x.Value)), Encoding.UTF8);
            }
        }

        internal static string? getSetting(string key)
        {
            settings.TryGetValue(key, out string? result);
            return result;
        }

        internal static void setSetting(string key, string value, bool save = true)
        {
            if (settings.ContainsKey(key))
                settings[key] = value;
            else
                settings.Add(key, value);

            if (save)
                manageSetting(false);
        }

        internal static void saveFormValues(Form form, params Control[] controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox tbx)
                    setSetting(form.Name + "." + tbx.Name, tbx.Text, false);
                if (control is ComboBox cbx)
                    setSetting(form.Name + "." + cbx.Name, cbx.SelectedIndex.ToString(), false);
                if (control is CheckBox chbx)
                    setSetting(form.Name + "." + chbx.Name, chbx.Checked.ToString(), false);
            }

            manageSetting(false);
        }

        internal static void loadFormValues(Form form)
        {
            var ident = form.Name + ".";
            List<Control> controls = GetAll(form);

            foreach (string controlName in settings.Where(x => x.Key.StartsWith(ident)).Select(x => x.Key.Substring(ident.Length)))
            {
                Control? control = controls.Find(x => x.Name == controlName);
                if (control is TextBox tbx)
                    tbx.Text = getSetting(ident + controlName);
                if (control is ComboBox cbx)
                    cbx.SelectedIndex = Convert.ToInt32(getSetting(ident + controlName));
                if (control is CheckBox chbx)
                    chbx.Checked = Convert.ToBoolean(getSetting(ident + controlName));
            }

            manageSetting(false);
        }

        public static List<Control> GetAll(Control control, Type? type = null)
        {
            var controls = control.Controls.Cast<Control>();
            return new List<Control>(controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => type == null || c.GetType() == type));
        }

        internal static bool eq(string? x, string? y)
        {
            if (x != null)
                return x.Equals(y, StringComparison.OrdinalIgnoreCase);
            else if (y != null)
                return y.Equals(x, StringComparison.OrdinalIgnoreCase);

            return x == y;
        }

        internal static bool eq(A3SMod x, A3SMod y)
        {
            if (x == null || y == null)
                return false;

            return eq(x.ModName, y.ModName);
        }

        internal static string getReadableSize(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        internal static void logError(string msg)
        {
            File.AppendAllText(Combine(getExePath(), "TBLinkerManager_Error.txt"), msg);
        }

    }
}
