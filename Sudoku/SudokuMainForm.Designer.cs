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
            this.chkHighlightHavingValue = new System.Windows.Forms.CheckBox();
            this.cbxPatterns = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.chkToggleNote = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkHighlightClickMode = new SudokuCustomControls.OptionButton();
            this.chkNumberKeysMode = new SudokuCustomControls.OptionButton();
            this.pnlCellHighlightPicker = new SudokuCustomControls.ColorButtonsList();
            this.pnlNoteHighlightPicker = new SudokuCustomControls.ColorButtonsList();
            this.pnlFocusNumber = new SudokuCustomControls.NumbersList();
            this.pnlHiNumbersList = new SudokuCustomControls.NumbersList();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetGiven
            // 
            this.btnSetGiven.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSetGiven.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetGiven.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetGiven.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSetGiven.Location = new System.Drawing.Point(581, 391);
            this.btnSetGiven.Name = "btnSetGiven";
            this.btnSetGiven.Size = new System.Drawing.Size(239, 38);
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
            this.btnSetGuess.Location = new System.Drawing.Point(581, 307);
            this.btnSetGuess.Name = "btnSetGuess";
            this.btnSetGuess.Size = new System.Drawing.Size(239, 38);
            this.btnSetGuess.TabIndex = 49;
            this.btnSetGuess.TabStop = false;
            this.btnSetGuess.Text = "Set Guess";
            this.btnSetGuess.UseVisualStyleBackColor = false;
            this.btnSetGuess.Click += new System.EventHandler(this.btnSetGuess_Click);
            // 
            // chkHighlightHavingValue
            // 
            this.chkHighlightHavingValue.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHighlightHavingValue.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkHighlightHavingValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkHighlightHavingValue.Font = new System.Drawing.Font("Yu Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHighlightHavingValue.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chkHighlightHavingValue.Location = new System.Drawing.Point(581, 268);
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
            this.cbxPatterns.Location = new System.Drawing.Point(641, 449);
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
            this.btnFind.Location = new System.Drawing.Point(582, 450);
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
            this.chkToggleNote.Location = new System.Drawing.Point(581, 229);
            this.chkToggleNote.Name = "chkToggleNote";
            this.chkToggleNote.Size = new System.Drawing.Size(239, 38);
            this.chkToggleNote.TabIndex = 61;
            this.chkToggleNote.TabStop = false;
            this.chkToggleNote.Text = "Toggle Note";
            this.chkToggleNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkToggleNote.UseVisualStyleBackColor = false;
            this.chkToggleNote.CheckedChanged += new System.EventHandler(this.chkToggleNote_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Location = new System.Drawing.Point(582, 537);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 28);
            this.panel1.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(33, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Invalids Mode:";
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox1.Font = new System.Drawing.Font("Yu Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.checkBox1.Location = new System.Drawing.Point(120, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 21);
            this.checkBox1.TabIndex = 48;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Don\'t Mark";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = false;
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
            this.chkNumberKeysMode.Location = new System.Drawing.Point(581, 199);
            this.chkNumberKeysMode.Name = "chkNumberKeysMode";
            this.chkNumberKeysMode.Size = new System.Drawing.Size(242, 28);
            this.chkNumberKeysMode.TabIndex = 67;
            this.chkNumberKeysMode.TabStop = false;
            this.chkNumberKeysMode.ThreeState = false;
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
            this.pnlFocusNumber.Location = new System.Drawing.Point(581, 346);
            this.pnlFocusNumber.Name = "pnlFocusNumber";
            this.pnlFocusNumber.Size = new System.Drawing.Size(240, 43);
            this.pnlFocusNumber.TabIndex = 63;
            this.pnlFocusNumber.TabStop = false;
            this.pnlFocusNumber.TriggerClickEvent = true;
            // 
            // pnlHiNumbersList
            // 
            this.pnlHiNumbersList.Location = new System.Drawing.Point(581, 137);
            this.pnlHiNumbersList.Name = "pnlHiNumbersList";
            this.pnlHiNumbersList.Size = new System.Drawing.Size(240, 43);
            this.pnlHiNumbersList.TabIndex = 62;
            this.pnlHiNumbersList.TabStop = false;
            this.pnlHiNumbersList.TriggerClickEvent = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(840, 577);
            this.Controls.Add(this.chkHighlightClickMode);
            this.Controls.Add(this.chkNumberKeysMode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlCellHighlightPicker);
            this.Controls.Add(this.pnlNoteHighlightPicker);
            this.Controls.Add(this.pnlFocusNumber);
            this.Controls.Add(this.pnlHiNumbersList);
            this.Controls.Add(this.chkToggleNote);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.cbxPatterns);
            this.Controls.Add(this.chkHighlightHavingValue);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSetGiven;
        private System.Windows.Forms.Button btnSetGuess;
        private System.Windows.Forms.CheckBox chkHighlightHavingValue;
        private System.Windows.Forms.ComboBox cbxPatterns;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.CheckBox chkToggleNote;
        private SudokuCustomControls.NumbersList pnlHiNumbersList;
        private SudokuCustomControls.NumbersList pnlFocusNumber;
        private SudokuCustomControls.ColorButtonsList pnlNoteHighlightPicker;
        private SudokuCustomControls.ColorButtonsList pnlCellHighlightPicker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private SudokuCustomControls.OptionButton chkNumberKeysMode;
        private SudokuCustomControls.OptionButton chkHighlightClickMode;
    }
}

