using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public abstract class Note
    {
        [JsonProperty]
        protected int _candidate;

        /// <summary>
        /// The number on this note (if one was assinged)
        /// </summary>
        public int Candidate
        {
            get { return _candidate; }

            set
            {
                if ((value < 0) || (value > 9))
                    throw new ArgumentException(String.Format("Invalid note value being set: {0}", value));

                _candidate = value;
            }
        }

        public bool IsNoted { get { return _candidate != 0; } }
        public NoteHighlightType HighlightType { get; set; }

        /// <summary>
        /// Render (work done in derived classes)
        /// </summary>
        /// <param name="parentCellRow">Board row of the parent cell (used for render calculations)</param>
        /// <param name="parentCellColumn">Board column of the parent cell (used for render calculations)</param>
        public abstract void Render(int parentCellRow, int parentCellColumn);
    }
}
