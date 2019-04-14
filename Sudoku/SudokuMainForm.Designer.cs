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
            this.btnSetGiven = new System.Windows.Forms.Button();
            this.pnlNumbers = new System.Windows.Forms.Panel();
            this.rad9 = new System.Windows.Forms.RadioButton();
            this.rad8 = new System.Windows.Forms.RadioButton();
            this.rad7 = new System.Windows.Forms.RadioButton();
            this.rad6 = new System.Windows.Forms.RadioButton();
            this.rad5 = new System.Windows.Forms.RadioButton();
            this.rad4 = new System.Windows.Forms.RadioButton();
            this.rad3 = new System.Windows.Forms.RadioButton();
            this.rad2 = new System.Windows.Forms.RadioButton();
            this.rad1 = new System.Windows.Forms.RadioButton();
            this.chkNumberMode = new System.Windows.Forms.CheckBox();
            this.btnSetGuess = new System.Windows.Forms.Button();
            this.btnToggleNote = new System.Windows.Forms.Button();
            this.btnHighlightHavingValue = new System.Windows.Forms.Button();
            this.pnlHiNoteInner = new System.Windows.Forms.Panel();
            this.radHiBad = new System.Windows.Forms.RadioButton();
            this.radHiWeak = new System.Windows.Forms.RadioButton();
            this.radHiStrong = new System.Windows.Forms.RadioButton();
            this.radHiInfo = new System.Windows.Forms.RadioButton();
            this.radHiNone = new System.Windows.Forms.RadioButton();
            this.pnlHiNoteOuter = new System.Windows.Forms.Panel();
            this.pnlNotesMode = new System.Windows.Forms.Panel();
            this.lblNumberMode = new System.Windows.Forms.Label();
            this.pnlNumbers.SuspendLayout();
            this.pnlHiNoteInner.SuspendLayout();
            this.pnlHiNoteOuter.SuspendLayout();
            this.pnlNotesMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetGiven
            // 
            this.btnSetGiven.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSetGiven.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetGiven.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetGiven.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSetGiven.Location = new System.Drawing.Point(581, 397);
            this.btnSetGiven.Name = "btnSetGiven";
            this.btnSetGiven.Size = new System.Drawing.Size(239, 38);
            this.btnSetGiven.TabIndex = 0;
            this.btnSetGiven.TabStop = false;
            this.btnSetGiven.Text = "Set Given";
            this.btnSetGiven.UseVisualStyleBackColor = false;
            this.btnSetGiven.Click += new System.EventHandler(this.btnSetGiven_Click);
            // 
            // pnlNumbers
            // 
            this.pnlNumbers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNumbers.Controls.Add(this.rad9);
            this.pnlNumbers.Controls.Add(this.rad8);
            this.pnlNumbers.Controls.Add(this.rad7);
            this.pnlNumbers.Controls.Add(this.rad6);
            this.pnlNumbers.Controls.Add(this.rad5);
            this.pnlNumbers.Controls.Add(this.rad4);
            this.pnlNumbers.Controls.Add(this.rad3);
            this.pnlNumbers.Controls.Add(this.rad2);
            this.pnlNumbers.Controls.Add(this.rad1);
            this.pnlNumbers.Location = new System.Drawing.Point(581, 352);
            this.pnlNumbers.Name = "pnlNumbers";
            this.pnlNumbers.Size = new System.Drawing.Size(239, 43);
            this.pnlNumbers.TabIndex = 47;
            // 
            // rad9
            // 
            this.rad9.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad9.BackColor = System.Drawing.SystemColors.Highlight;
            this.rad9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad9.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad9.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            this.rad8.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            // rad7
            // 
            this.rad7.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad7.BackColor = System.Drawing.SystemColors.Highlight;
            this.rad7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad7.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad7.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            this.rad6.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            // rad5
            // 
            this.rad5.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad5.BackColor = System.Drawing.SystemColors.Highlight;
            this.rad5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad5.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad5.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            this.rad4.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            // rad3
            // 
            this.rad3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad3.BackColor = System.Drawing.SystemColors.Highlight;
            this.rad3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rad3.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad3.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            this.rad2.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            this.rad1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.rad1.Location = new System.Drawing.Point(1, 1);
            this.rad1.Name = "rad1";
            this.rad1.Size = new System.Drawing.Size(25, 37);
            this.rad1.TabIndex = 0;
            this.rad1.TabStop = true;
            this.rad1.Tag = "1";
            this.rad1.Text = "1";
            this.rad1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rad1.UseVisualStyleBackColor = false;
            this.rad1.Click += new System.EventHandler(this.btnNumbers_Click);
            // 
            // chkNumberMode
            // 
            this.chkNumberMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkNumberMode.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkNumberMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkNumberMode.Font = new System.Drawing.Font("Yu Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNumberMode.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chkNumberMode.Location = new System.Drawing.Point(120, 2);
            this.chkNumberMode.Name = "chkNumberMode";
            this.chkNumberMode.Size = new System.Drawing.Size(112, 21);
            this.chkNumberMode.TabIndex = 48;
            this.chkNumberMode.Text = "Numbers";
            this.chkNumberMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkNumberMode.UseVisualStyleBackColor = false;
            this.chkNumberMode.CheckedChanged += new System.EventHandler(this.chkNumberMode_CheckedChanged);
            // 
            // btnSetGuess
            // 
            this.btnSetGuess.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSetGuess.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetGuess.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetGuess.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSetGuess.Location = new System.Drawing.Point(581, 312);
            this.btnSetGuess.Name = "btnSetGuess";
            this.btnSetGuess.Size = new System.Drawing.Size(239, 38);
            this.btnSetGuess.TabIndex = 49;
            this.btnSetGuess.TabStop = false;
            this.btnSetGuess.Text = "Set Guess";
            this.btnSetGuess.UseVisualStyleBackColor = false;
            this.btnSetGuess.Click += new System.EventHandler(this.btnSetGuess_Click);
            // 
            // btnToggleNote
            // 
            this.btnToggleNote.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnToggleNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToggleNote.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleNote.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnToggleNote.Location = new System.Drawing.Point(581, 232);
            this.btnToggleNote.Name = "btnToggleNote";
            this.btnToggleNote.Size = new System.Drawing.Size(239, 38);
            this.btnToggleNote.TabIndex = 50;
            this.btnToggleNote.TabStop = false;
            this.btnToggleNote.Text = "Toggle Note";
            this.btnToggleNote.UseVisualStyleBackColor = false;
            this.btnToggleNote.Click += new System.EventHandler(this.btnToggleNote_Click);
            // 
            // btnHighlightHavingValue
            // 
            this.btnHighlightHavingValue.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnHighlightHavingValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHighlightHavingValue.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighlightHavingValue.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnHighlightHavingValue.Location = new System.Drawing.Point(581, 272);
            this.btnHighlightHavingValue.Name = "btnHighlightHavingValue";
            this.btnHighlightHavingValue.Size = new System.Drawing.Size(239, 38);
            this.btnHighlightHavingValue.TabIndex = 51;
            this.btnHighlightHavingValue.TabStop = false;
            this.btnHighlightHavingValue.Text = "Highlight Having Value";
            this.btnHighlightHavingValue.UseVisualStyleBackColor = false;
            this.btnHighlightHavingValue.Click += new System.EventHandler(this.btnHighlightHavingValue_Click);
            // 
            // pnlHiNoteInner
            // 
            this.pnlHiNoteInner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHiNoteInner.Controls.Add(this.radHiBad);
            this.pnlHiNoteInner.Controls.Add(this.radHiWeak);
            this.pnlHiNoteInner.Controls.Add(this.radHiStrong);
            this.pnlHiNoteInner.Controls.Add(this.radHiInfo);
            this.pnlHiNoteInner.Controls.Add(this.radHiNone);
            this.pnlHiNoteInner.Location = new System.Drawing.Point(3, 2);
            this.pnlHiNoteInner.Name = "pnlHiNoteInner";
            this.pnlHiNoteInner.Size = new System.Drawing.Size(229, 35);
            this.pnlHiNoteInner.TabIndex = 52;
            // 
            // radHiBad
            // 
            this.radHiBad.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiBad.BackColor = System.Drawing.Color.Red;
            this.radHiBad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiBad.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiBad.ForeColor = System.Drawing.Color.LightGray;
            this.radHiBad.Location = new System.Drawing.Point(176, 1);
            this.radHiBad.Name = "radHiBad";
            this.radHiBad.Size = new System.Drawing.Size(48, 30);
            this.radHiBad.TabIndex = 4;
            this.radHiBad.Tag = "5";
            this.radHiBad.Text = "Bad";
            this.radHiBad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiBad.UseVisualStyleBackColor = false;
            this.radHiBad.Click += new System.EventHandler(this.radHiClick);
            // 
            // radHiWeak
            // 
            this.radHiWeak.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiWeak.BackColor = System.Drawing.Color.Yellow;
            this.radHiWeak.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiWeak.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiWeak.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.radHiWeak.Location = new System.Drawing.Point(127, 1);
            this.radHiWeak.Name = "radHiWeak";
            this.radHiWeak.Size = new System.Drawing.Size(48, 30);
            this.radHiWeak.TabIndex = 3;
            this.radHiWeak.Tag = "4";
            this.radHiWeak.Text = "Weak";
            this.radHiWeak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiWeak.UseVisualStyleBackColor = false;
            this.radHiWeak.Click += new System.EventHandler(this.radHiClick);
            // 
            // radHiStrong
            // 
            this.radHiStrong.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiStrong.BackColor = System.Drawing.Color.RoyalBlue;
            this.radHiStrong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiStrong.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiStrong.ForeColor = System.Drawing.Color.LightGray;
            this.radHiStrong.Location = new System.Drawing.Point(78, 1);
            this.radHiStrong.Name = "radHiStrong";
            this.radHiStrong.Size = new System.Drawing.Size(48, 30);
            this.radHiStrong.TabIndex = 2;
            this.radHiStrong.Tag = "3";
            this.radHiStrong.Text = "Strong";
            this.radHiStrong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiStrong.UseVisualStyleBackColor = false;
            this.radHiStrong.Click += new System.EventHandler(this.radHiClick);
            // 
            // radHiInfo
            // 
            this.radHiInfo.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiInfo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.radHiInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiInfo.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiInfo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.radHiInfo.Location = new System.Drawing.Point(29, 1);
            this.radHiInfo.Name = "radHiInfo";
            this.radHiInfo.Size = new System.Drawing.Size(48, 30);
            this.radHiInfo.TabIndex = 1;
            this.radHiInfo.Tag = "2";
            this.radHiInfo.Text = "Info";
            this.radHiInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiInfo.UseVisualStyleBackColor = false;
            this.radHiInfo.Click += new System.EventHandler(this.radHiClick);
            // 
            // radHiNone
            // 
            this.radHiNone.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiNone.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radHiNone.Checked = true;
            this.radHiNone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiNone.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiNone.ForeColor = System.Drawing.Color.DimGray;
            this.radHiNone.Location = new System.Drawing.Point(1, 1);
            this.radHiNone.Name = "radHiNone";
            this.radHiNone.Size = new System.Drawing.Size(26, 29);
            this.radHiNone.TabIndex = 0;
            this.radHiNone.TabStop = true;
            this.radHiNone.Tag = "1";
            this.radHiNone.Text = "X";
            this.radHiNone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiNone.UseVisualStyleBackColor = false;
            this.radHiNone.Click += new System.EventHandler(this.radHiClick);
            // 
            // pnlHiNoteOuter
            // 
            this.pnlHiNoteOuter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHiNoteOuter.Controls.Add(this.pnlHiNoteInner);
            this.pnlHiNoteOuter.Location = new System.Drawing.Point(581, 186);
            this.pnlHiNoteOuter.Name = "pnlHiNoteOuter";
            this.pnlHiNoteOuter.Size = new System.Drawing.Size(239, 43);
            this.pnlHiNoteOuter.TabIndex = 53;
            // 
            // pnlNotesMode
            // 
            this.pnlNotesMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNotesMode.Controls.Add(this.lblNumberMode);
            this.pnlNotesMode.Controls.Add(this.chkNumberMode);
            this.pnlNotesMode.Location = new System.Drawing.Point(581, 155);
            this.pnlNotesMode.Name = "pnlNotesMode";
            this.pnlNotesMode.Size = new System.Drawing.Size(239, 28);
            this.pnlNotesMode.TabIndex = 54;
            // 
            // lblNumberMode
            // 
            this.lblNumberMode.AutoSize = true;
            this.lblNumberMode.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberMode.ForeColor = System.Drawing.Color.DimGray;
            this.lblNumberMode.Location = new System.Drawing.Point(3, 5);
            this.lblNumberMode.Name = "lblNumberMode";
            this.lblNumberMode.Size = new System.Drawing.Size(115, 14);
            this.lblNumberMode.TabIndex = 2;
            this.lblNumberMode.Text = "Number Keys Mode:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(840, 577);
            this.Controls.Add(this.pnlNotesMode);
            this.Controls.Add(this.pnlHiNoteOuter);
            this.Controls.Add(this.btnHighlightHavingValue);
            this.Controls.Add(this.btnToggleNote);
            this.Controls.Add(this.btnSetGuess);
            this.Controls.Add(this.pnlNumbers);
            this.Controls.Add(this.btnSetGiven);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(860, 620);
            this.MinimumSize = new System.Drawing.Size(860, 620);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Woofus Sudoku";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.pnlNumbers.ResumeLayout(false);
            this.pnlHiNoteInner.ResumeLayout(false);
            this.pnlHiNoteOuter.ResumeLayout(false);
            this.pnlNotesMode.ResumeLayout(false);
            this.pnlNotesMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSetGiven;
        private System.Windows.Forms.Panel pnlNumbers;
        private System.Windows.Forms.RadioButton rad3;
        private System.Windows.Forms.RadioButton rad2;
        private System.Windows.Forms.RadioButton rad1;
        private System.Windows.Forms.CheckBox chkNumberMode;
        private System.Windows.Forms.RadioButton rad9;
        private System.Windows.Forms.RadioButton rad8;
        private System.Windows.Forms.RadioButton rad7;
        private System.Windows.Forms.RadioButton rad6;
        private System.Windows.Forms.RadioButton rad5;
        private System.Windows.Forms.RadioButton rad4;
        private System.Windows.Forms.Button btnSetGuess;
        private System.Windows.Forms.Button btnToggleNote;
        private System.Windows.Forms.Button btnHighlightHavingValue;
        private System.Windows.Forms.Panel pnlHiNoteInner;
        private System.Windows.Forms.RadioButton radHiBad;
        private System.Windows.Forms.RadioButton radHiWeak;
        private System.Windows.Forms.RadioButton radHiStrong;
        private System.Windows.Forms.RadioButton radHiInfo;
        private System.Windows.Forms.RadioButton radHiNone;
        private System.Windows.Forms.Panel pnlHiNoteOuter;
        private System.Windows.Forms.Panel pnlNotesMode;
        private System.Windows.Forms.Label lblNumberMode;
    }
}

