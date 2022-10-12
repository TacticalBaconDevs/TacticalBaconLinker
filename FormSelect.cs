using ArmA3SyncImporter.model;
using System.Reflection;

namespace TacticalBaconLinker
{
    public partial class FormSelect : Form
    {
        public static string ZIEL_REPO = "";

        public FormSelect()
        {
            InitializeComponent();
            Text += " " + Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void refresh()
        {
            lbxQuell.Items.Clear();
            foreach (A3SMod quellAddon in ModManager.localMods)
                lbxQuell.Items.Add(quellAddon);
            lbxQuell.Sorted = true;

            lbxZiel.Items.Clear();
            foreach (A3SMod zielAddon in ModManager.remoteMods)
                lbxZiel.Items.Add(zielAddon);
            lbxZiel.Sorted = true;

            lbxErgebnis.Items.Clear();
            foreach (ModMatch ergebisMatch in ModManager.modMatches.Where(x => x.Mode != "DIRECT"))
                lbxErgebnis.Items.Add(ergebisMatch);
            lbxErgebnis.Sorted = true;
        }

        private void FormSelect_Load(object sender, EventArgs e)
        {
            refresh();

            lblQuell.Text = "lokale Repo";
            lblZiel.Text = ZIEL_REPO;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (ModManager.modMatches.Count == 0)
            {
                MessageBox.Show("Es gibt keine Operationen zum Anwenden.", "Fehler");
                return;
            }

            if (File.Exists("createdList.txt"))
            {
                MessageBox.Show("Es ist derzeit bereits vermutlich eine Einstellung aktiv, resette diese erst.", "Fehler");
                return;
            }

            List<string> createdList = LinkerOperations.makeOperations();
            File.WriteAllLines("createdList.txt", createdList);

            long savedSize = ModManager.modMatches.Select(x => x.SavedSize).Aggregate((x, y) => x + y);

            ((FormStart)Program.formsManager.forms["Start"]).refreshMangeMods();
            refresh();

            MessageBox.Show(string.Format("Es wurden die Änderungen angewendet und du kannst bis zu {0} sparen.", Utils.getReadableSize(savedSize)), "Info");
        }

        public void btnReset_Click(object sender, EventArgs e)
        {
            if (!File.Exists("createdList.txt"))
            {
                MessageBox.Show("Es ist derzeit keine Einstellung aktiv, ein Reset ist unnötig", "Fehler");
                return;
            }

            List<string> notDeleted = new List<string>();
            foreach (var createdDir in File.ReadAllLines("createdList.txt"))
            {
                if (Directory.Exists(createdDir))
                {
                    if (!SymbolicLink.DeleteSymbolicLink(createdDir))
                        notDeleted.Add(createdDir);
                }
            }

            if (notDeleted.Count > 0)
            {
                File.WriteAllLines("createdList_problem.txt", notDeleted);
                MessageBox.Show("Ein paar angelegte Mods konnten nicht gelöscht werden", "Fehler");
            }
            else
            {
                MessageBox.Show("Alles wurde erfolgreich reseted!", "Info");
            }

            ((FormStart)Program.formsManager.forms["Start"]).refreshMangeMods();
            refresh();

            SymbolicLink.DeleteSymbolicLink("createdList.txt");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.formsManager.switchTo("Start");
        }

        private void FormSelect_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                FormSelect_Load(sender, e);
        }
    }
}