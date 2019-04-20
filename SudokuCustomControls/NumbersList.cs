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
    public partial class NumbersList : UserControl
    {
        private RadioButton _priorRadio;    // the radio button selected before selecting a new one (to toggle UI look back to unselected)
        private bool _triggerClickEvent;    // tracks if want a click on an already clicked button to trigger click

        [Description("Numeric value for the currently checked button.")]
        public int ActiveValue { get { return Int32.Parse(_priorRadio.Tag.ToString()); } }

        [Description("Trigger click event on already clicked button.")]
        public bool TriggerClickEvent
        {
            get { return _triggerClickEvent; }
            set { _triggerClickEvent = value; }
        }
        public NumbersList()
        {
            InitializeComponent();

            // make the 1 be on by default
            _priorRadio = rad1;
        }

        /// <summary>
        /// Clicking one of the numbers, so change look/feel, track new number, and let parent/listener know a click just happened
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void radNumbers_Click(object sender, EventArgs e)
        {
            RadioButton currentRadio = (RadioButton)sender;

            if ((currentRadio == _priorRadio) && !_triggerClickEvent)
                return;

            // flip the prior number seletion back to un-selected look/feel
            _priorRadio.BackColor = SystemColors.Highlight;
            _priorRadio.ForeColor = SystemColors.GradientInactiveCaption;
            _priorRadio.FlatStyle = FlatStyle.Popup;
            // flip the new selection to unique look/feel
            currentRadio.BackColor = SystemColors.GradientActiveCaption;
            currentRadio.ForeColor = SystemColors.Highlight;
            currentRadio.FlatStyle = FlatStyle.Standard;

            _priorRadio = currentRadio;

            OnNumberClicked(e);
        }

        /// <summary>
        /// Allow telling this component to set a specific number button (by number vs. click event)
        /// </summary>
        /// <param name="num">Number button to click</param>
        public void SimulateClick(int num)
        {
            RadioButton[] numButtons = { rad1, rad2, rad3, rad4, rad5, rad6, rad7, rad8, rad9 };
            radNumbers_Click(numButtons[num - 1], new EventArgs());
        }

        public event EventHandler NumberClicked;
        /// <summary>
        /// Call back to event listeners that a click occurred
        /// </summary>
        /// <param name="e">Standard WinForms click-event args</param>
        protected virtual void OnNumberClicked(EventArgs e)
        {
            var handler = NumberClicked;
            if (handler != null)
                handler(this, e);
        }
    }
}
