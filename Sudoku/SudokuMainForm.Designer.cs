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
            this.pnlSetNumbers = new System.Windows.Forms.Panel();
            this.radSet9 = new System.Windows.Forms.RadioButton();
            this.radSet8 = new System.Windows.Forms.RadioButton();
            this.radSet7 = new System.Windows.Forms.RadioButton();
            this.radSet6 = new System.Windows.Forms.RadioButton();
            this.radSet5 = new System.Windows.Forms.RadioButton();
            this.radSet4 = new System.Windows.Forms.RadioButton();
            this.radSet3 = new System.Windows.Forms.RadioButton();
            this.radSet2 = new System.Windows.Forms.RadioButton();
            this.radSet1 = new System.Windows.Forms.RadioButton();
            this.chkKeysNotesMode = new System.Windows.Forms.CheckBox();
            this.btnSetGuess = new System.Windows.Forms.Button();
            this.btnToggleNote = new System.Windows.Forms.Button();
            this.pnlHiNoteInner = new System.Windows.Forms.Panel();
            this.radHiNoteBad = new System.Windows.Forms.RadioButton();
            this.radHiNoteWeak = new System.Windows.Forms.RadioButton();
            this.radHiNoteStrong = new System.Windows.Forms.RadioButton();
            this.radHiNoteInfo = new System.Windows.Forms.RadioButton();
            this.radHiNoteNone = new System.Windows.Forms.RadioButton();
            this.pnlHiNoteOuter = new System.Windows.Forms.Panel();
            this.pnlKeysMode = new System.Windows.Forms.Panel();
            this.lblKeysMode = new System.Windows.Forms.Label();
            this.pnlHiCellOuter = new System.Windows.Forms.Panel();
            this.pnlHiCellInner = new System.Windows.Forms.Panel();
            this.radHiCellPincer = new System.Windows.Forms.RadioButton();
            this.radHiCellPivot = new System.Windows.Forms.RadioButton();
            this.radHiCellSpecial = new System.Windows.Forms.RadioButton();
            this.radHiCellValue = new System.Windows.Forms.RadioButton();
            this.radHiCellNone = new System.Windows.Forms.RadioButton();
            this.pnlHiNumbers = new System.Windows.Forms.Panel();
            this.radHi9 = new System.Windows.Forms.RadioButton();
            this.radHi8 = new System.Windows.Forms.RadioButton();
            this.radHi7 = new System.Windows.Forms.RadioButton();
            this.radHi6 = new System.Windows.Forms.RadioButton();
            this.radHi5 = new System.Windows.Forms.RadioButton();
            this.radHi4 = new System.Windows.Forms.RadioButton();
            this.radHi3 = new System.Windows.Forms.RadioButton();
            this.radHi2 = new System.Windows.Forms.RadioButton();
            this.radHi1 = new System.Windows.Forms.RadioButton();
            this.pnlHiMode = new System.Windows.Forms.Panel();
            this.lblHiMode = new System.Windows.Forms.Label();
            this.chkHiMode = new System.Windows.Forms.CheckBox();
            this.chkHighlightHavingValue = new System.Windows.Forms.CheckBox();
            this.cbxPatterns = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.chkToggleNote = new System.Windows.Forms.CheckBox();
            this.pnlSetNumbers.SuspendLayout();
            this.pnlHiNoteInner.SuspendLayout();
            this.pnlHiNoteOuter.SuspendLayout();
            this.pnlKeysMode.SuspendLayout();
            this.pnlHiCellOuter.SuspendLayout();
            this.pnlHiCellInner.SuspendLayout();
            this.pnlHiNumbers.SuspendLayout();
            this.pnlHiMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetGiven
            // 
            this.btnSetGiven.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSetGiven.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetGiven.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetGiven.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSetGiven.Location = new System.Drawing.Point(581, 418);
            this.btnSetGiven.Name = "btnSetGiven";
            this.btnSetGiven.Size = new System.Drawing.Size(239, 38);
            this.btnSetGiven.TabIndex = 0;
            this.btnSetGiven.TabStop = false;
            this.btnSetGiven.Text = "Set Given";
            this.btnSetGiven.UseVisualStyleBackColor = false;
            this.btnSetGiven.Click += new System.EventHandler(this.btnSetGiven_Click);
            // 
            // pnlSetNumbers
            // 
            this.pnlSetNumbers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSetNumbers.Controls.Add(this.radSet9);
            this.pnlSetNumbers.Controls.Add(this.radSet8);
            this.pnlSetNumbers.Controls.Add(this.radSet7);
            this.pnlSetNumbers.Controls.Add(this.radSet6);
            this.pnlSetNumbers.Controls.Add(this.radSet5);
            this.pnlSetNumbers.Controls.Add(this.radSet4);
            this.pnlSetNumbers.Controls.Add(this.radSet3);
            this.pnlSetNumbers.Controls.Add(this.radSet2);
            this.pnlSetNumbers.Controls.Add(this.radSet1);
            this.pnlSetNumbers.Location = new System.Drawing.Point(581, 373);
            this.pnlSetNumbers.Name = "pnlSetNumbers";
            this.pnlSetNumbers.Size = new System.Drawing.Size(239, 43);
            this.pnlSetNumbers.TabIndex = 47;
            // 
            // radSet9
            // 
            this.radSet9.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSet9.BackColor = System.Drawing.SystemColors.Highlight;
            this.radSet9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radSet9.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSet9.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radSet9.Location = new System.Drawing.Point(209, 1);
            this.radSet9.Name = "radSet9";
            this.radSet9.Size = new System.Drawing.Size(25, 37);
            this.radSet9.TabIndex = 8;
            this.radSet9.Tag = "9";
            this.radSet9.Text = "9";
            this.radSet9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSet9.UseVisualStyleBackColor = false;
            this.radSet9.Click += new System.EventHandler(this.radSetNumbers_Click);
            // 
            // radSet8
            // 
            this.radSet8.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSet8.BackColor = System.Drawing.SystemColors.Highlight;
            this.radSet8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radSet8.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSet8.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radSet8.Location = new System.Drawing.Point(183, 1);
            this.radSet8.Name = "radSet8";
            this.radSet8.Size = new System.Drawing.Size(25, 37);
            this.radSet8.TabIndex = 7;
            this.radSet8.Tag = "8";
            this.radSet8.Text = "8";
            this.radSet8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSet8.UseVisualStyleBackColor = false;
            this.radSet8.Click += new System.EventHandler(this.radSetNumbers_Click);
            // 
            // radSet7
            // 
            this.radSet7.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSet7.BackColor = System.Drawing.SystemColors.Highlight;
            this.radSet7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radSet7.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSet7.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radSet7.Location = new System.Drawing.Point(157, 1);
            this.radSet7.Name = "radSet7";
            this.radSet7.Size = new System.Drawing.Size(25, 37);
            this.radSet7.TabIndex = 6;
            this.radSet7.Tag = "7";
            this.radSet7.Text = "7";
            this.radSet7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSet7.UseVisualStyleBackColor = false;
            this.radSet7.Click += new System.EventHandler(this.radSetNumbers_Click);
            // 
            // radSet6
            // 
            this.radSet6.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSet6.BackColor = System.Drawing.SystemColors.Highlight;
            this.radSet6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radSet6.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSet6.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radSet6.Location = new System.Drawing.Point(131, 1);
            this.radSet6.Name = "radSet6";
            this.radSet6.Size = new System.Drawing.Size(25, 37);
            this.radSet6.TabIndex = 5;
            this.radSet6.Tag = "6";
            this.radSet6.Text = "6";
            this.radSet6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSet6.UseVisualStyleBackColor = false;
            this.radSet6.Click += new System.EventHandler(this.radSetNumbers_Click);
            // 
            // radSet5
            // 
            this.radSet5.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSet5.BackColor = System.Drawing.SystemColors.Highlight;
            this.radSet5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radSet5.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSet5.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radSet5.Location = new System.Drawing.Point(105, 1);
            this.radSet5.Name = "radSet5";
            this.radSet5.Size = new System.Drawing.Size(25, 37);
            this.radSet5.TabIndex = 4;
            this.radSet5.Tag = "5";
            this.radSet5.Text = "5";
            this.radSet5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSet5.UseVisualStyleBackColor = false;
            this.radSet5.Click += new System.EventHandler(this.radSetNumbers_Click);
            // 
            // radSet4
            // 
            this.radSet4.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSet4.BackColor = System.Drawing.SystemColors.Highlight;
            this.radSet4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radSet4.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSet4.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radSet4.Location = new System.Drawing.Point(79, 1);
            this.radSet4.Name = "radSet4";
            this.radSet4.Size = new System.Drawing.Size(25, 37);
            this.radSet4.TabIndex = 3;
            this.radSet4.Tag = "4";
            this.radSet4.Text = "4";
            this.radSet4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSet4.UseVisualStyleBackColor = false;
            this.radSet4.Click += new System.EventHandler(this.radSetNumbers_Click);
            // 
            // radSet3
            // 
            this.radSet3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSet3.BackColor = System.Drawing.SystemColors.Highlight;
            this.radSet3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radSet3.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSet3.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radSet3.Location = new System.Drawing.Point(53, 1);
            this.radSet3.Name = "radSet3";
            this.radSet3.Size = new System.Drawing.Size(25, 37);
            this.radSet3.TabIndex = 2;
            this.radSet3.Tag = "3";
            this.radSet3.Text = "3";
            this.radSet3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSet3.UseVisualStyleBackColor = false;
            this.radSet3.Click += new System.EventHandler(this.radSetNumbers_Click);
            // 
            // radSet2
            // 
            this.radSet2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSet2.BackColor = System.Drawing.SystemColors.Highlight;
            this.radSet2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radSet2.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSet2.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radSet2.Location = new System.Drawing.Point(27, 1);
            this.radSet2.Name = "radSet2";
            this.radSet2.Size = new System.Drawing.Size(25, 37);
            this.radSet2.TabIndex = 1;
            this.radSet2.Tag = "2";
            this.radSet2.Text = "2";
            this.radSet2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSet2.UseVisualStyleBackColor = false;
            this.radSet2.Click += new System.EventHandler(this.radSetNumbers_Click);
            // 
            // radSet1
            // 
            this.radSet1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSet1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.radSet1.Checked = true;
            this.radSet1.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSet1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radSet1.Location = new System.Drawing.Point(1, 1);
            this.radSet1.Name = "radSet1";
            this.radSet1.Size = new System.Drawing.Size(25, 37);
            this.radSet1.TabIndex = 0;
            this.radSet1.TabStop = true;
            this.radSet1.Tag = "1";
            this.radSet1.Text = "1";
            this.radSet1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSet1.UseVisualStyleBackColor = false;
            this.radSet1.Click += new System.EventHandler(this.radSetNumbers_Click);
            // 
            // chkKeysNotesMode
            // 
            this.chkKeysNotesMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkKeysNotesMode.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkKeysNotesMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkKeysNotesMode.Font = new System.Drawing.Font("Yu Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKeysNotesMode.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chkKeysNotesMode.Location = new System.Drawing.Point(120, 2);
            this.chkKeysNotesMode.Name = "chkKeysNotesMode";
            this.chkKeysNotesMode.Size = new System.Drawing.Size(112, 21);
            this.chkKeysNotesMode.TabIndex = 48;
            this.chkKeysNotesMode.TabStop = false;
            this.chkKeysNotesMode.Text = "Numbers";
            this.chkKeysNotesMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkKeysNotesMode.UseVisualStyleBackColor = false;
            this.chkKeysNotesMode.CheckedChanged += new System.EventHandler(this.chkNumberMode_CheckedChanged);
            // 
            // btnSetGuess
            // 
            this.btnSetGuess.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSetGuess.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetGuess.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetGuess.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSetGuess.Location = new System.Drawing.Point(581, 333);
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
            this.btnToggleNote.Location = new System.Drawing.Point(581, 527);
            this.btnToggleNote.Name = "btnToggleNote";
            this.btnToggleNote.Size = new System.Drawing.Size(239, 38);
            this.btnToggleNote.TabIndex = 50;
            this.btnToggleNote.TabStop = false;
            this.btnToggleNote.Text = "Toggle Note";
            this.btnToggleNote.UseVisualStyleBackColor = false;
            this.btnToggleNote.Click += new System.EventHandler(this.btnToggleNote_Click);
            // 
            // pnlHiNoteInner
            // 
            this.pnlHiNoteInner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHiNoteInner.Controls.Add(this.radHiNoteBad);
            this.pnlHiNoteInner.Controls.Add(this.radHiNoteWeak);
            this.pnlHiNoteInner.Controls.Add(this.radHiNoteStrong);
            this.pnlHiNoteInner.Controls.Add(this.radHiNoteInfo);
            this.pnlHiNoteInner.Controls.Add(this.radHiNoteNone);
            this.pnlHiNoteInner.Location = new System.Drawing.Point(3, 2);
            this.pnlHiNoteInner.Name = "pnlHiNoteInner";
            this.pnlHiNoteInner.Size = new System.Drawing.Size(229, 35);
            this.pnlHiNoteInner.TabIndex = 52;
            // 
            // radHiNoteBad
            // 
            this.radHiNoteBad.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiNoteBad.BackColor = System.Drawing.Color.Red;
            this.radHiNoteBad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiNoteBad.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiNoteBad.ForeColor = System.Drawing.Color.LightGray;
            this.radHiNoteBad.Location = new System.Drawing.Point(176, 1);
            this.radHiNoteBad.Name = "radHiNoteBad";
            this.radHiNoteBad.Size = new System.Drawing.Size(48, 30);
            this.radHiNoteBad.TabIndex = 4;
            this.radHiNoteBad.Tag = "4";
            this.radHiNoteBad.Text = "Bad";
            this.radHiNoteBad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiNoteBad.UseVisualStyleBackColor = false;
            this.radHiNoteBad.Click += new System.EventHandler(this.radHighlightNote_Click);
            // 
            // radHiNoteWeak
            // 
            this.radHiNoteWeak.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiNoteWeak.BackColor = System.Drawing.Color.Yellow;
            this.radHiNoteWeak.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiNoteWeak.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiNoteWeak.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.radHiNoteWeak.Location = new System.Drawing.Point(127, 1);
            this.radHiNoteWeak.Name = "radHiNoteWeak";
            this.radHiNoteWeak.Size = new System.Drawing.Size(48, 30);
            this.radHiNoteWeak.TabIndex = 3;
            this.radHiNoteWeak.Tag = "3";
            this.radHiNoteWeak.Text = "Weak";
            this.radHiNoteWeak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiNoteWeak.UseVisualStyleBackColor = false;
            this.radHiNoteWeak.Click += new System.EventHandler(this.radHighlightNote_Click);
            // 
            // radHiNoteStrong
            // 
            this.radHiNoteStrong.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiNoteStrong.BackColor = System.Drawing.Color.RoyalBlue;
            this.radHiNoteStrong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiNoteStrong.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiNoteStrong.ForeColor = System.Drawing.Color.LightGray;
            this.radHiNoteStrong.Location = new System.Drawing.Point(78, 1);
            this.radHiNoteStrong.Name = "radHiNoteStrong";
            this.radHiNoteStrong.Size = new System.Drawing.Size(48, 30);
            this.radHiNoteStrong.TabIndex = 2;
            this.radHiNoteStrong.Tag = "2";
            this.radHiNoteStrong.Text = "Strong";
            this.radHiNoteStrong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiNoteStrong.UseVisualStyleBackColor = false;
            this.radHiNoteStrong.Click += new System.EventHandler(this.radHighlightNote_Click);
            // 
            // radHiNoteInfo
            // 
            this.radHiNoteInfo.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiNoteInfo.BackColor = System.Drawing.Color.Plum;
            this.radHiNoteInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiNoteInfo.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiNoteInfo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.radHiNoteInfo.Location = new System.Drawing.Point(29, 1);
            this.radHiNoteInfo.Name = "radHiNoteInfo";
            this.radHiNoteInfo.Size = new System.Drawing.Size(48, 30);
            this.radHiNoteInfo.TabIndex = 1;
            this.radHiNoteInfo.Tag = "1";
            this.radHiNoteInfo.Text = "Info";
            this.radHiNoteInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiNoteInfo.UseVisualStyleBackColor = false;
            this.radHiNoteInfo.Click += new System.EventHandler(this.radHighlightNote_Click);
            // 
            // radHiNoteNone
            // 
            this.radHiNoteNone.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiNoteNone.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radHiNoteNone.Checked = true;
            this.radHiNoteNone.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiNoteNone.ForeColor = System.Drawing.Color.DimGray;
            this.radHiNoteNone.Location = new System.Drawing.Point(1, 1);
            this.radHiNoteNone.Name = "radHiNoteNone";
            this.radHiNoteNone.Size = new System.Drawing.Size(26, 29);
            this.radHiNoteNone.TabIndex = 0;
            this.radHiNoteNone.TabStop = true;
            this.radHiNoteNone.Tag = "0";
            this.radHiNoteNone.Text = "X";
            this.radHiNoteNone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiNoteNone.UseVisualStyleBackColor = false;
            this.radHiNoteNone.Click += new System.EventHandler(this.radHighlightNote_Click);
            // 
            // pnlHiNoteOuter
            // 
            this.pnlHiNoteOuter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHiNoteOuter.Controls.Add(this.pnlHiNoteInner);
            this.pnlHiNoteOuter.Location = new System.Drawing.Point(581, 97);
            this.pnlHiNoteOuter.Name = "pnlHiNoteOuter";
            this.pnlHiNoteOuter.Size = new System.Drawing.Size(239, 44);
            this.pnlHiNoteOuter.TabIndex = 53;
            // 
            // pnlKeysMode
            // 
            this.pnlKeysMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlKeysMode.Controls.Add(this.lblKeysMode);
            this.pnlKeysMode.Controls.Add(this.chkKeysNotesMode);
            this.pnlKeysMode.Location = new System.Drawing.Point(581, 223);
            this.pnlKeysMode.Name = "pnlKeysMode";
            this.pnlKeysMode.Size = new System.Drawing.Size(239, 28);
            this.pnlKeysMode.TabIndex = 54;
            // 
            // lblKeysMode
            // 
            this.lblKeysMode.AutoSize = true;
            this.lblKeysMode.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeysMode.ForeColor = System.Drawing.Color.DimGray;
            this.lblKeysMode.Location = new System.Drawing.Point(3, 5);
            this.lblKeysMode.Name = "lblKeysMode";
            this.lblKeysMode.Size = new System.Drawing.Size(115, 14);
            this.lblKeysMode.TabIndex = 2;
            this.lblKeysMode.Text = "Number Keys Mode:";
            // 
            // pnlHiCellOuter
            // 
            this.pnlHiCellOuter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHiCellOuter.Controls.Add(this.pnlHiCellInner);
            this.pnlHiCellOuter.Location = new System.Drawing.Point(581, 52);
            this.pnlHiCellOuter.Name = "pnlHiCellOuter";
            this.pnlHiCellOuter.Size = new System.Drawing.Size(239, 44);
            this.pnlHiCellOuter.TabIndex = 55;
            // 
            // pnlHiCellInner
            // 
            this.pnlHiCellInner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHiCellInner.Controls.Add(this.radHiCellPincer);
            this.pnlHiCellInner.Controls.Add(this.radHiCellPivot);
            this.pnlHiCellInner.Controls.Add(this.radHiCellSpecial);
            this.pnlHiCellInner.Controls.Add(this.radHiCellValue);
            this.pnlHiCellInner.Controls.Add(this.radHiCellNone);
            this.pnlHiCellInner.Location = new System.Drawing.Point(3, 2);
            this.pnlHiCellInner.Name = "pnlHiCellInner";
            this.pnlHiCellInner.Size = new System.Drawing.Size(229, 35);
            this.pnlHiCellInner.TabIndex = 52;
            // 
            // radHiCellPincer
            // 
            this.radHiCellPincer.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiCellPincer.BackColor = System.Drawing.Color.Aquamarine;
            this.radHiCellPincer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiCellPincer.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiCellPincer.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.radHiCellPincer.Location = new System.Drawing.Point(176, 1);
            this.radHiCellPincer.Name = "radHiCellPincer";
            this.radHiCellPincer.Size = new System.Drawing.Size(48, 30);
            this.radHiCellPincer.TabIndex = 4;
            this.radHiCellPincer.Tag = "4";
            this.radHiCellPincer.Text = "Pincer";
            this.radHiCellPincer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiCellPincer.UseVisualStyleBackColor = false;
            this.radHiCellPincer.Click += new System.EventHandler(this.radHighlightCell_Click);
            // 
            // radHiCellPivot
            // 
            this.radHiCellPivot.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiCellPivot.BackColor = System.Drawing.Color.LightSeaGreen;
            this.radHiCellPivot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiCellPivot.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiCellPivot.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.radHiCellPivot.Location = new System.Drawing.Point(127, 1);
            this.radHiCellPivot.Name = "radHiCellPivot";
            this.radHiCellPivot.Size = new System.Drawing.Size(48, 30);
            this.radHiCellPivot.TabIndex = 3;
            this.radHiCellPivot.Tag = "3";
            this.radHiCellPivot.Text = "Pivot";
            this.radHiCellPivot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiCellPivot.UseVisualStyleBackColor = false;
            this.radHiCellPivot.Click += new System.EventHandler(this.radHighlightCell_Click);
            // 
            // radHiCellSpecial
            // 
            this.radHiCellSpecial.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiCellSpecial.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.radHiCellSpecial.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiCellSpecial.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiCellSpecial.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.radHiCellSpecial.Location = new System.Drawing.Point(78, 1);
            this.radHiCellSpecial.Name = "radHiCellSpecial";
            this.radHiCellSpecial.Size = new System.Drawing.Size(48, 30);
            this.radHiCellSpecial.TabIndex = 2;
            this.radHiCellSpecial.Tag = "2";
            this.radHiCellSpecial.Text = "Special";
            this.radHiCellSpecial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiCellSpecial.UseVisualStyleBackColor = false;
            this.radHiCellSpecial.Click += new System.EventHandler(this.radHighlightCell_Click);
            // 
            // radHiCellValue
            // 
            this.radHiCellValue.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiCellValue.BackColor = System.Drawing.Color.Lime;
            this.radHiCellValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHiCellValue.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiCellValue.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.radHiCellValue.Location = new System.Drawing.Point(29, 1);
            this.radHiCellValue.Name = "radHiCellValue";
            this.radHiCellValue.Size = new System.Drawing.Size(48, 30);
            this.radHiCellValue.TabIndex = 1;
            this.radHiCellValue.Tag = "1";
            this.radHiCellValue.Text = "Value";
            this.radHiCellValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiCellValue.UseVisualStyleBackColor = false;
            this.radHiCellValue.Click += new System.EventHandler(this.radHighlightCell_Click);
            // 
            // radHiCellNone
            // 
            this.radHiCellNone.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHiCellNone.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radHiCellNone.Checked = true;
            this.radHiCellNone.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHiCellNone.ForeColor = System.Drawing.Color.DimGray;
            this.radHiCellNone.Location = new System.Drawing.Point(1, 1);
            this.radHiCellNone.Name = "radHiCellNone";
            this.radHiCellNone.Size = new System.Drawing.Size(26, 29);
            this.radHiCellNone.TabIndex = 0;
            this.radHiCellNone.TabStop = true;
            this.radHiCellNone.Tag = "0";
            this.radHiCellNone.Text = "X";
            this.radHiCellNone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHiCellNone.UseVisualStyleBackColor = false;
            this.radHiCellNone.Click += new System.EventHandler(this.radHighlightCell_Click);
            // 
            // pnlHiNumbers
            // 
            this.pnlHiNumbers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHiNumbers.Controls.Add(this.radHi9);
            this.pnlHiNumbers.Controls.Add(this.radHi8);
            this.pnlHiNumbers.Controls.Add(this.radHi7);
            this.pnlHiNumbers.Controls.Add(this.radHi6);
            this.pnlHiNumbers.Controls.Add(this.radHi5);
            this.pnlHiNumbers.Controls.Add(this.radHi4);
            this.pnlHiNumbers.Controls.Add(this.radHi3);
            this.pnlHiNumbers.Controls.Add(this.radHi2);
            this.pnlHiNumbers.Controls.Add(this.radHi1);
            this.pnlHiNumbers.Location = new System.Drawing.Point(581, 143);
            this.pnlHiNumbers.Name = "pnlHiNumbers";
            this.pnlHiNumbers.Size = new System.Drawing.Size(239, 43);
            this.pnlHiNumbers.TabIndex = 56;
            // 
            // radHi9
            // 
            this.radHi9.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHi9.BackColor = System.Drawing.SystemColors.Highlight;
            this.radHi9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHi9.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHi9.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radHi9.Location = new System.Drawing.Point(209, 1);
            this.radHi9.Name = "radHi9";
            this.radHi9.Size = new System.Drawing.Size(25, 37);
            this.radHi9.TabIndex = 8;
            this.radHi9.Tag = "9";
            this.radHi9.Text = "9";
            this.radHi9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHi9.UseVisualStyleBackColor = false;
            this.radHi9.Click += new System.EventHandler(this.radHiNumbers_Click);
            // 
            // radHi8
            // 
            this.radHi8.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHi8.BackColor = System.Drawing.SystemColors.Highlight;
            this.radHi8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHi8.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHi8.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radHi8.Location = new System.Drawing.Point(183, 1);
            this.radHi8.Name = "radHi8";
            this.radHi8.Size = new System.Drawing.Size(25, 37);
            this.radHi8.TabIndex = 7;
            this.radHi8.Tag = "8";
            this.radHi8.Text = "8";
            this.radHi8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHi8.UseVisualStyleBackColor = false;
            this.radHi8.Click += new System.EventHandler(this.radHiNumbers_Click);
            // 
            // radHi7
            // 
            this.radHi7.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHi7.BackColor = System.Drawing.SystemColors.Highlight;
            this.radHi7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHi7.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHi7.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radHi7.Location = new System.Drawing.Point(157, 1);
            this.radHi7.Name = "radHi7";
            this.radHi7.Size = new System.Drawing.Size(25, 37);
            this.radHi7.TabIndex = 6;
            this.radHi7.Tag = "7";
            this.radHi7.Text = "7";
            this.radHi7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHi7.UseVisualStyleBackColor = false;
            this.radHi7.Click += new System.EventHandler(this.radHiNumbers_Click);
            // 
            // radHi6
            // 
            this.radHi6.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHi6.BackColor = System.Drawing.SystemColors.Highlight;
            this.radHi6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHi6.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHi6.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radHi6.Location = new System.Drawing.Point(131, 1);
            this.radHi6.Name = "radHi6";
            this.radHi6.Size = new System.Drawing.Size(25, 37);
            this.radHi6.TabIndex = 5;
            this.radHi6.Tag = "6";
            this.radHi6.Text = "6";
            this.radHi6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHi6.UseVisualStyleBackColor = false;
            this.radHi6.Click += new System.EventHandler(this.radHiNumbers_Click);
            // 
            // radHi5
            // 
            this.radHi5.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHi5.BackColor = System.Drawing.SystemColors.Highlight;
            this.radHi5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHi5.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHi5.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radHi5.Location = new System.Drawing.Point(105, 1);
            this.radHi5.Name = "radHi5";
            this.radHi5.Size = new System.Drawing.Size(25, 37);
            this.radHi5.TabIndex = 4;
            this.radHi5.Tag = "5";
            this.radHi5.Text = "5";
            this.radHi5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHi5.UseVisualStyleBackColor = false;
            this.radHi5.Click += new System.EventHandler(this.radHiNumbers_Click);
            // 
            // radHi4
            // 
            this.radHi4.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHi4.BackColor = System.Drawing.SystemColors.Highlight;
            this.radHi4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHi4.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHi4.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radHi4.Location = new System.Drawing.Point(79, 1);
            this.radHi4.Name = "radHi4";
            this.radHi4.Size = new System.Drawing.Size(25, 37);
            this.radHi4.TabIndex = 3;
            this.radHi4.Tag = "4";
            this.radHi4.Text = "4";
            this.radHi4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHi4.UseVisualStyleBackColor = false;
            this.radHi4.Click += new System.EventHandler(this.radHiNumbers_Click);
            // 
            // radHi3
            // 
            this.radHi3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHi3.BackColor = System.Drawing.SystemColors.Highlight;
            this.radHi3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHi3.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHi3.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radHi3.Location = new System.Drawing.Point(53, 1);
            this.radHi3.Name = "radHi3";
            this.radHi3.Size = new System.Drawing.Size(25, 37);
            this.radHi3.TabIndex = 2;
            this.radHi3.Tag = "3";
            this.radHi3.Text = "3";
            this.radHi3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHi3.UseVisualStyleBackColor = false;
            this.radHi3.Click += new System.EventHandler(this.radHiNumbers_Click);
            // 
            // radHi2
            // 
            this.radHi2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHi2.BackColor = System.Drawing.SystemColors.Highlight;
            this.radHi2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHi2.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHi2.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.radHi2.Location = new System.Drawing.Point(27, 1);
            this.radHi2.Name = "radHi2";
            this.radHi2.Size = new System.Drawing.Size(25, 37);
            this.radHi2.TabIndex = 1;
            this.radHi2.Tag = "2";
            this.radHi2.Text = "2";
            this.radHi2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHi2.UseVisualStyleBackColor = false;
            this.radHi2.Click += new System.EventHandler(this.radHiNumbers_Click);
            // 
            // radHi1
            // 
            this.radHi1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHi1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.radHi1.Checked = true;
            this.radHi1.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHi1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radHi1.Location = new System.Drawing.Point(1, 1);
            this.radHi1.Name = "radHi1";
            this.radHi1.Size = new System.Drawing.Size(25, 37);
            this.radHi1.TabIndex = 0;
            this.radHi1.TabStop = true;
            this.radHi1.Tag = "1";
            this.radHi1.Text = "1";
            this.radHi1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHi1.UseVisualStyleBackColor = false;
            this.radHi1.Click += new System.EventHandler(this.radHiNumbers_Click);
            // 
            // pnlHiMode
            // 
            this.pnlHiMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHiMode.Controls.Add(this.lblHiMode);
            this.pnlHiMode.Controls.Add(this.chkHiMode);
            this.pnlHiMode.Location = new System.Drawing.Point(581, 22);
            this.pnlHiMode.Name = "pnlHiMode";
            this.pnlHiMode.Size = new System.Drawing.Size(239, 28);
            this.pnlHiMode.TabIndex = 57;
            // 
            // lblHiMode
            // 
            this.lblHiMode.AutoSize = true;
            this.lblHiMode.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiMode.ForeColor = System.Drawing.Color.DimGray;
            this.lblHiMode.Location = new System.Drawing.Point(-1, 5);
            this.lblHiMode.Name = "lblHiMode";
            this.lblHiMode.Size = new System.Drawing.Size(120, 14);
            this.lblHiMode.TabIndex = 2;
            this.lblHiMode.Tag = "0";
            this.lblHiMode.Text = "Highlight Click Mode:";
            // 
            // chkHiMode
            // 
            this.chkHiMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHiMode.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkHiMode.Checked = true;
            this.chkHiMode.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkHiMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkHiMode.Font = new System.Drawing.Font("Yu Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHiMode.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chkHiMode.Location = new System.Drawing.Point(120, 2);
            this.chkHiMode.Name = "chkHiMode";
            this.chkHiMode.Size = new System.Drawing.Size(112, 21);
            this.chkHiMode.TabIndex = 48;
            this.chkHiMode.TabStop = false;
            this.chkHiMode.Text = "Manual";
            this.chkHiMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkHiMode.ThreeState = true;
            this.chkHiMode.UseVisualStyleBackColor = false;
            this.chkHiMode.CheckStateChanged += new System.EventHandler(this.chkHiMode_CheckStateChanged);
            // 
            // chkHighlightHavingValue
            // 
            this.chkHighlightHavingValue.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHighlightHavingValue.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkHighlightHavingValue.Checked = true;
            this.chkHighlightHavingValue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHighlightHavingValue.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHighlightHavingValue.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chkHighlightHavingValue.Location = new System.Drawing.Point(581, 293);
            this.chkHighlightHavingValue.Name = "chkHighlightHavingValue";
            this.chkHighlightHavingValue.Size = new System.Drawing.Size(239, 38);
            this.chkHighlightHavingValue.TabIndex = 58;
            this.chkHighlightHavingValue.TabStop = false;
            this.chkHighlightHavingValue.Text = "Highlight Having Value";
            this.chkHighlightHavingValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkHighlightHavingValue.UseVisualStyleBackColor = false;
            this.chkHighlightHavingValue.CheckedChanged += new System.EventHandler(this.chkHighlightHavingValue_CheckedChanged);
            // 
            // cbxPatterns
            // 
            this.cbxPatterns.BackColor = System.Drawing.SystemColors.Highlight;
            this.cbxPatterns.CausesValidation = false;
            this.cbxPatterns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPatterns.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxPatterns.Font = new System.Drawing.Font("Yu Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPatterns.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cbxPatterns.Location = new System.Drawing.Point(641, 492);
            this.cbxPatterns.Name = "cbxPatterns";
            this.cbxPatterns.Size = new System.Drawing.Size(179, 25);
            this.cbxPatterns.TabIndex = 59;
            this.cbxPatterns.TabStop = false;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Font = new System.Drawing.Font("Yu Gothic", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFind.Location = new System.Drawing.Point(582, 493);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(59, 23);
            this.btnFind.TabIndex = 60;
            this.btnFind.TabStop = false;
            this.btnFind.Text = "Find:";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // chkToggleNote
            // 
            this.chkToggleNote.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkToggleNote.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkToggleNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkToggleNote.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkToggleNote.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chkToggleNote.Location = new System.Drawing.Point(581, 254);
            this.chkToggleNote.Name = "chkToggleNote";
            this.chkToggleNote.Size = new System.Drawing.Size(239, 38);
            this.chkToggleNote.TabIndex = 61;
            this.chkToggleNote.TabStop = false;
            this.chkToggleNote.Text = "Toggle Note";
            this.chkToggleNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkToggleNote.UseVisualStyleBackColor = false;
            this.chkToggleNote.CheckedChanged += new System.EventHandler(this.chkToggleNote_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(840, 577);
            this.Controls.Add(this.chkToggleNote);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.cbxPatterns);
            this.Controls.Add(this.chkHighlightHavingValue);
            this.Controls.Add(this.pnlHiMode);
            this.Controls.Add(this.pnlHiNumbers);
            this.Controls.Add(this.pnlHiCellOuter);
            this.Controls.Add(this.pnlKeysMode);
            this.Controls.Add(this.pnlHiNoteOuter);
            this.Controls.Add(this.btnToggleNote);
            this.Controls.Add(this.btnSetGuess);
            this.Controls.Add(this.pnlSetNumbers);
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
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            this.pnlSetNumbers.ResumeLayout(false);
            this.pnlHiNoteInner.ResumeLayout(false);
            this.pnlHiNoteOuter.ResumeLayout(false);
            this.pnlKeysMode.ResumeLayout(false);
            this.pnlKeysMode.PerformLayout();
            this.pnlHiCellOuter.ResumeLayout(false);
            this.pnlHiCellInner.ResumeLayout(false);
            this.pnlHiNumbers.ResumeLayout(false);
            this.pnlHiMode.ResumeLayout(false);
            this.pnlHiMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSetGiven;
        private System.Windows.Forms.Panel pnlSetNumbers;
        private System.Windows.Forms.RadioButton radSet3;
        private System.Windows.Forms.RadioButton radSet2;
        private System.Windows.Forms.RadioButton radSet1;
        private System.Windows.Forms.CheckBox chkKeysNotesMode;
        private System.Windows.Forms.RadioButton radSet9;
        private System.Windows.Forms.RadioButton radSet8;
        private System.Windows.Forms.RadioButton radSet7;
        private System.Windows.Forms.RadioButton radSet6;
        private System.Windows.Forms.RadioButton radSet5;
        private System.Windows.Forms.RadioButton radSet4;
        private System.Windows.Forms.Button btnSetGuess;
        private System.Windows.Forms.Button btnToggleNote;
        private System.Windows.Forms.Panel pnlHiNoteInner;
        private System.Windows.Forms.RadioButton radHiNoteBad;
        private System.Windows.Forms.RadioButton radHiNoteWeak;
        private System.Windows.Forms.RadioButton radHiNoteStrong;
        private System.Windows.Forms.RadioButton radHiNoteInfo;
        private System.Windows.Forms.RadioButton radHiNoteNone;
        private System.Windows.Forms.Panel pnlHiNoteOuter;
        private System.Windows.Forms.Panel pnlKeysMode;
        private System.Windows.Forms.Label lblKeysMode;
        private System.Windows.Forms.Panel pnlHiCellOuter;
        private System.Windows.Forms.Panel pnlHiCellInner;
        private System.Windows.Forms.RadioButton radHiCellPincer;
        private System.Windows.Forms.RadioButton radHiCellPivot;
        private System.Windows.Forms.RadioButton radHiCellSpecial;
        private System.Windows.Forms.RadioButton radHiCellValue;
        private System.Windows.Forms.RadioButton radHiCellNone;
        private System.Windows.Forms.Panel pnlHiNumbers;
        private System.Windows.Forms.RadioButton radHi9;
        private System.Windows.Forms.RadioButton radHi8;
        private System.Windows.Forms.RadioButton radHi7;
        private System.Windows.Forms.RadioButton radHi6;
        private System.Windows.Forms.RadioButton radHi5;
        private System.Windows.Forms.RadioButton radHi4;
        private System.Windows.Forms.RadioButton radHi3;
        private System.Windows.Forms.RadioButton radHi2;
        private System.Windows.Forms.RadioButton radHi1;
        private System.Windows.Forms.Panel pnlHiMode;
        private System.Windows.Forms.Label lblHiMode;
        private System.Windows.Forms.CheckBox chkHiMode;
        private System.Windows.Forms.CheckBox chkHighlightHavingValue;
        private System.Windows.Forms.ComboBox cbxPatterns;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.CheckBox chkToggleNote;
    }
}

