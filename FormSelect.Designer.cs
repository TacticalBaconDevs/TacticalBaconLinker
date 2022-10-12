namespace TacticalBaconLinker
{
    partial class FormSelect
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelect));
            this.lbxQuell = new System.Windows.Forms.ListBox();
            this.lbxZiel = new System.Windows.Forms.ListBox();
            this.lbxErgebnis = new System.Windows.Forms.ListBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblQuell = new System.Windows.Forms.Label();
            this.lblZiel = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxQuell
            // 
            this.lbxQuell.FormattingEnabled = true;
            this.lbxQuell.ItemHeight = 15;
            this.lbxQuell.Location = new System.Drawing.Point(12, 40);
            this.lbxQuell.Name = "lbxQuell";
            this.lbxQuell.Size = new System.Drawing.Size(281, 394);
            this.lbxQuell.TabIndex = 4;
            // 
            // lbxZiel
            // 
            this.lbxZiel.FormattingEnabled = true;
            this.lbxZiel.ItemHeight = 15;
            this.lbxZiel.Location = new System.Drawing.Point(318, 40);
            this.lbxZiel.Name = "lbxZiel";
            this.lbxZiel.Size = new System.Drawing.Size(281, 394);
            this.lbxZiel.TabIndex = 6;
            // 
            // lbxErgebnis
            // 
            this.lbxErgebnis.FormattingEnabled = true;
            this.lbxErgebnis.ItemHeight = 15;
            this.lbxErgebnis.Location = new System.Drawing.Point(12, 451);
            this.lbxErgebnis.Name = "lbxErgebnis";
            this.lbxErgebnis.Size = new System.Drawing.Size(587, 169);
            this.lbxErgebnis.TabIndex = 7;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReset.Location = new System.Drawing.Point(307, 626);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(73, 30);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblQuell
            // 
            this.lblQuell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQuell.Location = new System.Drawing.Point(12, 9);
            this.lblQuell.Name = "lblQuell";
            this.lblQuell.Size = new System.Drawing.Size(250, 28);
            this.lblQuell.TabIndex = 13;
            this.lblQuell.Text = "QuellRepo";
            // 
            // lblZiel
            // 
            this.lblZiel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblZiel.Location = new System.Drawing.Point(318, 9);
            this.lblZiel.Name = "lblZiel";
            this.lblZiel.Size = new System.Drawing.Size(281, 28);
            this.lblZiel.TabIndex = 14;
            this.lblZiel.Text = "ZielRepo";
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnApply.Location = new System.Drawing.Point(228, 626);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(73, 30);
            this.btnApply.TabIndex = 15;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(524, 626);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Zurück";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 663);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblZiel);
            this.Controls.Add(this.lblQuell);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lbxErgebnis);
            this.Controls.Add(this.lbxZiel);
            this.Controls.Add(this.lbxQuell);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelect";
            this.Text = "TacticalBaconLinker";
            this.Load += new System.EventHandler(this.FormSelect_Load);
            this.VisibleChanged += new System.EventHandler(this.FormSelect_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion
        private ListBox lbxQuell;
        private ListBox lbxZiel;
        private ListBox lbxErgebnis;
        private Button btnReset;
        private Label lblQuell;
        private Label lblZiel;
        private Button btnApply;
        private Button btnBack;
    }
}