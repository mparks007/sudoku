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
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Board Outer Boarder", BitmapBoard.Colors.BoardBorder));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Board Block Boarders", BitmapBoard.Colors.BlockBorder));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Border", BitmapBoard.Colors.CellBorder));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Background (Normal)", BitmapBoard.Colors.CellBlank));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Background (Block Alternate)", BitmapBoard.Colors.CellBlockAlternate));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Background (House Select)", BitmapBoard.Colors.CellHouseSelect));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Selection Box", BitmapBoard.Colors.CellSelectFrame));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (X)", BitmapBoard.Colors.CellHighlightNone));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (Value)", BitmapBoard.Colors.CellHighlightValue));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (Special)", BitmapBoard.Colors.CellHighlightSpecial));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (Pivot)", BitmapBoard.Colors.CellHighlightPivot));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (Pincer)", BitmapBoard.Colors.CellHighlightPincer));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (X)", BitmapBoard.Colors.CellTextOnHighlightNone));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (Value)", BitmapBoard.Colors.CellTextOnHighlightValue));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (Special)", BitmapBoard.Colors.CellTextOnHighlightSpecial));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (Pivot)", BitmapBoard.Colors.CellTextOnHighlightPivot));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (Pincer)", BitmapBoard.Colors.CellTextOnHighlightPincer));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Answer (Given)", BitmapBoard.Colors.AnswerGiven));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Answer (Guess)", BitmapBoard.Colors.AnswerGuess));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Answer (Invalid)", BitmapBoard.Colors.AnswerInvalid));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (X)", BitmapBoard.Colors.NoteHighlightNone));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (Info)", BitmapBoard.Colors.NoteHighlightInfo));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (Strong)", BitmapBoard.Colors.NoteHighlightStrong));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (Weak)", BitmapBoard.Colors.NoteHighlightWeak));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (Bad)", BitmapBoard.Colors.NoteHighlightBad));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (None)", BitmapBoard.Colors.NoteTextOnHighlightNone));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (Info)", BitmapBoard.Colors.NoteTextOnHighlightInfo));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (Strong)", BitmapBoard.Colors.NoteTextOnHighlightStrong));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (Weak)", BitmapBoard.Colors.NoteTextOnHighlightWeak));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (Bad)", BitmapBoard.Colors.NoteTextOnHighlightBad));
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
            
            BitmapBoard.Colors.BoardBorder = ((KeyValuePair<string, Color>)lbxChoices.Items[0]).Value;
            BitmapBoard.Colors.BlockBorder = ((KeyValuePair<string, Color>)lbxChoices.Items[1]).Value;
            BitmapBoard.Colors.CellBorder = ((KeyValuePair<string, Color>)lbxChoices.Items[2]).Value;
            BitmapBoard.Colors.CellBlank = ((KeyValuePair<string, Color>)lbxChoices.Items[3]).Value;
            BitmapBoard.Colors.CellBlockAlternate = ((KeyValuePair<string, Color>)lbxChoices.Items[4]).Value;
            BitmapBoard.Colors.CellHouseSelect = ((KeyValuePair<string, Color>)lbxChoices.Items[5]).Value;
            BitmapBoard.Colors.CellSelectFrame = ((KeyValuePair<string, Color>)lbxChoices.Items[6]).Value;
            BitmapBoard.Colors.CellHighlightNone = ((KeyValuePair<string, Color>)lbxChoices.Items[7]).Value;
            BitmapBoard.Colors.CellHighlightValue = ((KeyValuePair<string, Color>)lbxChoices.Items[8]).Value;
            BitmapBoard.Colors.CellHighlightSpecial = ((KeyValuePair<string, Color>)lbxChoices.Items[9]).Value;
            BitmapBoard.Colors.CellHighlightPivot = ((KeyValuePair<string, Color>)lbxChoices.Items[10]).Value;
            BitmapBoard.Colors.CellHighlightPincer = ((KeyValuePair<string, Color>)lbxChoices.Items[11]).Value;
            BitmapBoard.Colors.CellTextOnHighlightNone = ((KeyValuePair<string, Color>)lbxChoices.Items[12]).Value;
            BitmapBoard.Colors.CellTextOnHighlightValue = ((KeyValuePair<string, Color>)lbxChoices.Items[13]).Value;
            BitmapBoard.Colors.CellTextOnHighlightSpecial = ((KeyValuePair<string, Color>)lbxChoices.Items[14]).Value;
            BitmapBoard.Colors.CellTextOnHighlightPivot = ((KeyValuePair<string, Color>)lbxChoices.Items[15]).Value;
            BitmapBoard.Colors.CellTextOnHighlightPincer = ((KeyValuePair<string, Color>)lbxChoices.Items[16]).Value;
            BitmapBoard.Colors.AnswerGiven = ((KeyValuePair<string, Color>)lbxChoices.Items[17]).Value;
            BitmapBoard.Colors.AnswerGuess = ((KeyValuePair<string, Color>)lbxChoices.Items[18]).Value;
            BitmapBoard.Colors.AnswerInvalid = ((KeyValuePair<string, Color>)lbxChoices.Items[19]).Value;
            BitmapBoard.Colors.NoteHighlightNone = ((KeyValuePair<string, Color>)lbxChoices.Items[20]).Value;
            BitmapBoard.Colors.NoteHighlightInfo = ((KeyValuePair<string, Color>)lbxChoices.Items[21]).Value;
            BitmapBoard.Colors.NoteHighlightStrong = ((KeyValuePair<string, Color>)lbxChoices.Items[22]).Value;
            BitmapBoard.Colors.NoteHighlightWeak = ((KeyValuePair<string, Color>)lbxChoices.Items[23]).Value;
            BitmapBoard.Colors.NoteHighlightBad = ((KeyValuePair<string, Color>)lbxChoices.Items[24]).Value;
            BitmapBoard.Colors.NoteTextOnHighlightNone = ((KeyValuePair<string, Color>)lbxChoices.Items[25]).Value;
            BitmapBoard.Colors.NoteTextOnHighlightInfo = ((KeyValuePair<string, Color>)lbxChoices.Items[26]).Value;
            BitmapBoard.Colors.NoteTextOnHighlightStrong = ((KeyValuePair<string, Color>)lbxChoices.Items[27]).Value;
            BitmapBoard.Colors.NoteTextOnHighlightWeak = ((KeyValuePair<string, Color>)lbxChoices.Items[28]).Value;
            BitmapBoard.Colors.NoteTextOnHighlightBad = ((KeyValuePair<string, Color>)lbxChoices.Items[29]).Value;
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
                        BitmapBoard.Colors.BoardBorder = dlgColor.Color;
                        break;
                    case 1:
                        BitmapBoard.Colors.BlockBorder = dlgColor.Color;
                        break;
                    case 2:
                        BitmapBoard.Colors.CellBorder = dlgColor.Color;
                        break;
                    case 3:
                        BitmapBoard.Colors.CellBlank = dlgColor.Color;
                        break;
                    case 4:
                        BitmapBoard.Colors.CellBlockAlternate = dlgColor.Color;
                        break;
                    case 5:
                        BitmapBoard.Colors.CellHouseSelect = dlgColor.Color;
                        break;
                    case 6:
                        BitmapBoard.Colors.CellSelectFrame = dlgColor.Color;
                        break;
                    case 7:
                        BitmapBoard.Colors.CellHighlightNone = dlgColor.Color;
                        break;
                    case 8:
                        BitmapBoard.Colors.CellHighlightValue = dlgColor.Color;
                        break;
                    case 9:
                        BitmapBoard.Colors.CellHighlightSpecial = dlgColor.Color;
                        break;
                    case 10:
                        BitmapBoard.Colors.CellHighlightPivot = dlgColor.Color;
                        break;
                    case 11:
                        BitmapBoard.Colors.CellHighlightPincer = dlgColor.Color;
                        break;
                    case 12:
                        BitmapBoard.Colors.CellTextOnHighlightNone = dlgColor.Color;
                        break;
                    case 13:
                        BitmapBoard.Colors.CellTextOnHighlightValue = dlgColor.Color;
                        break;
                    case 14:
                        BitmapBoard.Colors.CellTextOnHighlightSpecial = dlgColor.Color;
                        break;
                    case 15:
                        BitmapBoard.Colors.CellTextOnHighlightPivot = dlgColor.Color;
                        break;
                    case 16:
                        BitmapBoard.Colors.CellTextOnHighlightPincer = dlgColor.Color;
                        break;
                    case 17:
                        BitmapBoard.Colors.AnswerGiven = dlgColor.Color;
                        break;
                    case 18:
                        BitmapBoard.Colors.AnswerGuess = dlgColor.Color;
                        break;
                    case 19:
                        BitmapBoard.Colors.AnswerInvalid = dlgColor.Color;
                        break;
                    case 20:
                        BitmapBoard.Colors.NoteHighlightNone = dlgColor.Color;
                        break;
                    case 21:
                        BitmapBoard.Colors.NoteHighlightInfo = dlgColor.Color;
                        break;
                    case 22:
                        BitmapBoard.Colors.NoteHighlightStrong = dlgColor.Color;
                        break;
                    case 23:
                        BitmapBoard.Colors.NoteHighlightWeak = dlgColor.Color;
                        break;
                    case 24:
                        BitmapBoard.Colors.NoteHighlightBad = dlgColor.Color;
                        break;
                    case 25:
                        BitmapBoard.Colors.NoteTextOnHighlightNone = dlgColor.Color;
                        break;
                    case 26:
                        BitmapBoard.Colors.NoteTextOnHighlightInfo = dlgColor.Color;
                        break;
                    case 27:
                        BitmapBoard.Colors.NoteTextOnHighlightStrong = dlgColor.Color;
                        break;
                    case 28:
                        BitmapBoard.Colors.NoteTextOnHighlightWeak = dlgColor.Color;
                        break;
                    case 29:
                        BitmapBoard.Colors.NoteTextOnHighlightBad = dlgColor.Color;
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
