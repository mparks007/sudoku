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
            this.btnSetGuess = new System.Windows.Forms.Button();
            this.cbxPatterns = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.chkClearOldNotes = new SudokuCustomControls.OptionButton();
            this.chkValidationMode = new SudokuCustomControls.OptionButton();
            this.chkHighlightClickMode = new SudokuCustomControls.OptionButton();
            this.chkNumberKeysMode = new SudokuCustomControls.OptionButton();
            this.pnlCellHighlightPicker = new SudokuCustomControls.ColorButtonsList();
            this.pnlNoteHighlightPicker = new SudokuCustomControls.ColorButtonsList();
            this.pnlFocusNumber = new SudokuCustomControls.NumbersList();
            this.pnlHiNumbersList = new SudokuCustomControls.NumbersList();
            this.chkHighlightHavingValue = new SudokuCustomControls.OptionButton();
            this.btnToggleNote = new System.Windows.Forms.Button();
            this.chkNotesHold = new SudokuCustomControls.OptionButton();
            this.SuspendLayout();
            // 
            // btnSetGiven
            // 
            this.btnSetGiven.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSetGiven.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetGiven.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetGiven.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSetGiven.Location = new System.Drawing.Point(581, 277);
            this.btnSetGiven.Name = "btnSetGiven";
            this.btnSetGiven.Size = new System.Drawing.Size(239, 33);
            this.btnSetGiven.TabIndex = 0;
            this.btnSetGiven.TabStop = false;
            this.btnSetGiven.Text = "Set Given";
            this.btnSetGiven.UseVisualStyleBackColor = false;
            this.btnSetGiven.Click += new System.EventHandler(this.btnSetGiven_Click);
            // 
            // btnSetGuess
            // 
            this.btnSetGuess.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSetGuess.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetGuess.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetGuess.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSetGuess.Location = new System.Drawing.Point(581, 169);
            this.btnSetGuess.Name = "btnSetGuess";
            this.btnSetGuess.Size = new System.Drawing.Size(239, 33);
            this.btnSetGuess.TabIndex = 49;
            this.btnSetGuess.TabStop = false;
            this.btnSetGuess.Text = "Set Guess";
            this.btnSetGuess.UseVisualStyleBackColor = false;
            this.btnSetGuess.Click += new System.EventHandler(this.btnSetGuess_Click);
            // 
            // cbxPatterns
            // 
            this.cbxPatterns.BackColor = System.Drawing.SystemColors.Highlight;
            this.cbxPatterns.CausesValidation = false;
            this.cbxPatterns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPatterns.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxPatterns.Font = new System.Drawing.Font("Yu Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPatterns.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cbxPatterns.Location = new System.Drawing.Point(636, 327);
            this.cbxPatterns.Name = "cbxPatterns";
            this.cbxPatterns.Size = new System.Drawing.Size(183, 25);
            this.cbxPatterns.TabIndex = 59;
            this.cbxPatterns.TabStop = false;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Font = new System.Drawing.Font("Yu Gothic", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFind.Location = new System.Drawing.Point(581, 328);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(55, 23);
            this.btnFind.TabIndex = 60;
            this.btnFind.TabStop = false;
            this.btnFind.Text = "Find:";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // chkClearOldNotes
            // 
            this.chkClearOldNotes.Checked = false;
            this.chkClearOldNotes.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkClearOldNotes.Label = "Clear Old Notes:";
            this.chkClearOldNotes.Location = new System.Drawing.Point(581, 508);
            this.chkClearOldNotes.Name = "chkClearOldNotes";
            this.chkClearOldNotes.Size = new System.Drawing.Size(242, 28);
            this.chkClearOldNotes.TabIndex = 70;
            this.chkClearOldNotes.TabStop = false;
            this.chkClearOldNotes.ThreeState = false;
            // 
            // chkValidationMode
            // 
            this.chkValidationMode.Checked = true;
            this.chkValidationMode.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkValidationMode.Label = "Validation Mode:";
            this.chkValidationMode.Location = new System.Drawing.Point(581, 535);
            this.chkValidationMode.Name = "chkValidationMode";
            this.chkValidationMode.Size = new System.Drawing.Size(242, 28);
            this.chkValidationMode.TabIndex = 69;
            this.chkValidationMode.TabStop = false;
            this.chkValidationMode.ThreeState = true;
            // 
            // chkHighlightClickMode
            // 
            this.chkHighlightClickMode.Checked = true;
            this.chkHighlightClickMode.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkHighlightClickMode.Label = "Highlight Click Mode:";
            this.chkHighlightClickMode.Location = new System.Drawing.Point(581, 22);
            this.chkHighlightClickMode.Name = "chkHighlightClickMode";
            this.chkHighlightClickMode.Size = new System.Drawing.Size(242, 28);
            this.chkHighlightClickMode.TabIndex = 68;
            this.chkHighlightClickMode.TabStop = false;
            this.chkHighlightClickMode.ThreeState = true;
            // 
            // chkNumberKeysMode
            // 
            this.chkNumberKeysMode.Checked = false;
            this.chkNumberKeysMode.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkNumberKeysMode.Label = "Number Keys Mode:";
            this.chkNumberKeysMode.Location = new System.Drawing.Point(581, 481);
            this.chkNumberKeysMode.Name = "chkNumberKeysMode";
            this.chkNumberKeysMode.Size = new System.Drawing.Size(242, 28);
            this.chkNumberKeysMode.TabIndex = 67;
            this.chkNumberKeysMode.TabStop = false;
            this.chkNumberKeysMode.ThreeState = false;
            // 
            // pnlCellHighlightPicker
            // 
            this.pnlCellHighlightPicker.Location = new System.Drawing.Point(580, 48);
            this.pnlCellHighlightPicker.Name = "pnlCellHighlightPicker";
            this.pnlCellHighlightPicker.Size = new System.Drawing.Size(240, 31);
            this.pnlCellHighlightPicker.TabIndex = 65;
            this.pnlCellHighlightPicker.TabStop = false;
            // 
            // pnlNoteHighlightPicker
            // 
            this.pnlNoteHighlightPicker.Location = new System.Drawing.Point(580, 79);
            this.pnlNoteHighlightPicker.Name = "pnlNoteHighlightPicker";
            this.pnlNoteHighlightPicker.Size = new System.Drawing.Size(240, 32);
            this.pnlNoteHighlightPicker.TabIndex = 64;
            this.pnlNoteHighlightPicker.TabStop = false;
            // 
            // pnlFocusNumber
            // 
            this.pnlFocusNumber.Location = new System.Drawing.Point(581, 203);
            this.pnlFocusNumber.Name = "pnlFocusNumber";
            this.pnlFocusNumber.Size = new System.Drawing.Size(240, 37);
            this.pnlFocusNumber.TabIndex = 63;
            this.pnlFocusNumber.TabStop = false;
            this.pnlFocusNumber.TriggerClickEvent = true;
            // 
            // pnlHiNumbersList
            // 
            this.pnlHiNumbersList.Location = new System.Drawing.Point(581, 109);
            this.pnlHiNumbersList.Name = "pnlHiNumbersList";
            this.pnlHiNumbersList.Size = new System.Drawing.Size(240, 43);
            this.pnlHiNumbersList.TabIndex = 62;
            this.pnlHiNumbersList.TabStop = false;
            this.pnlHiNumbersList.TriggerClickEvent = false;
            // 
            // chkHighlightHavingValue
            // 
            this.chkHighlightHavingValue.Checked = false;
            this.chkHighlightHavingValue.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkHighlightHavingValue.Label = "Highlight Numbers:";
            this.chkHighlightHavingValue.Location = new System.Drawing.Point(581, 454);
            this.chkHighlightHavingValue.Name = "chkHighlightHavingValue";
            this.chkHighlightHavingValue.Size = new System.Drawing.Size(242, 28);
            this.chkHighlightHavingValue.TabIndex = 71;
            this.chkHighlightHavingValue.TabStop = false;
            this.chkHighlightHavingValue.ThreeState = false;
            // 
            // btnToggleNote
            // 
            this.btnToggleNote.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnToggleNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToggleNote.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleNote.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnToggleNote.Location = new System.Drawing.Point(581, 242);
            this.btnToggleNote.Name = "btnToggleNote";
            this.btnToggleNote.Size = new System.Drawing.Size(239, 33);
            this.btnToggleNote.TabIndex = 72;
            this.btnToggleNote.TabStop = false;
            this.btnToggleNote.Text = "Toggle Note";
            this.btnToggleNote.UseVisualStyleBackColor = false;
            this.btnToggleNote.Click += new System.EventHandler(this.btnToggleNote_Click);
            // 
            // chkNotesHold
            // 
            this.chkNotesHold.Checked = false;
            this.chkNotesHold.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkNotesHold.Label = "Note Lock:";
            this.chkNotesHold.Location = new System.Drawing.Point(581, 427);
            this.chkNotesHold.Name = "chkNotesHold";
            this.chkNotesHold.Size = new System.Drawing.Size(242, 28);
            this.chkNotesHold.TabIndex = 73;
            this.chkNotesHold.TabStop = false;
            this.chkNotesHold.ThreeState = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(840, 577);
            this.Controls.Add(this.chkNotesHold);
            this.Controls.Add(this.btnToggleNote);
            this.Controls.Add(this.chkHighlightHavingValue);
            this.Controls.Add(this.chkClearOldNotes);
            this.Controls.Add(this.chkValidationMode);
            this.Controls.Add(this.chkHighlightClickMode);
            this.Controls.Add(this.chkNumberKeysMode);
            this.Controls.Add(this.pnlCellHighlightPicker);
            this.Controls.Add(this.pnlNoteHighlightPicker);
            this.Controls.Add(this.pnlFocusNumber);
            this.Controls.Add(this.pnlHiNumbersList);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.cbxPatterns);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSetGiven;
        private System.Windows.Forms.Button btnSetGuess;
        private System.Windows.Forms.ComboBox cbxPatterns;
        private System.Windows.Forms.Button btnFind;
        private SudokuCustomControls.NumbersList pnlHiNumbersList;
        private SudokuCustomControls.NumbersList pnlFocusNumber;
        private SudokuCustomControls.ColorButtonsList pnlNoteHighlightPicker;
        private SudokuCustomControls.ColorButtonsList pnlCellHighlightPicker;
        private SudokuCustomControls.OptionButton chkNumberKeysMode;
        private SudokuCustomControls.OptionButton chkHighlightClickMode;
        private SudokuCustomControls.OptionButton chkValidationMode;
        private SudokuCustomControls.OptionButton chkClearOldNotes;
        private SudokuCustomControls.OptionButton chkHighlightHavingValue;
        private System.Windows.Forms.Button btnToggleNote;
        private SudokuCustomControls.OptionButton chkNotesHold;
    }
}

