namespace TacticalBaconLinker
{
    internal class FormsManager
    {
        public Dictionary<string, Form> forms = new();
        public Form activeForm;
        public Form? lastForm;

        public FormsManager()
        {
            forms.Add("Start", new FormStart());
            forms.Add("Select", new FormSelect());
            activeForm = forms["Start"];

            onStart();

            foreach (Form form in forms.Values)
            {
                form.FormClosed += onExit;
                form.Load += onLoad;
            }
        }

        internal void switchTo(string newForm)
        {
            lastForm = activeForm;
            lastForm.Hide();

            activeForm = forms[newForm];
            activeForm.StartPosition = FormStartPosition.CenterScreen;
            activeForm.Show();
        }

        private void onStart()
        {
            Utils.initProgram();
        }

        private void onExit(object? sender, EventArgs e)
        {
            Utils.exitProgram();
            Application.Exit();
        }

        private void onLoad(object? sender, EventArgs e)
        {
            if (sender != null && sender is Form form)
                Utils.loadFormValues(form);
        }

    }
}
