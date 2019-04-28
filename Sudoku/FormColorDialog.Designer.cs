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
            this.lbxChoices.Size = new System.Drawing.Size(247, 523);
            this.lbxChoices.TabIndex = 1;
            this.lbxChoices.Click += new System.EventHandler(this.lbxChoices_Click);
            // 
            // dlgColor
            // 
            this.dlgColor.FullOpen = true;
            // 
            // frmColorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(247, 523);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxChoices;
        private System.Windows.Forms.ColorDialog dlgColor;
    }
}