namespace TacticalBaconLinker
{
    partial class FormStart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStart));
            this.btnVergleichen = new System.Windows.Forms.Button();
            this.gbxQuelle = new System.Windows.Forms.GroupBox();
            this.btnQuellFolder = new System.Windows.Forms.Button();
            this.tbxQuelleFolder = new System.Windows.Forms.TextBox();
            this.lblQuelleFolder = new System.Windows.Forms.Label();
            this.fbdQuellFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.gbxZiel = new System.Windows.Forms.GroupBox();
            this.cbxZielEvent = new System.Windows.Forms.ComboBox();
            this.lblZielEvent = new System.Windows.Forms.Label();
            this.tbxZielAuto = new System.Windows.Forms.TextBox();
            this.lblZielAuto = new System.Windows.Forms.Label();
            this.gbxWeiteres = new System.Windows.Forms.GroupBox();
            this.cbxAndererOrdner = new System.Windows.Forms.CheckBox();
            this.btnAuswahlZielOrdner = new System.Windows.Forms.Button();
            this.tbxZielOrdner = new System.Windows.Forms.TextBox();
            this.lblZielOrdner = new System.Windows.Forms.Label();
            this.fbdZielOrdner = new System.Windows.Forms.FolderBrowserDialog();
            this.btnReset = new System.Windows.Forms.Button();
            this.gbxQuelle.SuspendLayout();
            this.gbxZiel.SuspendLayout();
            this.gbxWeiteres.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVergleichen
            // 
            this.btnVergleichen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVergleichen.Location = new System.Drawing.Point(272, 293);
            this.btnVergleichen.Name = "btnVergleichen";
            this.btnVergleichen.Size = new System.Drawing.Size(109, 30);
            this.btnVergleichen.TabIndex = 10;
            this.btnVergleichen.Text = "Vergleichen";
            this.btnVergleichen.UseVisualStyleBackColor = true;
            this.btnVergleichen.Click += new System.EventHandler(this.btnVergleichen_Click);
            // 
            // gbxQuelle
            // 
            this.gbxQuelle.Controls.Add(this.btnQuellFolder);
            this.gbxQuelle.Controls.Add(this.tbxQuelleFolder);
            this.gbxQuelle.Controls.Add(this.lblQuelleFolder);
            this.gbxQuelle.Location = new System.Drawing.Point(12, 12);
            this.gbxQuelle.Name = "gbxQuelle";
            this.gbxQuelle.Size = new System.Drawing.Size(628, 70);
            this.gbxQuelle.TabIndex = 11;
            this.gbxQuelle.TabStop = false;
            this.gbxQuelle.Text = "Quelle";
            // 
            // btnQuellFolder
            // 
            this.btnQuellFolder.Location = new System.Drawing.Point(552, 30);
            this.btnQuellFolder.Name = "btnQuellFolder";
            this.btnQuellFolder.Size = new System.Drawing.Size(61, 23);
            this.btnQuellFolder.TabIndex = 12;
            this.btnQuellFolder.Text = "Auswahl";
            this.btnQuellFolder.UseVisualStyleBackColor = true;
            this.btnQuellFolder.Click += new System.EventHandler(this.btnQuellFolder_Click);
            // 
            // tbxQuelleFolder
            // 
            this.tbxQuelleFolder.Location = new System.Drawing.Point(83, 31);
            this.tbxQuelleFolder.Name = "tbxQuelleFolder";
            this.tbxQuelleFolder.Size = new System.Drawing.Size(463, 23);
            this.tbxQuelleFolder.TabIndex = 11;
            // 
            // lblQuelleFolder
            // 
            this.lblQuelleFolder.Location = new System.Drawing.Point(6, 31);
            this.lblQuelleFolder.Name = "lblQuelleFolder";
            this.lblQuelleFolder.Size = new System.Drawing.Size(82, 23);
            this.lblQuelleFolder.TabIndex = 10;
            this.lblQuelleFolder.Text = "Quell Ordner:";
            this.lblQuelleFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fbdQuellFolder
            // 
            this.fbdQuellFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdQuellFolder.ShowNewFolderButton = false;
            // 
            // gbxZiel
            // 
            this.gbxZiel.Controls.Add(this.cbxZielEvent);
            this.gbxZiel.Controls.Add(this.lblZielEvent);
            this.gbxZiel.Controls.Add(this.tbxZielAuto);
            this.gbxZiel.Controls.Add(this.lblZielAuto);
            this.gbxZiel.Location = new System.Drawing.Point(12, 88);
            this.gbxZiel.Name = "gbxZiel";
            this.gbxZiel.Size = new System.Drawing.Size(628, 108);
            this.gbxZiel.TabIndex = 12;
            this.gbxZiel.TabStop = false;
            this.gbxZiel.Text = "Zielrepo";
            // 
            // cbxZielEvent
            // 
            this.cbxZielEvent.FormattingEnabled = true;
            this.cbxZielEvent.Location = new System.Drawing.Point(83, 70);
            this.cbxZielEvent.Name = "cbxZielEvent";
            this.cbxZielEvent.Size = new System.Drawing.Size(530, 23);
            this.cbxZielEvent.TabIndex = 11;
            // 
            // lblZielEvent
            // 
            this.lblZielEvent.Location = new System.Drawing.Point(6, 69);
            this.lblZielEvent.Name = "lblZielEvent";
            this.lblZielEvent.Size = new System.Drawing.Size(71, 23);
            this.lblZielEvent.TabIndex = 10;
            this.lblZielEvent.Text = "Event:";
            this.lblZielEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxZielAuto
            // 
            this.tbxZielAuto.Location = new System.Drawing.Point(83, 32);
            this.tbxZielAuto.Name = "tbxZielAuto";
            this.tbxZielAuto.Size = new System.Drawing.Size(530, 23);
            this.tbxZielAuto.TabIndex = 9;
            this.tbxZielAuto.TextChanged += new System.EventHandler(this.tbxZielAuto_TextChanged);
            // 
            // lblZielAuto
            // 
            this.lblZielAuto.Location = new System.Drawing.Point(6, 31);
            this.lblZielAuto.Name = "lblZielAuto";
            this.lblZielAuto.Size = new System.Drawing.Size(71, 23);
            this.lblZielAuto.TabIndex = 8;
            this.lblZielAuto.Text = "Autoconfig:";
            this.lblZielAuto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxWeiteres
            // 
            this.gbxWeiteres.Controls.Add(this.cbxAndererOrdner);
            this.gbxWeiteres.Controls.Add(this.btnAuswahlZielOrdner);
            this.gbxWeiteres.Controls.Add(this.tbxZielOrdner);
            this.gbxWeiteres.Controls.Add(this.lblZielOrdner);
            this.gbxWeiteres.Location = new System.Drawing.Point(12, 202);
            this.gbxWeiteres.Name = "gbxWeiteres";
            this.gbxWeiteres.Size = new System.Drawing.Size(628, 85);
            this.gbxWeiteres.TabIndex = 13;
            this.gbxWeiteres.TabStop = false;
            this.gbxWeiteres.Text = "weiteres";
            // 
            // cbxAndererOrdner
            // 
            this.cbxAndererOrdner.AutoSize = true;
            this.cbxAndererOrdner.Location = new System.Drawing.Point(10, 28);
            this.cbxAndererOrdner.Name = "cbxAndererOrdner";
            this.cbxAndererOrdner.Size = new System.Drawing.Size(247, 19);
            this.cbxAndererOrdner.TabIndex = 16;
            this.cbxAndererOrdner.Text = "anderen Ordner als Ziel Ordner auswählen";
            this.cbxAndererOrdner.UseVisualStyleBackColor = true;
            this.cbxAndererOrdner.CheckedChanged += new System.EventHandler(this.cbxAndererOrdner_CheckedChanged);
            // 
            // btnAuswahlZielOrdner
            // 
            this.btnAuswahlZielOrdner.Enabled = false;
            this.btnAuswahlZielOrdner.Location = new System.Drawing.Point(552, 51);
            this.btnAuswahlZielOrdner.Name = "btnAuswahlZielOrdner";
            this.btnAuswahlZielOrdner.Size = new System.Drawing.Size(61, 23);
            this.btnAuswahlZielOrdner.TabIndex = 15;
            this.btnAuswahlZielOrdner.Text = "Auswahl";
            this.btnAuswahlZielOrdner.UseVisualStyleBackColor = true;
            this.btnAuswahlZielOrdner.Click += new System.EventHandler(this.btnAuswahlZielOrdner_Click);
            // 
            // tbxZielOrdner
            // 
            this.tbxZielOrdner.Enabled = false;
            this.tbxZielOrdner.Location = new System.Drawing.Point(83, 51);
            this.tbxZielOrdner.Name = "tbxZielOrdner";
            this.tbxZielOrdner.Size = new System.Drawing.Size(463, 23);
            this.tbxZielOrdner.TabIndex = 14;
            // 
            // lblZielOrdner
            // 
            this.lblZielOrdner.Enabled = false;
            this.lblZielOrdner.Location = new System.Drawing.Point(6, 50);
            this.lblZielOrdner.Name = "lblZielOrdner";
            this.lblZielOrdner.Size = new System.Drawing.Size(71, 23);
            this.lblZielOrdner.TabIndex = 13;
            this.lblZielOrdner.Text = "Ziel Ordner:";
            this.lblZielOrdner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fbdZielOrdner
            // 
            this.fbdZielOrdner.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdZielOrdner.ShowNewFolderButton = false;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReset.Location = new System.Drawing.Point(567, 294);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(73, 30);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(650, 329);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.gbxWeiteres);
            this.Controls.Add(this.gbxZiel);
            this.Controls.Add(this.gbxQuelle);
            this.Controls.Add(this.btnVergleichen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TacticalBaconLinker";
            this.gbxQuelle.ResumeLayout(false);
            this.gbxQuelle.PerformLayout();
            this.gbxZiel.ResumeLayout(false);
            this.gbxZiel.PerformLayout();
            this.gbxWeiteres.ResumeLayout(false);
            this.gbxWeiteres.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnVergleichen;
        private GroupBox gbxQuelle;
        private Button btnQuellFolder;
        private TextBox tbxQuelleFolder;
        private Label lblQuelleFolder;
        private FolderBrowserDialog fbdQuellFolder;
        private GroupBox gbxZiel;
        private ComboBox cbxZielEvent;
        private Label lblZielEvent;
        private TextBox tbxZielAuto;
        private Label lblZielAuto;
        private GroupBox gbxWeiteres;
        private Button btnAuswahlZielOrdner;
        private TextBox tbxZielOrdner;
        private Label lblZielOrdner;
        private FolderBrowserDialog fbdZielOrdner;
        private CheckBox cbxAndererOrdner;
        private Button btnReset;
    }
}