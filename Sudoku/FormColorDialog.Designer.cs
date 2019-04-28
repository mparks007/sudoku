namespace Sudoku
{
    partial class frmColorDialog
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
            this.lbxChoices = new System.Windows.Forms.ListBox();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dlgExport = new System.Windows.Forms.SaveFileDialog();
            this.dlgImport = new System.Windows.Forms.OpenFileDialog();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxChoices
            // 
            this.lbxChoices.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbxChoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxChoices.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxChoices.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbxChoices.FormattingEnabled = true;
            this.lbxChoices.ItemHeight = 17;
            this.lbxChoices.Location = new System.Drawing.Point(0, 0);
            this.lbxChoices.Name = "lbxChoices";
            this.lbxChoices.Size = new System.Drawing.Size(251, 537);
            this.lbxChoices.TabIndex = 1;
            this.lbxChoices.Click += new System.EventHandler(this.lbxChoices_Click);
            // 
            // dlgColor
            // 
            this.dlgColor.FullOpen = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnExport);
            this.pnlButtons.Controls.Add(this.btnImport);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 516);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(251, 21);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.Font = new System.Drawing.Font("Yu Gothic", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnImport.Location = new System.Drawing.Point(0, 0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(125, 21);
            this.btnImport.TabIndex = 61;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Font = new System.Drawing.Font("Yu Gothic", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExport.Location = new System.Drawing.Point(126, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(125, 21);
            this.btnExport.TabIndex = 62;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dlgExport
            // 
            this.dlgExport.DefaultExt = "json";
            this.dlgExport.FileName = "customcolors.json";
            this.dlgExport.Filter = "JSON files|*.json|All files|*.*";
            this.dlgExport.InitialDirectory = ".";
            this.dlgExport.Title = "Export Custom Color Scheme";
            // 
            // dlgImport
            // 
            this.dlgImport.DefaultExt = "json";
            this.dlgImport.FileName = "customcolors.json";
            this.dlgImport.Filter = "JSON files|*.json|All files|*.*";
            this.dlgImport.InitialDirectory = ".";
            this.dlgImport.Title = "Import Custom Color Scheme";
            // 
            // frmColorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(251, 537);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lbxChoices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmColorDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customize Colors";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmColorDialog_KeyDown);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxChoices;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.SaveFileDialog dlgExport;
        private System.Windows.Forms.OpenFileDialog dlgImport;
    }
}