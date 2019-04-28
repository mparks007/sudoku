using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Board Outer Boarder", Colors.Instance.BoardBorder));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Board Block Boarders", Colors.Instance.BlockBorder));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Border", Colors.Instance.CellBorder));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Background (Normal)", Colors.Instance.CellBlank));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Background (Block Alternate)", Colors.Instance.CellBlockAlternate));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Background (House Select)", Colors.Instance.CellHouseSelect));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Selection Box", Colors.Instance.CellSelectFrame));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (X)", Colors.Instance.CellHighlightNone));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (Value)", Colors.Instance.CellHighlightValue));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (Special)", Colors.Instance.CellHighlightSpecial));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (Pivot)", Colors.Instance.CellHighlightPivot));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Highlight (Pincer)", Colors.Instance.CellHighlightPincer));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (X)", Colors.Instance.CellTextOnHighlightNone));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (Value)", Colors.Instance.CellTextOnHighlightValue));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (Special)", Colors.Instance.CellTextOnHighlightSpecial));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (Pivot)", Colors.Instance.CellTextOnHighlightPivot));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Text When Highlighted (Pincer)", Colors.Instance.CellTextOnHighlightPincer));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Answer (Given)", Colors.Instance.AnswerGiven));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Answer (Guess)", Colors.Instance.AnswerGuess));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Answer (Invalid)", Colors.Instance.AnswerInvalid));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (X)", Colors.Instance.NoteHighlightNone));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (Info)", Colors.Instance.NoteHighlightInfo));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (Strong)", Colors.Instance.NoteHighlightStrong));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (Weak)", Colors.Instance.NoteHighlightWeak));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Highlight (Bad)", Colors.Instance.NoteHighlightBad));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (None)", Colors.Instance.NoteTextOnHighlightNone));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (Info)", Colors.Instance.NoteTextOnHighlightInfo));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (Strong)", Colors.Instance.NoteTextOnHighlightStrong));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (Weak)", Colors.Instance.NoteTextOnHighlightWeak));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Note Text When Highlighted (Bad)", Colors.Instance.NoteTextOnHighlightBad));
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
            
            Colors.Instance.BoardBorder = ((KeyValuePair<string, Color>)lbxChoices.Items[0]).Value;
            Colors.Instance.BlockBorder = ((KeyValuePair<string, Color>)lbxChoices.Items[1]).Value;
            Colors.Instance.CellBorder = ((KeyValuePair<string, Color>)lbxChoices.Items[2]).Value;
            Colors.Instance.CellBlank = ((KeyValuePair<string, Color>)lbxChoices.Items[3]).Value;
            Colors.Instance.CellBlockAlternate = ((KeyValuePair<string, Color>)lbxChoices.Items[4]).Value;
            Colors.Instance.CellHouseSelect = ((KeyValuePair<string, Color>)lbxChoices.Items[5]).Value;
            Colors.Instance.CellSelectFrame = ((KeyValuePair<string, Color>)lbxChoices.Items[6]).Value;
            Colors.Instance.CellHighlightNone = ((KeyValuePair<string, Color>)lbxChoices.Items[7]).Value;
            Colors.Instance.CellHighlightValue = ((KeyValuePair<string, Color>)lbxChoices.Items[8]).Value;
            Colors.Instance.CellHighlightSpecial = ((KeyValuePair<string, Color>)lbxChoices.Items[9]).Value;
            Colors.Instance.CellHighlightPivot = ((KeyValuePair<string, Color>)lbxChoices.Items[10]).Value;
            Colors.Instance.CellHighlightPincer = ((KeyValuePair<string, Color>)lbxChoices.Items[11]).Value;
            Colors.Instance.CellTextOnHighlightNone = ((KeyValuePair<string, Color>)lbxChoices.Items[12]).Value;
            Colors.Instance.CellTextOnHighlightValue = ((KeyValuePair<string, Color>)lbxChoices.Items[13]).Value;
            Colors.Instance.CellTextOnHighlightSpecial = ((KeyValuePair<string, Color>)lbxChoices.Items[14]).Value;
            Colors.Instance.CellTextOnHighlightPivot = ((KeyValuePair<string, Color>)lbxChoices.Items[15]).Value;
            Colors.Instance.CellTextOnHighlightPincer = ((KeyValuePair<string, Color>)lbxChoices.Items[16]).Value;
            Colors.Instance.AnswerGiven = ((KeyValuePair<string, Color>)lbxChoices.Items[17]).Value;
            Colors.Instance.AnswerGuess = ((KeyValuePair<string, Color>)lbxChoices.Items[18]).Value;
            Colors.Instance.AnswerInvalid = ((KeyValuePair<string, Color>)lbxChoices.Items[19]).Value;
            Colors.Instance.NoteHighlightNone = ((KeyValuePair<string, Color>)lbxChoices.Items[20]).Value;
            Colors.Instance.NoteHighlightInfo = ((KeyValuePair<string, Color>)lbxChoices.Items[21]).Value;
            Colors.Instance.NoteHighlightStrong = ((KeyValuePair<string, Color>)lbxChoices.Items[22]).Value;
            Colors.Instance.NoteHighlightWeak = ((KeyValuePair<string, Color>)lbxChoices.Items[23]).Value;
            Colors.Instance.NoteHighlightBad = ((KeyValuePair<string, Color>)lbxChoices.Items[24]).Value;
            Colors.Instance.NoteTextOnHighlightNone = ((KeyValuePair<string, Color>)lbxChoices.Items[25]).Value;
            Colors.Instance.NoteTextOnHighlightInfo = ((KeyValuePair<string, Color>)lbxChoices.Items[26]).Value;
            Colors.Instance.NoteTextOnHighlightStrong = ((KeyValuePair<string, Color>)lbxChoices.Items[27]).Value;
            Colors.Instance.NoteTextOnHighlightWeak = ((KeyValuePair<string, Color>)lbxChoices.Items[28]).Value;
            Colors.Instance.NoteTextOnHighlightBad = ((KeyValuePair<string, Color>)lbxChoices.Items[29]).Value;
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
                        Colors.Instance.BoardBorder = dlgColor.Color;
                        break;
                    case 1:
                        Colors.Instance.BlockBorder = dlgColor.Color;
                        break;
                    case 2:
                        Colors.Instance.CellBorder = dlgColor.Color;
                        break;
                    case 3:
                        Colors.Instance.CellBlank = dlgColor.Color;
                        break;
                    case 4:
                        Colors.Instance.CellBlockAlternate = dlgColor.Color;
                        break;
                    case 5:
                        Colors.Instance.CellHouseSelect = dlgColor.Color;
                        break;
                    case 6:
                        Colors.Instance.CellSelectFrame = dlgColor.Color;
                        break;
                    case 7:
                        Colors.Instance.CellHighlightNone = dlgColor.Color;
                        break;
                    case 8:
                        Colors.Instance.CellHighlightValue = dlgColor.Color;
                        break;
                    case 9:
                        Colors.Instance.CellHighlightSpecial = dlgColor.Color;
                        break;
                    case 10:
                        Colors.Instance.CellHighlightPivot = dlgColor.Color;
                        break;
                    case 11:
                        Colors.Instance.CellHighlightPincer = dlgColor.Color;
                        break;
                    case 12:
                        Colors.Instance.CellTextOnHighlightNone = dlgColor.Color;
                        break;
                    case 13:
                        Colors.Instance.CellTextOnHighlightValue = dlgColor.Color;
                        break;
                    case 14:
                        Colors.Instance.CellTextOnHighlightSpecial = dlgColor.Color;
                        break;
                    case 15:
                        Colors.Instance.CellTextOnHighlightPivot = dlgColor.Color;
                        break;
                    case 16:
                        Colors.Instance.CellTextOnHighlightPincer = dlgColor.Color;
                        break;
                    case 17:
                        Colors.Instance.AnswerGiven = dlgColor.Color;
                        break;
                    case 18:
                        Colors.Instance.AnswerGuess = dlgColor.Color;
                        break;
                    case 19:
                        Colors.Instance.AnswerInvalid = dlgColor.Color;
                        break;
                    case 20:
                        Colors.Instance.NoteHighlightNone = dlgColor.Color;
                        break;
                    case 21:
                        Colors.Instance.NoteHighlightInfo = dlgColor.Color;
                        break;
                    case 22:
                        Colors.Instance.NoteHighlightStrong = dlgColor.Color;
                        break;
                    case 23:
                        Colors.Instance.NoteHighlightWeak = dlgColor.Color;
                        break;
                    case 24:
                        Colors.Instance.NoteHighlightBad = dlgColor.Color;
                        break;
                    case 25:
                        Colors.Instance.NoteTextOnHighlightNone = dlgColor.Color;
                        break;
                    case 26:
                        Colors.Instance.NoteTextOnHighlightInfo = dlgColor.Color;
                        break;
                    case 27:
                        Colors.Instance.NoteTextOnHighlightStrong = dlgColor.Color;
                        break;
                    case 28:
                        Colors.Instance.NoteTextOnHighlightWeak = dlgColor.Color;
                        break;
                    case 29:
                        Colors.Instance.NoteTextOnHighlightBad = dlgColor.Color;
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

        /// <summary>
        /// Save the current custom colors
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Colors.Instance, Newtonsoft.Json.Formatting.None);

            if (dlgExport.ShowDialog() == DialogResult.OK)
                File.WriteAllText(dlgExport.FileName, json);
        }

        /// <summary>
        /// Load custom colors
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dlgImport.ShowDialog() == DialogResult.OK)
            {
                var json = File.ReadAllText(dlgImport.FileName);

                Colors.Instance = JsonConvert.DeserializeObject<Colors>(json);

                _mainFormCallback();
            }
        }
    }
}
