namespace SudokuCustomControls
{
    partial class ColorButtonsList
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
            this.pnlHiCellOuter = new System.Windows.Forms.Panel();
            this.pnlHiCellInner = new System.Windows.Forms.Panel();
            this.rad4 = new System.Windows.Forms.RadioButton();
            this.rad3 = new System.Windows.Forms.RadioButton();
            this.rad2 = new System.Windows.Forms.RadioButton();
            this.rad1 = new System.Windows.Forms.RadioButton();
            this.radNone = new System.Windows.Forms.RadioButton();
            this.pnlHiCellOuter.SuspendLayout();
            this.pnlHiCellInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHiCellOuter
            // 
            this.pnlHiCellOuter.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlHiCellOuter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHiCellOuter.Controls.Add(this.pnlHiCellInner);
            this.pnlHiCellOuter.Location = new System.Drawing.Point(0, 0);
            this.pnlHiCellOuter.Name = "pnlHiCellOuter";
            this.pnlHiCellOuter.Size = new System.Drawing.Size(239, 42);
            this.pnlHiCellOuter.TabIndex = 56;
            // 
            // pnlHiCellInner
            // 
            this.pnlHiCellInner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHiCellInner.Controls.Add(this.rad4);
            this.pnlHiCellInner.Controls.Add(this.rad3);
            this.pnlHiCellInner.Controls.Add(this.rad2);
            this.pnlHiCellInner.Controls.Add(this.rad1);
            this.pnlHiCellInner.Controls.Add(this.radNone);
            this.pnlHiCellInner.Location = new System.Drawing.Point(3, 2);
            this.pnlHiCellInner.Name = "pnlHiCellInner";
            this.pnlHiCellInner.Size = new System.Drawing.Size(229, 35);
            this.pnlHiCellInner.TabIndex = 52;
            // 
            // rad4
            // 
            this.rad4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad4.BackColor = System.Drawing.SystemColors.Control;
            this.rad4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.rad4.Location = new System.Drawing.Point(176, 1);
            this.rad4.Name = "rad4";
            this.rad4.Size = new System.Drawing.Size(48, 30);
            this.rad4.TabIndex = 4;
            this.rad4.Tag = "4";
            this.rad4.Text = "4";
            this.rad4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad4.UseVisualStyleBackColor = false;
            this.rad4.Click += new System.EventHandler(this.radButtons_Click);
            // 
            // rad3
            // 
            this.rad3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad3.BackColor = System.Drawing.SystemColors.Control;
            this.rad3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.rad3.Location = new System.Drawing.Point(127, 1);
            this.rad3.Name = "rad3";
            this.rad3.Size = new System.Drawing.Size(48, 30);
            this.rad3.TabIndex = 3;
            this.rad3.Tag = "3";
            this.rad3.Text = "3";
            this.rad3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad3.UseVisualStyleBackColor = false;
            this.rad3.Click += new System.EventHandler(this.radButtons_Click);
            // 
            // rad2
            // 
            this.rad2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad2.BackColor = System.Drawing.SystemColors.Control;
            this.rad2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.rad2.Location = new System.Drawing.Point(78, 1);
            this.rad2.Name = "rad2";
            this.rad2.Size = new System.Drawing.Size(48, 30);
            this.rad2.TabIndex = 2;
            this.rad2.Tag = "2";
            this.rad2.Text = "2";
            this.rad2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad2.UseVisualStyleBackColor = false;
            this.rad2.Click += new System.EventHandler(this.radButtons_Click);
            // 
            // rad1
            // 
            this.rad1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad1.BackColor = System.Drawing.SystemColors.Control;
            this.rad1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.rad1.Location = new System.Drawing.Point(29, 1);
            this.rad1.Name = "rad1";
            this.rad1.Size = new System.Drawing.Size(48, 30);
            this.rad1.TabIndex = 1;
            this.rad1.Tag = "1";
            this.rad1.Text = "1";
            this.rad1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad1.UseVisualStyleBackColor = false;
            this.rad1.Click += new System.EventHandler(this.radButtons_Click);
            // 
            // radNone
            // 
            this.radNone.Appearance = System.Windows.Forms.Appearance.Button;
            this.radNone.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radNone.Checked = true;
            this.radNone.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNone.ForeColor = System.Drawing.Color.DimGray;
            this.radNone.Location = new System.Drawing.Point(1, 1);
            this.radNone.Name = "radNone";
            this.radNone.Size = new System.Drawing.Size(26, 29);
            this.radNone.TabIndex = 0;
            this.radNone.TabStop = true;
            this.radNone.Tag = "0";
            this.radNone.Text = "X";
            this.radNone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radNone.UseVisualStyleBackColor = false;
            this.radNone.Click += new System.EventHandler(this.radButtons_Click);
            // 
            // ColorButtonsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlHiCellOuter);
            this.Name = "ColorButtonsList";
            this.Size = new System.Drawing.Size(239, 42);
            this.pnlHiCellOuter.ResumeLayout(false);
            this.pnlHiCellInner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHiCellOuter;
        private System.Windows.Forms.Panel pnlHiCellInner;
        private System.Windows.Forms.RadioButton rad4;
        private System.Windows.Forms.RadioButton rad3;
        private System.Windows.Forms.RadioButton rad2;
        private System.Windows.Forms.RadioButton rad1;
        private System.Windows.Forms.RadioButton radNone;
    }
}
