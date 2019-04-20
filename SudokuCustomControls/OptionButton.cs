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
    public partial class OptionButton : UserControl
    {
        private List<string> _stateText = new List<string>(new string[] { "unchecked", "checked", "indeterminate" });

        public OptionButton()
        {
            InitializeComponent();
        }

        [Description("The label text for the control")]
        public string Label
        {
            get { return lbOption.Text; }
            set { lbOption.Text = value; }
        }

        [Description("The specific checked state type (unchecked, checked), indeterminate")]
        public CheckState CheckState
        {
            get { return chkOption.CheckState; }
            set { chkOption.CheckState = value; }
        }

        [Description("The checked state of the checkbox/button.")]
        public bool Checked
        {
            get { return chkOption.Checked; }
            set { chkOption.Checked = value; }
        }

        [Description("If the checkbox/button should be ThreeState.")]
        public bool ThreeState
        {
            get { return chkOption.ThreeState; }
            set { chkOption.ThreeState = value; }
        }

        public void SetButtonText(string text1, string text2, string text3)
        {
            _stateText.Clear();
            _stateText.AddRange(new string[] { text1, text2, text3});
            chkOption_CheckStateChanged(this, new EventArgs());
        }

        private void chkOption_CheckStateChanged(object sender, EventArgs e)
        {
            chkOption.Text = _stateText[(int)chkOption.CheckState];

            //switch (chkOption.CheckState)
            //{
            //    case CheckState.Unchecked:
            //        chkOption.Text = _stateText[0];
            //        break;
            //    case CheckState.Checked:
            //        chkOption.Text = _stateText[1];
            //        break;
            //    case CheckState.Indeterminate:
            //        chkOption.Text = _stateText[2];
            //        //pnlCellHighlightPicker.Visible = true;
            //        //pnlNoteHighlightPicker.Visible = true;
            //        //pnlNoteHighlightPicker.Top = 94;
            //        //pnlHiNumbers.Visible = true;
            //        //_highlightClickMode = HighlightClickMode.Manual;
            //        break;
            //}

            //OnButtonClicked(new OptionButtonEventArgs(chkOption.CheckState));
            OnButtonClicked(e);
        }

        public event EventHandler ButtonClicked;
        /// <summary>
        /// Call back to event listeners that a click occurred
        /// </summary>
        /// <param name="e">Standard WinForms click-event args</param>
        protected virtual void OnButtonClicked(EventArgs e)
        //protected virtual void OnButtonClicked(OptionButtonEventArgs e)
        {
            var handler = ButtonClicked;
            if (handler != null)
                handler(this, e);
        }
    }

    //public class OptionButtonEventArgs : EventArgs
    //{
    //    CheckState _checkState;

    //    public CheckState CheckState { get; }

    //    public OptionButtonEventArgs(CheckState checkState)
    //    {
    //        _checkState = checkState;
    //    }
    //}
}
