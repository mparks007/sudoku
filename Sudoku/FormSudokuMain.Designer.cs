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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnSetGiven = new System.Windows.Forms.Button();
            this.btnSetGuess = new System.Windows.Forms.Button();
            this.cbxPatterns = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnToggleNote = new System.Windows.Forms.Button();
            this.btnColorDialog = new System.Windows.Forms.Button();
            this.cbxFindResults = new System.Windows.Forms.ComboBox();
            this.chkNotesHold = new SudokuCustomControls.OptionButton();
            this.chkHighlightHavingValue = new SudokuCustomControls.OptionButton();
            this.chkHighlightClickMode = new SudokuCustomControls.OptionButton();
            this.pnlCellHighlightPicker = new SudokuCustomControls.ColorButtonsList();
            this.pnlNoteHighlightPicker = new SudokuCustomControls.ColorButtonsList();
            this.pnlFocusNumber = new SudokuCustomControls.NumbersList();
            this.pnlHiNumbersList = new SudokuCustomControls.NumbersList();
            this.chkNumberKeysMode = new SudokuCustomControls.OptionButton();
            this.chkRemoveOldNotes = new SudokuCustomControls.OptionButton();
            this.chkValidationMode = new SudokuCustomControls.OptionButton();
            this.chkColorScheme = new SudokuCustomControls.OptionButton();
            this.SuspendLayout();
            // 
            // btnSetGiven
            // 
            this.btnSetGiven.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSetGiven.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetGiven.Font = new System.Drawing.Font("Yu Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetGiven.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSetGiven.Location = new System.Drawing.Point(581, 255);
            this.btnSetGiven.Name = "btnSetGiven";
            this.btnSetGiven.Size = new System.Drawing.Size(239, 30);
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
            this.btnSetGuess.Font = new System.Drawing.Font("Yu Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetGuess.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSetGuess.Location = new System.Drawing.Point(581, 156);
            this.btnSetGuess.Name = "btnSetGuess";
            this.btnSetGuess.Size = new System.Drawing.Size(239, 30);
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
            this.cbxPatterns.Location = new System.Drawing.Point(636, 303);
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
            this.btnFind.Location = new System.Drawing.Point(581, 304);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(55, 23);
            this.btnFind.TabIndex = 60;
            this.btnFind.TabStop = false;
            this.btnFind.Text = "Find:";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnToggleNote
            // 
            this.btnToggleNote.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnToggleNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToggleNote.Font = new System.Drawing.Font("Yu Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleNote.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnToggleNote.Location = new System.Drawing.Point(581, 224);
            this.btnToggleNote.Name = "btnToggleNote";
            this.btnToggleNote.Size = new System.Drawing.Size(239, 30);
            this.btnToggleNote.TabIndex = 72;
            this.btnToggleNote.TabStop = false;
            this.btnToggleNote.Text = "Toggle Note";
            this.btnToggleNote.UseVisualStyleBackColor = false;
            this.btnToggleNote.Click += new System.EventHandler(this.btnToggleNote_Click);
            // 
            // btnColorDialog
            // 
            this.btnColorDialog.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnColorDialog.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnColorDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorDialog.Font = new System.Drawing.Font("Yu Gothic", 5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorDialog.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnColorDialog.Location = new System.Drawing.Point(820, 539);
            this.btnColorDialog.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorDialog.Name = "btnColorDialog";
            this.btnColorDialog.Size = new System.Drawing.Size(21, 23);
            this.btnColorDialog.TabIndex = 75;
            this.btnColorDialog.TabStop = false;
            this.btnColorDialog.Text = "...";
            this.btnColorDialog.UseVisualStyleBackColor = false;
            this.btnColorDialog.Visible = false;
            this.btnColorDialog.Click += new System.EventHandler(this.btnColorDialog_Click);
            // 
            // cbxFindResults
            // 
            this.cbxFindResults.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cbxFindResults.CausesValidation = false;
            this.cbxFindResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFindResults.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxFindResults.Font = new System.Drawing.Font("Yu Gothic", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFindResults.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cbxFindResults.Location = new System.Drawing.Point(581, 328);
            this.cbxFindResults.Name = "cbxFindResults";
            this.cbxFindResults.Size = new System.Drawing.Size(238, 20);
            this.cbxFindResults.TabIndex = 76;
            this.cbxFindResults.TabStop = false;
            this.cbxFindResults.SelectedIndexChanged += new System.EventHandler(this.cbxFindResults_SelectedIndexChanged);
            // 
            // chkNotesHold
            // 
            this.chkNotesHold.Checked = false;
            this.chkNotesHold.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkNotesHold.Label = "Note Lock:";
            this.chkNotesHold.Location = new System.Drawing.Point(581, 418);
            this.chkNotesHold.Name = "chkNotesHold";
            this.chkNotesHold.Size = new System.Drawing.Size(242, 25);
            this.chkNotesHold.TabIndex = 73;
            this.chkNotesHold.TabStop = false;
            this.chkNotesHold.ThreeState = false;
            // 
            // chkHighlightHavingValue
            // 
            this.chkHighlightHavingValue.Checked = false;
            this.chkHighlightHavingValue.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkHighlightHavingValue.Label = "Highlight Numbers:";
            this.chkHighlightHavingValue.Location = new System.Drawing.Point(581, 442);
            this.chkHighlightHavingValue.Name = "chkHighlightHavingValue";
            this.chkHighlightHavingValue.Size = new System.Drawing.Size(242, 25);
            this.chkHighlightHavingValue.TabIndex = 71;
            this.chkHighlightHavingValue.TabStop = false;
            this.chkHighlightHavingValue.ThreeState = false;
            // 
            // chkHighlightClickMode
            // 
            this.chkHighlightClickMode.Checked = true;
            this.chkHighlightClickMode.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkHighlightClickMode.Label = "Highlight Click Mode:";
            this.chkHighlightClickMode.Location = new System.Drawing.Point(581, 17);
            this.chkHighlightClickMode.Name = "chkHighlightClickMode";
            this.chkHighlightClickMode.Size = new System.Drawing.Size(242, 25);
            this.chkHighlightClickMode.TabIndex = 68;
            this.chkHighlightClickMode.TabStop = false;
            this.chkHighlightClickMode.ThreeState = true;
            // 
            // pnlCellHighlightPicker
            // 
            this.pnlCellHighlightPicker.Location = new System.Drawing.Point(580, 40);
            this.pnlCellHighlightPicker.Name = "pnlCellHighlightPicker";
            this.pnlCellHighlightPicker.Size = new System.Drawing.Size(241, 31);
            this.pnlCellHighlightPicker.TabIndex = 65;
            this.pnlCellHighlightPicker.TabStop = false;
            // 
            // pnlNoteHighlightPicker
            // 
            this.pnlNoteHighlightPicker.Location = new System.Drawing.Point(580, 71);
            this.pnlNoteHighlightPicker.Name = "pnlNoteHighlightPicker";
            this.pnlNoteHighlightPicker.Size = new System.Drawing.Size(241, 32);
            this.pnlNoteHighlightPicker.TabIndex = 64;
            this.pnlNoteHighlightPicker.TabStop = false;
            // 
            // pnlFocusNumber
            // 
            this.pnlFocusNumber.Location = new System.Drawing.Point(581, 186);
            this.pnlFocusNumber.Name = "pnlFocusNumber";
            this.pnlFocusNumber.Size = new System.Drawing.Size(240, 37);
            this.pnlFocusNumber.TabIndex = 63;
            this.pnlFocusNumber.TabStop = false;
            this.pnlFocusNumber.TriggerClickEvent = true;
            // 
            // pnlHiNumbersList
            // 
            this.pnlHiNumbersList.Location = new System.Drawing.Point(581, 101);
            this.pnlHiNumbersList.Name = "pnlHiNumbersList";
            this.pnlHiNumbersList.Size = new System.Drawing.Size(240, 43);
            this.pnlHiNumbersList.TabIndex = 62;
            this.pnlHiNumbersList.TabStop = false;
            this.pnlHiNumbersList.TriggerClickEvent = false;
            // 
            // chkNumberKeysMode
            // 
            this.chkNumberKeysMode.Checked = false;
            this.chkNumberKeysMode.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkNumberKeysMode.Label = "Number Keys Mode:";
            this.chkNumberKeysMode.Location = new System.Drawing.Point(581, 466);
            this.chkNumberKeysMode.Name = "chkNumberKeysMode";
            this.chkNumberKeysMode.Size = new System.Drawing.Size(242, 25);
            this.chkNumberKeysMode.TabIndex = 67;
            this.chkNumberKeysMode.TabStop = false;
            this.chkNumberKeysMode.ThreeState = false;
            // 
            // chkRemoveOldNotes
            // 
            this.chkRemoveOldNotes.Checked = false;
            this.chkRemoveOldNotes.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkRemoveOldNotes.Label = "Clear Old Notes:";
            this.chkRemoveOldNotes.Location = new System.Drawing.Point(581, 490);
            this.chkRemoveOldNotes.Name = "chkRemoveOldNotes";
            this.chkRemoveOldNotes.Size = new System.Drawing.Size(242, 25);
            this.chkRemoveOldNotes.TabIndex = 70;
            this.chkRemoveOldNotes.TabStop = false;
            this.chkRemoveOldNotes.ThreeState = false;
            // 
            // chkValidationMode
            // 
            this.chkValidationMode.Checked = true;
            this.chkValidationMode.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkValidationMode.Label = "Validation Mode:";
            this.chkValidationMode.Location = new System.Drawing.Point(581, 514);
            this.chkValidationMode.Name = "chkValidationMode";
            this.chkValidationMode.Size = new System.Drawing.Size(242, 25);
            this.chkValidationMode.TabIndex = 69;
            this.chkValidationMode.TabStop = false;
            this.chkValidationMode.ThreeState = true;
            // 
            // chkColorScheme
            // 
            this.chkColorScheme.Checked = false;
            this.chkColorScheme.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkColorScheme.Label = "Color Scheme:";
            this.chkColorScheme.Location = new System.Drawing.Point(581, 538);
            this.chkColorScheme.Name = "chkColorScheme";
            this.chkColorScheme.Size = new System.Drawing.Size(242, 25);
            this.chkColorScheme.TabIndex = 74;
            this.chkColorScheme.TabStop = false;
            this.chkColorScheme.ThreeState = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(845, 577);
            this.Controls.Add(this.cbxFindResults);
            this.Controls.Add(this.chkNotesHold);
            this.Controls.Add(this.chkHighlightHavingValue);
            this.Controls.Add(this.btnToggleNote);
            this.Controls.Add(this.chkHighlightClickMode);
            this.Controls.Add(this.pnlCellHighlightPicker);
            this.Controls.Add(this.pnlNoteHighlightPicker);
            this.Controls.Add(this.pnlFocusNumber);
            this.Controls.Add(this.pnlHiNumbersList);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.cbxPatterns);
            this.Controls.Add(this.btnSetGuess);
            this.Controls.Add(this.btnSetGiven);
            this.Controls.Add(this.chkNumberKeysMode);
            this.Controls.Add(this.chkRemoveOldNotes);
            this.Controls.Add(this.chkValidationMode);
            this.Controls.Add(this.chkColorScheme);
            this.Controls.Add(this.btnColorDialog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(865, 620);
            this.MinimumSize = new System.Drawing.Size(865, 620);
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
        private SudokuCustomControls.OptionButton chkRemoveOldNotes;
        private SudokuCustomControls.OptionButton chkHighlightHavingValue;
        private System.Windows.Forms.Button btnToggleNote;
        private SudokuCustomControls.OptionButton chkNotesHold;
        private SudokuCustomControls.OptionButton chkColorScheme;
        private System.Windows.Forms.Button btnColorDialog;
        private System.Windows.Forms.ComboBox cbxFindResults;
    }
}

