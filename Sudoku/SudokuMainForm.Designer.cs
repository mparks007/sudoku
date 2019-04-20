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
            this.chkKeysNotesMode = new System.Windows.Forms.CheckBox();
            this.btnSetGuess = new System.Windows.Forms.Button();
            this.pnlKeysMode = new System.Windows.Forms.Panel();
            this.lblKeysMode = new System.Windows.Forms.Label();
            this.pnlHiMode = new System.Windows.Forms.Panel();
            this.lblHiMode = new System.Windows.Forms.Label();
            this.chkHiMode = new System.Windows.Forms.CheckBox();
            this.chkHighlightHavingValue = new System.Windows.Forms.CheckBox();
            this.cbxPatterns = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.chkToggleNote = new System.Windows.Forms.CheckBox();
            this.pnlCellHighlightPicker = new SudokuCustomControls.ColorButtonsList();
            this.pnlNoteHighlightPicker = new SudokuCustomControls.ColorButtonsList();
            this.pnlFocusNumber = new SudokuCustomControls.NumbersList();
            this.pnlHiNumbers = new SudokuCustomControls.NumbersList();
            this.pnlKeysMode.SuspendLayout();
            this.pnlHiMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetGiven
            // 
            this.btnSetGiven.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSetGiven.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetGiven.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetGiven.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSetGiven.Location = new System.Drawing.Point(581, 416);
            this.btnSetGiven.Name = "btnSetGiven";
            this.btnSetGiven.Size = new System.Drawing.Size(239, 38);
            this.btnSetGiven.TabIndex = 0;
            this.btnSetGiven.TabStop = false;
            this.btnSetGiven.Text = "Set Given";
            this.btnSetGiven.UseVisualStyleBackColor = false;
            this.btnSetGiven.Click += new System.EventHandler(this.btnSetGiven_Click);
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
            this.btnSetGuess.Location = new System.Drawing.Point(581, 332);
            this.btnSetGuess.Name = "btnSetGuess";
            this.btnSetGuess.Size = new System.Drawing.Size(239, 38);
            this.btnSetGuess.TabIndex = 49;
            this.btnSetGuess.TabStop = false;
            this.btnSetGuess.Text = "Set Guess";
            this.btnSetGuess.UseVisualStyleBackColor = false;
            this.btnSetGuess.Click += new System.EventHandler(this.btnSetGuess_Click);
            // 
            // pnlKeysMode
            // 
            this.pnlKeysMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlKeysMode.Controls.Add(this.lblKeysMode);
            this.pnlKeysMode.Controls.Add(this.chkKeysNotesMode);
            this.pnlKeysMode.Location = new System.Drawing.Point(581, 224);
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
            this.chkHighlightHavingValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
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
            // pnlCellHighlightPicker
            // 
            this.pnlCellHighlightPicker.Location = new System.Drawing.Point(581, 51);
            this.pnlCellHighlightPicker.Name = "pnlCellHighlightPicker";
            this.pnlCellHighlightPicker.Size = new System.Drawing.Size(239, 44);
            this.pnlCellHighlightPicker.TabIndex = 65;
            this.pnlCellHighlightPicker.TabStop = false;
            // 
            // pnlNoteHighlightPicker
            // 
            this.pnlNoteHighlightPicker.Location = new System.Drawing.Point(581, 94);
            this.pnlNoteHighlightPicker.Name = "pnlNoteHighlightPicker";
            this.pnlNoteHighlightPicker.Size = new System.Drawing.Size(239, 44);
            this.pnlNoteHighlightPicker.TabIndex = 64;
            this.pnlNoteHighlightPicker.TabStop = false;
            // 
            // pnlFocusNumber
            // 
            this.pnlFocusNumber.Location = new System.Drawing.Point(581, 371);
            this.pnlFocusNumber.Name = "pnlFocusNumber";
            this.pnlFocusNumber.Size = new System.Drawing.Size(240, 43);
            this.pnlFocusNumber.TabIndex = 63;
            this.pnlFocusNumber.TabStop = false;
            this.pnlFocusNumber.TriggerClickEvent = true;
            // 
            // pnlHiNumbers
            // 
            this.pnlHiNumbers.Location = new System.Drawing.Point(581, 137);
            this.pnlHiNumbers.Name = "pnlHiNumbers";
            this.pnlHiNumbers.Size = new System.Drawing.Size(240, 43);
            this.pnlHiNumbers.TabIndex = 62;
            this.pnlHiNumbers.TabStop = false;
            this.pnlHiNumbers.TriggerClickEvent = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(840, 577);
            this.Controls.Add(this.pnlCellHighlightPicker);
            this.Controls.Add(this.pnlNoteHighlightPicker);
            this.Controls.Add(this.pnlFocusNumber);
            this.Controls.Add(this.pnlHiNumbers);
            this.Controls.Add(this.chkToggleNote);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.cbxPatterns);
            this.Controls.Add(this.chkHighlightHavingValue);
            this.Controls.Add(this.pnlHiMode);
            this.Controls.Add(this.pnlKeysMode);
            this.Controls.Add(this.btnSetGuess);
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
            this.pnlKeysMode.ResumeLayout(false);
            this.pnlKeysMode.PerformLayout();
            this.pnlHiMode.ResumeLayout(false);
            this.pnlHiMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSetGiven;
        private System.Windows.Forms.CheckBox chkKeysNotesMode;
        private System.Windows.Forms.Button btnSetGuess;
        private System.Windows.Forms.Panel pnlKeysMode;
        private System.Windows.Forms.Label lblKeysMode;
        private System.Windows.Forms.Panel pnlHiMode;
        private System.Windows.Forms.Label lblHiMode;
        private System.Windows.Forms.CheckBox chkHiMode;
        private System.Windows.Forms.CheckBox chkHighlightHavingValue;
        private System.Windows.Forms.ComboBox cbxPatterns;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.CheckBox chkToggleNote;
        private SudokuCustomControls.NumbersList pnlHiNumbers;
        private SudokuCustomControls.NumbersList pnlFocusNumber;
        private SudokuCustomControls.ColorButtonsList pnlNoteHighlightPicker;
        private SudokuCustomControls.ColorButtonsList pnlCellHighlightPicker;
    }
}

