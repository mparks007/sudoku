using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuCustomControls
{
    public partial class ColorButtonsList : UserControl
    {
        private RadioButton _priorRadio;    // the radio button selected before selecting a new one (to toggle UI look back to unselected)
        //private List<string> _buttonText = new List<string>();

        public int ActiveValue { get { return Int32.Parse(_priorRadio.Tag.ToString()); } }

        public ColorButtonsList()
        {
            InitializeComponent();

            // make the X be on by default
            _priorRadio = radNone;
        }

        public bool ClearSelected {  get { return radNone.Checked; } }

        /// <summary>
        /// Set Tag values for each button (will be the control's return value)
        /// </summary>
        /// <param name="tagX">Tag for the X (off) button</param>
        /// <param name="tag1">Tag for button 1</param>
        /// <param name="tag2">Tag for button 2</param>
        /// <param name="tag3">Tag for button 3</param>
        /// <param name="tag4">Tag for button 4</param>
        public void SetButtonTags(int tagX, int tag1, int tag2, int tag3, int tag4)
        {
            radNone.Tag = tagX;
            rad1.Tag = tag1;
            rad2.Tag = tag2;
            rad3.Tag = tag3;
            rad4.Tag = tag4;
        }

        /// <summary>
        /// Set text for each button
        /// </summary>
        /// <param name="textX">Text for the X (off) button</param>
        /// <param name="text1">Text for button 1</param>
        /// <param name="text2">Text for button 2</param>
        /// <param name="text3">Text for button 3</param>
        /// <param name="text4">Text for button 4</param>
        public void SetButtonText(string textX, string text1, string text2, string text3, string text4)
        {
            radNone.Text = textX;
            rad1.Text = text1;
            rad2.Text = text2;
            rad3.Text = text3;
            rad4.Text = text4;
        }

        /// <summary>
        /// Set background colors for each button
        /// </summary>
        /// <param name="colorX">Color for the X (off) button</param>
        /// <param name="color1">Color for button 1</param>
        /// <param name="color2">Color for button 2</param>
        /// <param name="color3">Color for button 3</param>
        /// <param name="color4">Color for button 4</param>
        public void SetButtonColors(Color colorX, Color color1, Color color2, Color color3, Color color4)
        {
            radNone.BackColor = colorX;
            rad1.BackColor = color1;
            rad2.BackColor = color2;
            rad3.BackColor = color3;
            rad4.BackColor = color4;
        }

        /// <summary>
        /// Set font colors for each button
        /// </summary>
        /// <param name="colorX">Font color for the X (off) button</param>
        /// <param name="color1">Font color for button 1</param>
        /// <param name="color2">Font color for button 2</param>
        /// <param name="color3">Font color for button 3</param>
        /// <param name="color4">Font color for button 4</param>
        public void SetButtonFontColors(Color colorX, Color color1, Color color2, Color color3, Color color4)
        {
            radNone.ForeColor = colorX;
            rad1.ForeColor = color1;
            rad2.ForeColor = color2;
            rad3.ForeColor = color3;
            rad4.ForeColor = color4;
        }

        /// <summary>
        /// Clicking one of the color buttons, so change look/feel, track new option, and let parent/listener know a click just happened
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void radButtons_Click(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;

            // flip the prior number seletion back to un-selected look/feel
            _priorRadio.FlatStyle = FlatStyle.Popup;
            // flip the new selection to unique look/feel
            rad.FlatStyle = FlatStyle.Standard;

            _priorRadio = rad;

            OnButtonClicked(e);
        }

        public event EventHandler ButtonClicked;
        /// <summary>
        /// Call back to event listeners that a click occurred
        /// </summary>
        /// <param name="e">Standard WinForms click-event args</param>
        protected virtual void OnButtonClicked(EventArgs e)
        {
            var handler = ButtonClicked;
            if (handler != null)
                handler(this, e);
        }
    }
}
