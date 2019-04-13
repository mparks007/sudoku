namespace Sudoku
{
    partial class frmMain
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
            this.btnSetNote = new System.Windows.Forms.Button();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.radHiBad = new System.Windows.Forms.RadioButton();
            this.radHiInfo = new System.Windows.Forms.RadioButton();
            this.radHiNone = new System.Windows.Forms.RadioButton();
            this.radHiStrong = new System.Windows.Forms.RadioButton();
            this.radHiWeak = new System.Windows.Forms.RadioButton();
            this.btnHiNote = new System.Windows.Forms.Button();
            this.radSetInvalid = new System.Windows.Forms.RadioButton();
            this.radSetGuess = new System.Windows.Forms.RadioButton();
            this.radSetGiven = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radSetNone = new System.Windows.Forms.RadioButton();
            this.btnHiWithValue = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rad3 = new System.Windows.Forms.RadioButton();
            this.rad2 = new System.Windows.Forms.RadioButton();
            this.rad1 = new System.Windows.Forms.RadioButton();
            this.chkNotesMode = new System.Windows.Forms.CheckBox();
            this.rad5 = new System.Windows.Forms.RadioButton();
            this.rad4 = new System.Windows.Forms.RadioButton();
            this.rad7 = new System.Windows.Forms.RadioButton();
            this.rad6 = new System.Windows.Forms.RadioButton();
            this.rad9 = new System.Windows.Forms.RadioButton();
            this.rad8 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetNote
            // 
            this.btnSetNote.Location = new System.Drawing.Point(682, 231);
            this.btnSetNote.Name = "btnSetNote";
            this.btnSetNote.Size = new System.Drawing.Size(131, 23);
            this.btnSetNote.TabIndex = 18;
            this.btnSetNote.TabStop = false;
            this.btnSetNote.Text = "Set/Clear Note";
            this.btnSetNote.UseVisualStyleBackColor = true;
            this.btnSetNote.Click += new System.EventHandler(this.btnSetNote_Click);
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(682, 387);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(131, 23);
            this.btnAnswer.TabIndex = 28;
            this.btnAnswer.TabStop = false;
            this.btnAnswer.Text = "Set Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // radHiBad
            // 
            this.radHiBad.AutoSize = true;
            this.radHiBad.Location = new System.Drawing.Point(8, 46);
            this.radHiBad.Name = "radHiBad";
            this.radHiBad.Size = new System.Drawing.Size(44, 17);
            this.radHiBad.TabIndex = 33;
            this.radHiBad.Text = "Bad";
            this.radHiBad.UseVisualStyleBackColor = true;
            // 
            // radHiInfo
            // 
            this.radHiInfo.AutoSize = true;
            this.radHiInfo.Location = new System.Drawing.Point(8, 29);
            this.radHiInfo.Name = "radHiInfo";
            this.radHiInfo.Size = new System.Drawing.Size(43, 17);
            this.radHiInfo.TabIndex = 32;
            this.radHiInfo.Text = "Info";
            this.radHiInfo.UseVisualStyleBackColor = true;
            // 
            // radHiNone
            // 
            this.radHiNone.AutoSize = true;
            this.radHiNone.Checked = true;
            this.radHiNone.Location = new System.Drawing.Point(8, 12);
            this.radHiNone.Name = "radHiNone";
            this.radHiNone.Size = new System.Drawing.Size(51, 17);
            this.radHiNone.TabIndex = 31;
            this.radHiNone.TabStop = true;
            this.radHiNone.Text = "None";
            this.radHiNone.UseVisualStyleBackColor = true;
            // 
            // radHiStrong
            // 
            this.radHiStrong.AutoSize = true;
            this.radHiStrong.Location = new System.Drawing.Point(8, 63);
            this.radHiStrong.Name = "radHiStrong";
            this.radHiStrong.Size = new System.Drawing.Size(56, 17);
            this.radHiStrong.TabIndex = 34;
            this.radHiStrong.Text = "Strong";
            this.radHiStrong.UseVisualStyleBackColor = true;
            // 
            // radHiWeak
            // 
            this.radHiWeak.AutoSize = true;
            this.radHiWeak.Location = new System.Drawing.Point(8, 81);
            this.radHiWeak.Name = "radHiWeak";
            this.radHiWeak.Size = new System.Drawing.Size(54, 17);
            this.radHiWeak.TabIndex = 35;
            this.radHiWeak.Text = "Weak";
            this.radHiWeak.UseVisualStyleBackColor = true;
            // 
            // btnHiNote
            // 
            this.btnHiNote.Location = new System.Drawing.Point(682, 99);
            this.btnHiNote.Name = "btnHiNote";
            this.btnHiNote.Size = new System.Drawing.Size(131, 23);
            this.btnHiNote.TabIndex = 36;
            this.btnHiNote.TabStop = false;
            this.btnHiNote.Text = "Hightlight Note";
            this.btnHiNote.UseVisualStyleBackColor = true;
            this.btnHiNote.Click += new System.EventHandler(this.btnHiNote_Click);
            // 
            // radSetInvalid
            // 
            this.radSetInvalid.AutoSize = true;
            this.radSetInvalid.Location = new System.Drawing.Point(7, 59);
            this.radSetInvalid.Name = "radSetInvalid";
            this.radSetInvalid.Size = new System.Drawing.Size(56, 17);
            this.radSetInvalid.TabIndex = 40;
            this.radSetInvalid.Text = "Invalid";
            this.radSetInvalid.UseVisualStyleBackColor = true;
            // 
            // radSetGuess
            // 
            this.radSetGuess.AutoSize = true;
            this.radSetGuess.Location = new System.Drawing.Point(7, 42);
            this.radSetGuess.Name = "radSetGuess";
            this.radSetGuess.Size = new System.Drawing.Size(55, 17);
            this.radSetGuess.TabIndex = 39;
            this.radSetGuess.Text = "Guess";
            this.radSetGuess.UseVisualStyleBackColor = true;
            // 
            // radSetGiven
            // 
            this.radSetGiven.AutoSize = true;
            this.radSetGiven.Checked = true;
            this.radSetGiven.Location = new System.Drawing.Point(7, 25);
            this.radSetGiven.Name = "radSetGiven";
            this.radSetGiven.Size = new System.Drawing.Size(53, 17);
            this.radSetGiven.TabIndex = 38;
            this.radSetGiven.TabStop = true;
            this.radSetGiven.Text = "Given";
            this.radSetGiven.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radHiWeak);
            this.groupBox1.Controls.Add(this.radHiNone);
            this.groupBox1.Controls.Add(this.radHiInfo);
            this.groupBox1.Controls.Add(this.radHiBad);
            this.groupBox1.Controls.Add(this.radHiStrong);
            this.groupBox1.Location = new System.Drawing.Point(610, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(66, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radSetNone);
            this.groupBox2.Controls.Add(this.radSetInvalid);
            this.groupBox2.Controls.Add(this.radSetGiven);
            this.groupBox2.Controls.Add(this.radSetGuess);
            this.groupBox2.Location = new System.Drawing.Point(610, 355);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(67, 79);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // radSetNone
            // 
            this.radSetNone.AutoSize = true;
            this.radSetNone.Location = new System.Drawing.Point(7, 8);
            this.radSetNone.Name = "radSetNone";
            this.radSetNone.Size = new System.Drawing.Size(51, 17);
            this.radSetNone.TabIndex = 41;
            this.radSetNone.Text = "None";
            this.radSetNone.UseVisualStyleBackColor = true;
            // 
            // btnHiWithValue
            // 
            this.btnHiWithValue.Location = new System.Drawing.Point(682, 316);
            this.btnHiWithValue.Name = "btnHiWithValue";
            this.btnHiWithValue.Size = new System.Drawing.Size(131, 23);
            this.btnHiWithValue.TabIndex = 6;
            this.btnHiWithValue.TabStop = false;
            this.btnHiWithValue.Text = "Highlight With Value";
            this.btnHiWithValue.UseVisualStyleBackColor = true;
            this.btnHiWithValue.Click += new System.EventHandler(this.btnHiWithValue_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.rad9);
            this.panel1.Controls.Add(this.rad8);
            this.panel1.Controls.Add(this.rad7);
            this.panel1.Controls.Add(this.rad6);
            this.panel1.Controls.Add(this.rad5);
            this.panel1.Controls.Add(this.rad4);
            this.panel1.Controls.Add(this.rad3);
            this.panel1.Controls.Add(this.rad2);
            this.panel1.Controls.Add(this.rad1);
            this.panel1.Location = new System.Drawing.Point(594, 469);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 43);
            this.panel1.TabIndex = 47;
            // 
            // rad3
            // 
            this.rad3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad3.BackColor = System.Drawing.SystemColors.Highlight;
            this.rad3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad3.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad3.Location = new System.Drawing.Point(53, 1);
            this.rad3.Name = "rad3";
            this.rad3.Size = new System.Drawing.Size(25, 37);
            this.rad3.TabIndex = 2;
            this.rad3.Tag = "3";
            this.rad3.Text = "3";
            this.rad3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad3.UseVisualStyleBackColor = false;
            this.rad3.Click += new System.EventHandler(this.btnNumbers_Click);
            // 
            // rad2
            // 
            this.rad2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad2.BackColor = System.Drawing.SystemColors.Highlight;
            this.rad2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad2.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad2.Location = new System.Drawing.Point(27, 1);
            this.rad2.Name = "rad2";
            this.rad2.Size = new System.Drawing.Size(25, 37);
            this.rad2.TabIndex = 1;
            this.rad2.Tag = "2";
            this.rad2.Text = "2";
            this.rad2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad2.UseVisualStyleBackColor = false;
            this.rad2.Click += new System.EventHandler(this.btnNumbers_Click);
            // 
            // rad1
            // 
            this.rad1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.rad1.Checked = true;
            this.rad1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad1.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad1.Location = new System.Drawing.Point(1, 1);
            this.rad1.Name = "rad1";
            this.rad1.Size = new System.Drawing.Size(25, 37);
            this.rad1.TabIndex = 0;
            this.rad1.Tag = "1";
            this.rad1.Text = "1";
            this.rad1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad1.UseVisualStyleBackColor = false;
            this.rad1.Click += new System.EventHandler(this.btnNumbers_Click);
            // 
            // chkNotesMode
            // 
            this.chkNotesMode.AutoSize = true;
            this.chkNotesMode.Location = new System.Drawing.Point(686, 33);
            this.chkNotesMode.Name = "chkNotesMode";
            this.chkNotesMode.Size = new System.Drawing.Size(84, 17);
            this.chkNotesMode.TabIndex = 48;
            this.chkNotesMode.Text = "Notes Mode";
            this.chkNotesMode.UseVisualStyleBackColor = true;
            // 
            // rad5
            // 
            this.rad5.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad5.BackColor = System.Drawing.SystemColors.Highlight;
            this.rad5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad5.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad5.Location = new System.Drawing.Point(105, 1);
            this.rad5.Name = "rad5";
            this.rad5.Size = new System.Drawing.Size(25, 37);
            this.rad5.TabIndex = 4;
            this.rad5.Tag = "5";
            this.rad5.Text = "5";
            this.rad5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad5.UseVisualStyleBackColor = false;
            this.rad5.Click += new System.EventHandler(this.btnNumbers_Click);
            // 
            // rad4
            // 
            this.rad4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad4.BackColor = System.Drawing.SystemColors.Highlight;
            this.rad4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad4.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad4.Location = new System.Drawing.Point(79, 1);
            this.rad4.Name = "rad4";
            this.rad4.Size = new System.Drawing.Size(25, 37);
            this.rad4.TabIndex = 3;
            this.rad4.Tag = "4";
            this.rad4.Text = "4";
            this.rad4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad4.UseVisualStyleBackColor = false;
            this.rad4.Click += new System.EventHandler(this.btnNumbers_Click);
            // 
            // rad7
            // 
            this.rad7.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad7.BackColor = System.Drawing.SystemColors.Highlight;
            this.rad7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad7.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad7.Location = new System.Drawing.Point(157, 1);
            this.rad7.Name = "rad7";
            this.rad7.Size = new System.Drawing.Size(25, 37);
            this.rad7.TabIndex = 6;
            this.rad7.Tag = "7";
            this.rad7.Text = "7";
            this.rad7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad7.UseVisualStyleBackColor = false;
            this.rad7.Click += new System.EventHandler(this.btnNumbers_Click);
            // 
            // rad6
            // 
            this.rad6.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad6.BackColor = System.Drawing.SystemColors.Highlight;
            this.rad6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad6.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad6.Location = new System.Drawing.Point(131, 1);
            this.rad6.Name = "rad6";
            this.rad6.Size = new System.Drawing.Size(25, 37);
            this.rad6.TabIndex = 5;
            this.rad6.Tag = "6";
            this.rad6.Text = "6";
            this.rad6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad6.UseVisualStyleBackColor = false;
            this.rad6.Click += new System.EventHandler(this.btnNumbers_Click);
            // 
            // rad9
            // 
            this.rad9.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad9.BackColor = System.Drawing.SystemColors.Highlight;
            this.rad9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad9.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad9.Location = new System.Drawing.Point(209, 1);
            this.rad9.Name = "rad9";
            this.rad9.Size = new System.Drawing.Size(25, 37);
            this.rad9.TabIndex = 8;
            this.rad9.Tag = "9";
            this.rad9.Text = "9";
            this.rad9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad9.UseVisualStyleBackColor = false;
            this.rad9.Click += new System.EventHandler(this.btnNumbers_Click);
            // 
            // rad8
            // 
            this.rad8.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad8.BackColor = System.Drawing.SystemColors.Highlight;
            this.rad8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad8.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad8.Location = new System.Drawing.Point(183, 1);
            this.rad8.Name = "rad8";
            this.rad8.Size = new System.Drawing.Size(25, 37);
            this.rad8.TabIndex = 7;
            this.rad8.Tag = "8";
            this.rad8.Text = "8";
            this.rad8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad8.UseVisualStyleBackColor = false;
            this.rad8.Click += new System.EventHandler(this.btnNumbers_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(880, 577);
            this.Controls.Add(this.chkNotesMode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHiNote);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.btnSetNote);
            this.Controls.Add(this.btnHiWithValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 620);
            this.MinimumSize = new System.Drawing.Size(900, 620);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Woofus Sudoku";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSetNote;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.RadioButton radHiBad;
        private System.Windows.Forms.RadioButton radHiInfo;
        private System.Windows.Forms.RadioButton radHiNone;
        private System.Windows.Forms.RadioButton radHiStrong;
        private System.Windows.Forms.RadioButton radHiWeak;
        private System.Windows.Forms.Button btnHiNote;
        private System.Windows.Forms.RadioButton radSetInvalid;
        private System.Windows.Forms.RadioButton radSetGuess;
        private System.Windows.Forms.RadioButton radSetGiven;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHiWithValue;
        private System.Windows.Forms.RadioButton radSetNone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rad3;
        private System.Windows.Forms.RadioButton rad2;
        private System.Windows.Forms.RadioButton rad1;
        private System.Windows.Forms.CheckBox chkNotesMode;
        private System.Windows.Forms.RadioButton rad9;
        private System.Windows.Forms.RadioButton rad8;
        private System.Windows.Forms.RadioButton rad7;
        private System.Windows.Forms.RadioButton rad6;
        private System.Windows.Forms.RadioButton rad5;
        private System.Windows.Forms.RadioButton rad4;
    }
}

