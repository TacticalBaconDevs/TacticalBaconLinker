using ArmA3SyncImporter;
using ArmA3SyncImporter.model;
using System.Reflection;

namespace TacticalBaconLinker
{
    public partial class FormStart : Form
    {
        public const string GESAMT_REPO_TEXT = "gesamte Repository";
        public static readonly A3SEvent GESAMT_REPO = new() { EventName = GESAMT_REPO_TEXT };
        private List<A3SEvent> events = new() { GESAMT_REPO };

        public FormStart()
        {
            InitializeComponent();
            Text += " " + Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void btnQuellFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdQuellFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbxQuelleFolder.Text = fbdQuellFolder.SelectedPath;
                tbxZielOrdner.Text = fbdQuellFolder.SelectedPath;
            }
        }

        private void tbxZielAuto_TextChanged(object sender, EventArgs e)
        {
            string text = tbxZielAuto.Text;
            if (text.StartsWith("http") && text.EndsWith("/autoconfig"))
            {
                events = new() { GESAMT_REPO };
                events.AddRange(ImporterUtils.GetEvents(text));

                // Event füllen
                cbxZielEvent.Items.Clear();
                cbxZielEvent.Items.AddRange(events.ToArray());
                cbxZielEvent.SelectedIndex = 0;
            }
        }

        public void btnVergleichen_Click(object sender, EventArgs e)
        {
            Utils.saveFormValues(this, tbxQuelleFolder, tbxZielAuto, cbxZielEvent, tbxZielOrdner, cbxAndererOrdner);

            // Quell Validierung
            var quelleFolder = tbxQuelleFolder.Text;
            if (quelleFolder.Length == 0)
            {
                MessageBox.Show("Bitte den Quell-Ordner eingeben!", "Fehler");
                return;
            }
            if (!Directory.Exists(quelleFolder))
            {
                MessageBox.Show("Der Quell-Ordner ist nicht valide!", "Fehler");
                return;
            }

            // Ziel Validierung
            var zielAuto = tbxZielAuto.Text;
            var zielEvent = cbxZielEvent.Text;
            if (zielAuto.Length == 0 || zielEvent.Length == 0)
            {
                MessageBox.Show("Es ist keine Ziel-Autoconfig/Event eingegeben", "Fehler");
                return;
            }
            if (!zielAuto.StartsWith("http") || !zielAuto.EndsWith("/autoconfig"))
            {
                MessageBox.Show("Der Ziel Autoconfig-Link ist nicht valide!", "Fehler");
                return;
            }

            // anderer ZielOrdner Validierung
            if (cbxAndererOrdner.Checked && (tbxZielOrdner.Text.Length == 0 || !Directory.Exists(tbxZielOrdner.Text)))
            {
                MessageBox.Show("Der abweichende Ziel-Ordner ist nicht valide!", "Fehler");
                return;
            }

            refreshMangeMods();

            Program.formsManager.switchTo("Select");
        }

        public void refreshMangeMods()
        {
            var quelleFolder = tbxQuelleFolder.Text;
            Utils.PATH_LOCAL_REPO = quelleFolder;
            Utils.PATH_TARGET_REPO = quelleFolder;
            List<string> localModsPaths = new List<string> { quelleFolder };

            // Zielordner ist nicht gleich Quellordner
            if (cbxAndererOrdner.Checked)
            {
                Utils.PATH_TARGET_REPO = tbxZielOrdner.Text;
                localModsPaths.Add(tbxZielOrdner.Text);
            }

            var zielAuto = tbxZielAuto.Text;
            if (zielAuto.Length > 0)
                FormSelect.ZIEL_REPO = minimizeRepoName(zielAuto);

            A3SEvent? selectedEvent = (A3SEvent)cbxZielEvent.SelectedItem;
            selectedEvent = (selectedEvent != null && !GESAMT_REPO_TEXT.Equals(selectedEvent.EventName)) ? selectedEvent : null;
            ModManager.GetModMatches(localModsPaths, zielAuto, selectedEvent);
        }

        private string minimizeRepoName(string longName)
        {
            return longName; // new Uri(longName).Host;
        }

        private void btnAuswahlZielOrdner_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdZielOrdner.ShowDialog();
            if (result == DialogResult.OK)
                tbxZielOrdner.Text = fbdZielOrdner.SelectedPath;
        }

        private void cbxAndererOrdner_CheckedChanged(object sender, EventArgs e)
        {
            var enabled = cbxAndererOrdner.Checked;
            lblZielOrdner.Enabled = enabled;
            tbxZielOrdner.Enabled = enabled;
            btnAuswahlZielOrdner.Enabled = enabled;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ((FormSelect)Program.formsManager.forms["Select"]).btnReset_Click(sender, e);
        }
    }
}
