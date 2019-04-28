using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class frmColorDialog : Form
    {
        private Action _mainFormCallback;

        public frmColorDialog()
        {
            InitializeComponent();

            lbxChoices.Items.Clear();
            lbxChoices.DisplayMember = "Key";
            lbxChoices.ValueMember = "Value";

            // load up the list box with every custom color option
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Board Outer Boarder", Colors.BoardBorder));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Board Block Boarders", Colors.BlockBorder));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Border", Colors.CellBorder));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Background (Normal)", Colors.CellBlank));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Background (Block Alternate)", Colors.CellBlockAlternate));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Background (House Select)", Colors.CellHouseSelect));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Selection Box", Colors.CellSelectFrame));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (X)", Colors.CellHighlightNone));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (Value)", Colors.CellHighlightValue));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (Special)", Colors.CellHighlightSpecial));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (Pivot)", Colors.CellHighlightPivot));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (Pincer)", Colors.CellHighlightPincer));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (X)", Colors.CellTextOnHighlightNone));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (Value)", Colors.CellTextOnHighlightValue));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (Special)", Colors.CellTextOnHighlightSpecial));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (Pivot)", Colors.CellTextOnHighlightPivot));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (Pincer)", Colors.CellTextOnHighlightPincer));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Answer (Given)", Colors.AnswerGiven));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Answer (Guess)", Colors.AnswerGuess));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Answer (Invalid)", Colors.AnswerInvalid));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (X)", Colors.NoteHighlightNone));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (Info)", Colors.NoteHighlightInfo));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (Strong)", Colors.NoteHighlightStrong));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (Weak)", Colors.NoteHighlightWeak));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (Bad)", Colors.NoteHighlightBad));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (None)", Colors.NoteTextOnHighlightNone));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (Info)", Colors.NoteTextOnHighlightInfo));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (Strong)", Colors.NoteTextOnHighlightStrong));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (Weak)", Colors.NoteTextOnHighlightWeak));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (Bad)", Colors.NoteTextOnHighlightBad));
        }

        /// <summary>
        /// Allow the setting of the callback method on each color change
        /// </summary>
        /// <param name="callback">Method to call with a new color is selected</param>
        public void SetCallBack(Action callback)
        {
            _mainFormCallback = callback;
        }

        /// <summary>
        /// Update board with the custom colors
        /// </summary>
        public void SetCustom()
        {
            
            Colors.BoardBorder = ((KeyValuePair<string, Color>)lbxChoices.Items[0]).Value;
            Colors.BlockBorder = ((KeyValuePair<string, Color>)lbxChoices.Items[1]).Value;
            Colors.CellBorder = ((KeyValuePair<string, Color>)lbxChoices.Items[2]).Value;
            Colors.CellBlank = ((KeyValuePair<string, Color>)lbxChoices.Items[3]).Value;
            Colors.CellBlockAlternate = ((KeyValuePair<string, Color>)lbxChoices.Items[4]).Value;
            Colors.CellHouseSelect = ((KeyValuePair<string, Color>)lbxChoices.Items[5]).Value;
            Colors.CellSelectFrame = ((KeyValuePair<string, Color>)lbxChoices.Items[6]).Value;
            Colors.CellHighlightNone = ((KeyValuePair<string, Color>)lbxChoices.Items[7]).Value;
            Colors.CellHighlightValue = ((KeyValuePair<string, Color>)lbxChoices.Items[8]).Value;
            Colors.CellHighlightSpecial = ((KeyValuePair<string, Color>)lbxChoices.Items[9]).Value;
            Colors.CellHighlightPivot = ((KeyValuePair<string, Color>)lbxChoices.Items[10]).Value;
            Colors.CellHighlightPincer = ((KeyValuePair<string, Color>)lbxChoices.Items[11]).Value;
            Colors.CellTextOnHighlightNone = ((KeyValuePair<string, Color>)lbxChoices.Items[12]).Value;
            Colors.CellTextOnHighlightValue = ((KeyValuePair<string, Color>)lbxChoices.Items[13]).Value;
            Colors.CellTextOnHighlightSpecial = ((KeyValuePair<string, Color>)lbxChoices.Items[14]).Value;
            Colors.CellTextOnHighlightPivot = ((KeyValuePair<string, Color>)lbxChoices.Items[15]).Value;
            Colors.CellTextOnHighlightPincer = ((KeyValuePair<string, Color>)lbxChoices.Items[16]).Value;
            Colors.AnswerGiven = ((KeyValuePair<string, Color>)lbxChoices.Items[17]).Value;
            Colors.AnswerGuess = ((KeyValuePair<string, Color>)lbxChoices.Items[18]).Value;
            Colors.AnswerInvalid = ((KeyValuePair<string, Color>)lbxChoices.Items[19]).Value;
            Colors.NoteHighlightNone = ((KeyValuePair<string, Color>)lbxChoices.Items[20]).Value;
            Colors.NoteHighlightInfo = ((KeyValuePair<string, Color>)lbxChoices.Items[21]).Value;
            Colors.NoteHighlightStrong = ((KeyValuePair<string, Color>)lbxChoices.Items[22]).Value;
            Colors.NoteHighlightWeak = ((KeyValuePair<string, Color>)lbxChoices.Items[23]).Value;
            Colors.NoteHighlightBad = ((KeyValuePair<string, Color>)lbxChoices.Items[24]).Value;
            Colors.NoteTextOnHighlightNone = ((KeyValuePair<string, Color>)lbxChoices.Items[25]).Value;
            Colors.NoteTextOnHighlightInfo = ((KeyValuePair<string, Color>)lbxChoices.Items[26]).Value;
            Colors.NoteTextOnHighlightStrong = ((KeyValuePair<string, Color>)lbxChoices.Items[27]).Value;
            Colors.NoteTextOnHighlightWeak = ((KeyValuePair<string, Color>)lbxChoices.Items[28]).Value;
            Colors.NoteTextOnHighlightBad = ((KeyValuePair<string, Color>)lbxChoices.Items[29]).Value;
        }

        /// <summary>
        /// Clicked a color type from the list
        /// </summary>
        /// <param name="sender">Standard WinForm's sender object</param>
        /// <param name="e">Standard WinForm's args for a listbox click event</param>
        private void lbxChoices_Click(object sender, EventArgs e)
        {
            var kvp = (KeyValuePair<string, Color>)lbxChoices.SelectedItem;

            // prime the Color dialog with the selected color
            dlgColor.Color = kvp.Value;

            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                switch (lbxChoices.SelectedIndex)
                {
                    case 0:
                        Colors.BoardBorder = dlgColor.Color;
                        break;
                    case 1:
                        Colors.BlockBorder = dlgColor.Color;
                        break;
                    case 2:
                        Colors.CellBorder = dlgColor.Color;
                        break;
                    case 3:
                        Colors.CellBlank = dlgColor.Color;
                        break;
                    case 4:
                        Colors.CellBlockAlternate = dlgColor.Color;
                        break;
                    case 5:
                        Colors.CellHouseSelect = dlgColor.Color;
                        break;
                    case 6:
                        Colors.CellSelectFrame = dlgColor.Color;
                        break;
                    case 7:
                        Colors.CellHighlightNone = dlgColor.Color;
                        break;
                    case 8:
                        Colors.CellHighlightValue = dlgColor.Color;
                        break;
                    case 9:
                        Colors.CellHighlightSpecial = dlgColor.Color;
                        break;
                    case 10:
                        Colors.CellHighlightPivot = dlgColor.Color;
                        break;
                    case 11:
                        Colors.CellHighlightPincer = dlgColor.Color;
                        break;
                    case 12:
                        Colors.CellTextOnHighlightNone = dlgColor.Color;
                        break;
                    case 13:
                        Colors.CellTextOnHighlightValue = dlgColor.Color;
                        break;
                    case 14:
                        Colors.CellTextOnHighlightSpecial = dlgColor.Color;
                        break;
                    case 15:
                        Colors.CellTextOnHighlightPivot = dlgColor.Color;
                        break;
                    case 16:
                        Colors.CellTextOnHighlightPincer = dlgColor.Color;
                        break;
                    case 17:
                        Colors.AnswerGiven = dlgColor.Color;
                        break;
                    case 18:
                        Colors.AnswerGuess = dlgColor.Color;
                        break;
                    case 19:
                        Colors.AnswerInvalid = dlgColor.Color;
                        break;
                    case 20:
                        Colors.NoteHighlightNone = dlgColor.Color;
                        break;
                    case 21:
                        Colors.NoteHighlightInfo = dlgColor.Color;
                        break;
                    case 22:
                        Colors.NoteHighlightStrong = dlgColor.Color;
                        break;
                    case 23:
                        Colors.NoteHighlightWeak = dlgColor.Color;
                        break;
                    case 24:
                        Colors.NoteHighlightBad = dlgColor.Color;
                        break;
                    case 25:
                        Colors.NoteTextOnHighlightNone = dlgColor.Color;
                        break;
                    case 26:
                        Colors.NoteTextOnHighlightInfo = dlgColor.Color;
                        break;
                    case 27:
                        Colors.NoteTextOnHighlightStrong = dlgColor.Color;
                        break;
                    case 28:
                        Colors.NoteTextOnHighlightWeak = dlgColor.Color;
                        break;
                    case 29:
                        Colors.NoteTextOnHighlightBad = dlgColor.Color;
                        break;
                }

                // update the selected item's data
                lbxChoices.Items[lbxChoices.SelectedIndex] = new KeyValuePair<string, Color>(kvp.Key, dlgColor.Color);
            }

            // tell main form to update/render
            _mainFormCallback();
        }

        /// <summary>
        /// Key down on form
        /// </summary>
        /// <param name="sender">Standard WinForm's sender object</param>
        /// <param name="e">Standard WinForm's args for a key down event</param>
        private void frmColorDialog_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Enter:
                    lbxChoices_Click(sender, e);
                    break;
            }
        }
    }
}
