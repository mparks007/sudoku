namespace SudokuCustomControls
{
    partial class OptionButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlOption = new System.Windows.Forms.Panel();
            this.lbOption = new System.Windows.Forms.Label();
            this.chkOption = new System.Windows.Forms.CheckBox();
            this.pnlOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOption
            // 
            this.pnlOption.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlOption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOption.Controls.Add(this.lbOption);
            this.pnlOption.Controls.Add(this.chkOption);
            this.pnlOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOption.Location = new System.Drawing.Point(0, 0);
            this.pnlOption.Name = "pnlOption";
            this.pnlOption.Size = new System.Drawing.Size(242, 25);
            this.pnlOption.TabIndex = 58;
            // 
            // lbOption
            // 
            this.lbOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOption.Font = new System.Drawing.Font("Yu Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOption.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbOption.Location = new System.Drawing.Point(0, 0);
            this.lbOption.Name = "lbOption";
            this.lbOption.Size = new System.Drawing.Size(132, 21);
            this.lbOption.TabIndex = 2;
            this.lbOption.Tag = "0";
            this.lbOption.Text = "Option Label:";
            this.lbOption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkOption
            // 
            this.chkOption.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkOption.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkOption.Checked = true;
            this.chkOption.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkOption.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkOption.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkOption.Font = new System.Drawing.Font("Yu Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOption.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chkOption.Location = new System.Drawing.Point(132, 0);
            this.chkOption.Name = "chkOption";
            this.chkOption.Size = new System.Drawing.Size(106, 21);
            this.chkOption.TabIndex = 48;
            this.chkOption.TabStop = false;
            this.chkOption.Text = "Option";
            this.chkOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkOption.ThreeState = true;
            this.chkOption.UseVisualStyleBackColor = false;
            this.chkOption.CheckStateChanged += new System.EventHandler(this.chkOption_CheckStateChanged);
            // 
            // OptionButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlOption);
            this.Name = "OptionButton";
            this.Size = new System.Drawing.Size(242, 25);
            this.pnlOption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOption;
        private System.Windows.Forms.Label lbOption;
        private System.Windows.Forms.CheckBox chkOption;
    }
}
