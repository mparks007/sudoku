namespace Sudoku
{
    partial class Form1
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
            this.btnHiCell = new System.Windows.Forms.Button();
            this.btnHiWithName = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtCoords = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblCol = new System.Windows.Forms.Label();
            this.txtCol = new System.Windows.Forms.TextBox();
            this.btnSelCell = new System.Windows.Forms.Button();
            this.btnSelHouse = new System.Windows.Forms.Button();
            this.btnSetNote = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnClearNote = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.chkRow = new System.Windows.Forms.CheckBox();
            this.chkCol = new System.Windows.Forms.CheckBox();
            this.chkHouse = new System.Windows.Forms.CheckBox();
            this.lblNum = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.chkGiven = new System.Windows.Forms.CheckBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.lblRow = new System.Windows.Forms.Label();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.radHiBad = new System.Windows.Forms.RadioButton();
            this.radHiInfo = new System.Windows.Forms.RadioButton();
            this.radHiNone = new System.Windows.Forms.RadioButton();
            this.radHiStrong = new System.Windows.Forms.RadioButton();
            this.radHiWeak = new System.Windows.Forms.RadioButton();
            this.btnHiNote = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHiCell
            // 
            this.btnHiCell.Enabled = false;
            this.btnHiCell.Location = new System.Drawing.Point(844, 391);
            this.btnHiCell.Name = "btnHiCell";
            this.btnHiCell.Size = new System.Drawing.Size(118, 23);
            this.btnHiCell.TabIndex = 2;
            this.btnHiCell.Text = "Highlight Cell";
            this.btnHiCell.UseVisualStyleBackColor = true;
            this.btnHiCell.Click += new System.EventHandler(this.btnHiCell_Click);
            // 
            // btnHiWithName
            // 
            this.btnHiWithName.Location = new System.Drawing.Point(844, 478);
            this.btnHiWithName.Name = "btnHiWithName";
            this.btnHiWithName.Size = new System.Drawing.Size(118, 23);
            this.btnHiWithName.TabIndex = 6;
            this.btnHiWithName.Text = "Highlight With Note";
            this.btnHiWithName.UseVisualStyleBackColor = true;
            this.btnHiWithName.Click += new System.EventHandler(this.btnHiWithName_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCreate.Location = new System.Drawing.Point(844, 574);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(118, 23);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create Board";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(36, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(540, 540);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(680, 31);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(282, 114);
            this.textBox2.TabIndex = 9;
            this.textBox2.WordWrap = false;
            // 
            // txtCoords
            // 
            this.txtCoords.Location = new System.Drawing.Point(507, 577);
            this.txtCoords.Name = "txtCoords";
            this.txtCoords.ReadOnly = true;
            this.txtCoords.Size = new System.Drawing.Size(69, 20);
            this.txtCoords.TabIndex = 10;
            this.txtCoords.TabStop = false;
            // 
            // txtSize
            // 
            this.txtSize.HideSelection = false;
            this.txtSize.Location = new System.Drawing.Point(807, 574);
            this.txtSize.MaxLength = 3;
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(25, 20);
            this.txtSize.TabIndex = 11;
            this.txtSize.Text = "60";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(754, 579);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(47, 13);
            this.lblSize.TabIndex = 12;
            this.lblSize.Text = "Cell Size";
            // 
            // lblCol
            // 
            this.lblCol.AutoSize = true;
            this.lblCol.Location = new System.Drawing.Point(766, 397);
            this.lblCol.Name = "lblCol";
            this.lblCol.Size = new System.Drawing.Size(22, 13);
            this.lblCol.TabIndex = 14;
            this.lblCol.Text = "Col";
            // 
            // txtCol
            // 
            this.txtCol.HideSelection = false;
            this.txtCol.Location = new System.Drawing.Point(801, 394);
            this.txtCol.MaxLength = 1;
            this.txtCol.Name = "txtCol";
            this.txtCol.Size = new System.Drawing.Size(25, 20);
            this.txtCol.TabIndex = 13;
            this.txtCol.Text = "1";
            // 
            // btnSelCell
            // 
            this.btnSelCell.Location = new System.Drawing.Point(844, 365);
            this.btnSelCell.Name = "btnSelCell";
            this.btnSelCell.Size = new System.Drawing.Size(118, 23);
            this.btnSelCell.TabIndex = 15;
            this.btnSelCell.Text = "Select Cell";
            this.btnSelCell.UseVisualStyleBackColor = true;
            this.btnSelCell.Click += new System.EventHandler(this.btnSelCell_Click);
            // 
            // btnSelHouse
            // 
            this.btnSelHouse.Enabled = false;
            this.btnSelHouse.Location = new System.Drawing.Point(844, 323);
            this.btnSelHouse.Name = "btnSelHouse";
            this.btnSelHouse.Size = new System.Drawing.Size(118, 23);
            this.btnSelHouse.TabIndex = 17;
            this.btnSelHouse.Text = "Select House";
            this.btnSelHouse.UseVisualStyleBackColor = true;
            this.btnSelHouse.Click += new System.EventHandler(this.btnSelHouse_Click);
            // 
            // btnSetNote
            // 
            this.btnSetNote.Location = new System.Drawing.Point(844, 420);
            this.btnSetNote.Name = "btnSetNote";
            this.btnSetNote.Size = new System.Drawing.Size(118, 23);
            this.btnSetNote.TabIndex = 18;
            this.btnSetNote.Text = "Set Note";
            this.btnSetNote.UseVisualStyleBackColor = true;
            this.btnSetNote.Click += new System.EventHandler(this.btnSetNote_Click);
            // 
            // txtNote
            // 
            this.txtNote.HideSelection = false;
            this.txtNote.Location = new System.Drawing.Point(801, 421);
            this.txtNote.MaxLength = 1;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(25, 20);
            this.txtNote.TabIndex = 19;
            this.txtNote.Text = "1";
            // 
            // btnClearNote
            // 
            this.btnClearNote.Location = new System.Drawing.Point(844, 449);
            this.btnClearNote.Name = "btnClearNote";
            this.btnClearNote.Size = new System.Drawing.Size(118, 23);
            this.btnClearNote.TabIndex = 20;
            this.btnClearNote.Text = "Clear Note";
            this.btnClearNote.UseVisualStyleBackColor = true;
            this.btnClearNote.Click += new System.EventHandler(this.btnClearNote_Click);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(762, 423);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(30, 13);
            this.lblNote.TabIndex = 21;
            this.lblNote.Text = "Note";
            // 
            // chkRow
            // 
            this.chkRow.AutoSize = true;
            this.chkRow.Checked = true;
            this.chkRow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRow.Location = new System.Drawing.Point(777, 310);
            this.chkRow.Name = "chkRow";
            this.chkRow.Size = new System.Drawing.Size(48, 17);
            this.chkRow.TabIndex = 22;
            this.chkRow.Text = "Row";
            this.chkRow.UseVisualStyleBackColor = true;
            // 
            // chkCol
            // 
            this.chkCol.AutoSize = true;
            this.chkCol.Location = new System.Drawing.Point(777, 327);
            this.chkCol.Name = "chkCol";
            this.chkCol.Size = new System.Drawing.Size(61, 17);
            this.chkCol.TabIndex = 23;
            this.chkCol.Text = "Column";
            this.chkCol.UseVisualStyleBackColor = true;
            // 
            // chkHouse
            // 
            this.chkHouse.AutoSize = true;
            this.chkHouse.Location = new System.Drawing.Point(777, 344);
            this.chkHouse.Name = "chkHouse";
            this.chkHouse.Size = new System.Drawing.Size(57, 17);
            this.chkHouse.TabIndex = 24;
            this.chkHouse.Text = "House";
            this.chkHouse.UseVisualStyleBackColor = true;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(762, 454);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(29, 13);
            this.lblNum.TabIndex = 26;
            this.lblNum.Text = "Num";
            // 
            // txtNum
            // 
            this.txtNum.HideSelection = false;
            this.txtNum.Location = new System.Drawing.Point(801, 451);
            this.txtNum.MaxLength = 1;
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(25, 20);
            this.txtNum.TabIndex = 25;
            this.txtNum.Text = "1";
            // 
            // chkGiven
            // 
            this.chkGiven.AutoSize = true;
            this.chkGiven.Checked = true;
            this.chkGiven.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGiven.Location = new System.Drawing.Point(778, 477);
            this.chkGiven.Name = "chkGiven";
            this.chkGiven.Size = new System.Drawing.Size(54, 17);
            this.chkGiven.TabIndex = 27;
            this.chkGiven.Text = "Given";
            this.chkGiven.UseVisualStyleBackColor = true;
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(844, 507);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(118, 23);
            this.btnAnswer.TabIndex = 28;
            this.btnAnswer.Text = "Set Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(766, 370);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(29, 13);
            this.lblRow.TabIndex = 30;
            this.lblRow.Text = "Row";
            // 
            // txtRow
            // 
            this.txtRow.HideSelection = false;
            this.txtRow.Location = new System.Drawing.Point(801, 367);
            this.txtRow.MaxLength = 1;
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(25, 20);
            this.txtRow.TabIndex = 29;
            this.txtRow.Text = "1";
            // 
            // radHiBad
            // 
            this.radHiBad.AutoSize = true;
            this.radHiBad.Location = new System.Drawing.Point(778, 231);
            this.radHiBad.Name = "radHiBad";
            this.radHiBad.Size = new System.Drawing.Size(44, 17);
            this.radHiBad.TabIndex = 33;
            this.radHiBad.Text = "Bad";
            this.radHiBad.UseVisualStyleBackColor = true;
            // 
            // radHiInfo
            // 
            this.radHiInfo.AutoSize = true;
            this.radHiInfo.Location = new System.Drawing.Point(778, 214);
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
            this.radHiNone.Location = new System.Drawing.Point(778, 197);
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
            this.radHiStrong.Location = new System.Drawing.Point(778, 248);
            this.radHiStrong.Name = "radHiStrong";
            this.radHiStrong.Size = new System.Drawing.Size(56, 17);
            this.radHiStrong.TabIndex = 34;
            this.radHiStrong.Text = "Strong";
            this.radHiStrong.UseVisualStyleBackColor = true;
            // 
            // radHiWeak
            // 
            this.radHiWeak.AutoSize = true;
            this.radHiWeak.Location = new System.Drawing.Point(778, 266);
            this.radHiWeak.Name = "radHiWeak";
            this.radHiWeak.Size = new System.Drawing.Size(54, 17);
            this.radHiWeak.TabIndex = 35;
            this.radHiWeak.Text = "Weak";
            this.radHiWeak.UseVisualStyleBackColor = true;
            // 
            // btnHiNote
            // 
            this.btnHiNote.Location = new System.Drawing.Point(844, 225);
            this.btnHiNote.Name = "btnHiNote";
            this.btnHiNote.Size = new System.Drawing.Size(118, 23);
            this.btnHiNote.TabIndex = 36;
            this.btnHiNote.Text = "Hightlight Note";
            this.btnHiNote.UseVisualStyleBackColor = true;
            this.btnHiNote.Click += new System.EventHandler(this.btnHiNote_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 610);
            this.Controls.Add(this.btnHiNote);
            this.Controls.Add(this.radHiWeak);
            this.Controls.Add(this.radHiStrong);
            this.Controls.Add(this.radHiBad);
            this.Controls.Add(this.radHiInfo);
            this.Controls.Add(this.radHiNone);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.chkGiven);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.chkHouse);
            this.Controls.Add(this.chkCol);
            this.Controls.Add(this.chkRow);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnClearNote);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnSetNote);
            this.Controls.Add(this.btnSelHouse);
            this.Controls.Add(this.btnSelCell);
            this.Controls.Add(this.lblCol);
            this.Controls.Add(this.txtCol);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.txtCoords);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnHiWithName);
            this.Controls.Add(this.btnHiCell);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnHiCell;
        private System.Windows.Forms.Button btnHiWithName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtCoords;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblCol;
        private System.Windows.Forms.TextBox txtCol;
        private System.Windows.Forms.Button btnSelCell;
        private System.Windows.Forms.Button btnSelHouse;
        private System.Windows.Forms.Button btnSetNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnClearNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.CheckBox chkRow;
        private System.Windows.Forms.CheckBox chkCol;
        private System.Windows.Forms.CheckBox chkHouse;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.CheckBox chkGiven;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.RadioButton radHiBad;
        private System.Windows.Forms.RadioButton radHiInfo;
        private System.Windows.Forms.RadioButton radHiNone;
        private System.Windows.Forms.RadioButton radHiStrong;
        private System.Windows.Forms.RadioButton radHiWeak;
        private System.Windows.Forms.Button btnHiNote;
    }
}

