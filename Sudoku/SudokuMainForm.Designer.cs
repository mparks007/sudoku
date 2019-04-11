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
            this.btnCreate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtCoords = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblCol = new System.Windows.Forms.Label();
            this.txtCol = new System.Windows.Forms.TextBox();
            this.btnSelCell = new System.Windows.Forms.Button();
            this.btnSetNote = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnClearNote = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.lblRow = new System.Windows.Forms.Label();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.radHiBad = new System.Windows.Forms.RadioButton();
            this.radHiInfo = new System.Windows.Forms.RadioButton();
            this.radHiNone = new System.Windows.Forms.RadioButton();
            this.radHiStrong = new System.Windows.Forms.RadioButton();
            this.radHiWeak = new System.Windows.Forms.RadioButton();
            this.btnHiNote = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radSetInvalid = new System.Windows.Forms.RadioButton();
            this.radSetGuess = new System.Windows.Forms.RadioButton();
            this.radSetGiven = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radSetNone = new System.Windows.Forms.RadioButton();
            this.btnHiWithValue = new System.Windows.Forms.Button();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCreate.Location = new System.Drawing.Point(682, 466);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(131, 23);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.TabStop = false;
            this.btnCreate.Text = "Create Board";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Visible = false;
            this.btnCreate.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(540, 540);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // txtCoords
            // 
            this.txtCoords.Location = new System.Drawing.Point(576, 535);
            this.txtCoords.Name = "txtCoords";
            this.txtCoords.ReadOnly = true;
            this.txtCoords.Size = new System.Drawing.Size(69, 20);
            this.txtCoords.TabIndex = 10;
            this.txtCoords.TabStop = false;
            // 
            // txtSize
            // 
            this.txtSize.HideSelection = false;
            this.txtSize.Location = new System.Drawing.Point(645, 466);
            this.txtSize.MaxLength = 3;
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(25, 20);
            this.txtSize.TabIndex = 11;
            this.txtSize.TabStop = false;
            this.txtSize.Text = "60";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(592, 471);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(47, 13);
            this.lblSize.TabIndex = 12;
            this.lblSize.Text = "Cell Size";
            // 
            // lblCol
            // 
            this.lblCol.AutoSize = true;
            this.lblCol.Location = new System.Drawing.Point(604, 218);
            this.lblCol.Name = "lblCol";
            this.lblCol.Size = new System.Drawing.Size(22, 13);
            this.lblCol.TabIndex = 14;
            this.lblCol.Text = "Col";
            // 
            // txtCol
            // 
            this.txtCol.HideSelection = false;
            this.txtCol.Location = new System.Drawing.Point(639, 215);
            this.txtCol.MaxLength = 1;
            this.txtCol.Name = "txtCol";
            this.txtCol.Size = new System.Drawing.Size(25, 20);
            this.txtCol.TabIndex = 13;
            this.txtCol.TabStop = false;
            this.txtCol.Text = "1";
            // 
            // btnSelCell
            // 
            this.btnSelCell.Location = new System.Drawing.Point(682, 202);
            this.btnSelCell.Name = "btnSelCell";
            this.btnSelCell.Size = new System.Drawing.Size(131, 23);
            this.btnSelCell.TabIndex = 15;
            this.btnSelCell.TabStop = false;
            this.btnSelCell.Text = "Select Cell";
            this.btnSelCell.UseVisualStyleBackColor = true;
            this.btnSelCell.Click += new System.EventHandler(this.btnSelCell_Click);
            // 
            // btnSetNote
            // 
            this.btnSetNote.Location = new System.Drawing.Point(682, 231);
            this.btnSetNote.Name = "btnSetNote";
            this.btnSetNote.Size = new System.Drawing.Size(131, 23);
            this.btnSetNote.TabIndex = 18;
            this.btnSetNote.TabStop = false;
            this.btnSetNote.Text = "Set Note";
            this.btnSetNote.UseVisualStyleBackColor = true;
            this.btnSetNote.Click += new System.EventHandler(this.btnSetNote_Click);
            // 
            // txtNote
            // 
            this.txtNote.HideSelection = false;
            this.txtNote.Location = new System.Drawing.Point(639, 242);
            this.txtNote.MaxLength = 1;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(25, 20);
            this.txtNote.TabIndex = 19;
            this.txtNote.TabStop = false;
            this.txtNote.Text = "1";
            // 
            // btnClearNote
            // 
            this.btnClearNote.Location = new System.Drawing.Point(682, 260);
            this.btnClearNote.Name = "btnClearNote";
            this.btnClearNote.Size = new System.Drawing.Size(131, 23);
            this.btnClearNote.TabIndex = 20;
            this.btnClearNote.TabStop = false;
            this.btnClearNote.Text = "Clear Note";
            this.btnClearNote.UseVisualStyleBackColor = true;
            this.btnClearNote.Click += new System.EventHandler(this.btnClearNote_Click);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(600, 244);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(30, 13);
            this.lblNote.TabIndex = 21;
            this.lblNote.Text = "Note";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(600, 273);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(29, 13);
            this.lblNum.TabIndex = 26;
            this.lblNum.Text = "Num";
            // 
            // txtNum
            // 
            this.txtNum.HideSelection = false;
            this.txtNum.Location = new System.Drawing.Point(639, 270);
            this.txtNum.MaxLength = 1;
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(25, 20);
            this.txtNum.TabIndex = 25;
            this.txtNum.TabStop = false;
            this.txtNum.Text = "1";
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(682, 362);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(131, 23);
            this.btnAnswer.TabIndex = 28;
            this.btnAnswer.TabStop = false;
            this.btnAnswer.Text = "Set Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(604, 191);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(29, 13);
            this.lblRow.TabIndex = 30;
            this.lblRow.Text = "Row";
            // 
            // txtRow
            // 
            this.txtRow.HideSelection = false;
            this.txtRow.Location = new System.Drawing.Point(639, 188);
            this.txtRow.MaxLength = 1;
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(25, 20);
            this.txtRow.TabIndex = 29;
            this.txtRow.TabStop = false;
            this.txtRow.Text = "1";
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
            this.btnHiNote.Location = new System.Drawing.Point(682, 55);
            this.btnHiNote.Name = "btnHiNote";
            this.btnHiNote.Size = new System.Drawing.Size(131, 23);
            this.btnHiNote.TabIndex = 36;
            this.btnHiNote.TabStop = false;
            this.btnHiNote.Text = "Hightlight Note";
            this.btnHiNote.UseVisualStyleBackColor = true;
            this.btnHiNote.Click += new System.EventHandler(this.btnHiNote_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(24, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 545);
            this.panel1.TabIndex = 37;
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
            this.groupBox1.Location = new System.Drawing.Point(610, 12);
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
            this.btnHiWithValue.Location = new System.Drawing.Point(682, 309);
            this.btnHiWithValue.Name = "btnHiWithValue";
            this.btnHiWithValue.Size = new System.Drawing.Size(131, 23);
            this.btnHiWithValue.TabIndex = 6;
            this.btnHiWithValue.TabStop = false;
            this.btnHiWithValue.Text = "Highlight With Value";
            this.btnHiWithValue.UseVisualStyleBackColor = true;
            this.btnHiWithValue.Click += new System.EventHandler(this.btnHiWithValue_Click);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(600, 312);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 44;
            this.lblValue.Text = "Value";
            // 
            // txtValue
            // 
            this.txtValue.HideSelection = false;
            this.txtValue.Location = new System.Drawing.Point(639, 309);
            this.txtValue.MaxLength = 1;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(25, 20);
            this.txtValue.TabIndex = 43;
            this.txtValue.TabStop = false;
            this.txtValue.Text = "1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(880, 572);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnHiNote);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnClearNote);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnSetNote);
            this.Controls.Add(this.btnSelCell);
            this.Controls.Add(this.lblCol);
            this.Controls.Add(this.txtCol);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.txtCoords);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnHiWithValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 615);
            this.MinimumSize = new System.Drawing.Size(900, 615);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Woofus Sudoku";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtCoords;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblCol;
        private System.Windows.Forms.TextBox txtCol;
        private System.Windows.Forms.Button btnSelCell;
        private System.Windows.Forms.Button btnSetNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnClearNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.RadioButton radHiBad;
        private System.Windows.Forms.RadioButton radHiInfo;
        private System.Windows.Forms.RadioButton radHiNone;
        private System.Windows.Forms.RadioButton radHiStrong;
        private System.Windows.Forms.RadioButton radHiWeak;
        private System.Windows.Forms.Button btnHiNote;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radSetInvalid;
        private System.Windows.Forms.RadioButton radSetGuess;
        private System.Windows.Forms.RadioButton radSetGiven;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHiWithValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.RadioButton radSetNone;
    }
}

