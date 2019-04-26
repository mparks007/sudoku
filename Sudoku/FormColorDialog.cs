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
        public frmColorDialog()
        {
            InitializeComponent();

            lbxChoices.Items.Clear();
            lbxChoices.DisplayMember = "Key";
            lbxChoices.ValueMember = "Value";

            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Board Outer Boarder", Color.Transparent));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Board Block Boarders", Color.Transparent));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Block Alternate Shading", Color.Transparent));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Border", Color.Transparent));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell Empty Background", Color.Transparent));
            lbxChoices.Items.Add(new KeyValuePair<string, Color>("Cell House Select", Color.Transparent));
        }

        private void lbxChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color color = ((KeyValuePair<string, Color>)lbxChoices.SelectedItem).Value;

            if (color != Color.Transparent)
                dlgColor.Color = (Color)lbxChoices.SelectedItem;

            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                switch (lbxChoices.SelectedIndex)
                {
                    case 0:
                        BitmapBoard.Colors.BoardBorder = dlgColor.Color;
                        break;
                }
            }
        }
    }
}
