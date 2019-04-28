using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public sealed class Colors
    {
        //private static readonly Lazy<Colors> lazy = new Lazy<Colors>(() => new Colors());
        private static Colors _instance = new Colors();

        // public static Colors Instance { get { return lazy.Value; } }
        public static Colors Instance
        {
            get { return _instance; } 
            set { _instance = value;  }
        }

        //public void SetInstance(Colors instance)
        //{
        //    lazy.
        //}

        public Color BoardBorder { get; set; }
        public Color BlockBorder { get; set; }
        public Color CellBorder { get; set; }
        public Color CellBlank { get; set; }
        public Color CellBlockAlternate { get; set; }
        public Color CellHouseSelect { get; set; }
        public Color CellSelectFrame { get; set; }
        public Color CellHighlightNone { get; set; }
        public Color CellHighlightValue { get; set; }
        public Color CellHighlightSpecial { get; set; }
        public Color CellHighlightPivot { get; set; }
        public Color CellHighlightPincer { get; set; }
        public Color CellTextOnHighlightNone { get; set; }
        public Color CellTextOnHighlightValue { get; set; }
        public Color CellTextOnHighlightSpecial { get; set; }
        public Color CellTextOnHighlightPivot { get; set; }
        public Color CellTextOnHighlightPincer { get; set; }
        public Color AnswerGiven { get; set; }
        public Color AnswerGuess { get; set; }
        public Color AnswerInvalid { get; set; }
        public Color NoteHighlightNone { get; set; }
        public Color NoteHighlightInfo { get; set; }
        public Color NoteHighlightStrong { get; set; }
        public Color NoteHighlightWeak { get; set; }
        public Color NoteHighlightBad { get; set; }
        public Color NoteTextOnHighlightNone { get; set; }
        public Color NoteTextOnHighlightInfo { get; set; }
        public Color NoteTextOnHighlightStrong { get; set; }
        public Color NoteTextOnHighlightWeak { get; set; }
        public Color NoteTextOnHighlightBad { get; set; }

        private Colors()
        {
            SetLight();
        }

        public void SetLight()
        {
            BoardBorder = Color.Black;
            BlockBorder = Color.Black;
            CellBorder = Color.DarkGray;
            CellBlank = Color.White;
            CellBlockAlternate = Color.GhostWhite;
            CellHouseSelect = Color.LavenderBlush;
            CellSelectFrame = Color.Coral;
            CellHighlightNone = SystemColors.GradientInactiveCaption;
            CellHighlightValue = Color.Lime;
            CellHighlightSpecial = Color.MediumSeaGreen;
            CellHighlightPivot = Color.LightSeaGreen;
            CellHighlightPincer = Color.Aquamarine;
            CellTextOnHighlightNone = Color.DimGray;
            CellTextOnHighlightValue = Color.DarkSlateGray;
            CellTextOnHighlightSpecial = Color.DarkSlateGray;
            CellTextOnHighlightPivot = Color.DarkSlateGray;
            CellTextOnHighlightPincer = Color.DarkSlateGray;
            AnswerGiven = Color.Black;
            AnswerGuess = Color.Blue;
            AnswerInvalid = Color.Red;
            NoteHighlightNone = Color.Transparent;
            NoteHighlightInfo = Color.Plum;
            NoteHighlightStrong = Color.RoyalBlue;
            NoteHighlightWeak = Color.Yellow;
            NoteHighlightBad = Color.Red;
            NoteTextOnHighlightNone = Color.DarkSlateGray;
            NoteTextOnHighlightInfo = Color.DarkSlateGray;
            NoteTextOnHighlightStrong = Color.LightGray;
            NoteTextOnHighlightWeak = Color.DarkSlateGray;
            NoteTextOnHighlightBad = Color.LightGray;
        }

        public void SetDark()
        {
            BoardBorder = Color.DarkViolet;
            BlockBorder = Color.DarkViolet;
            CellBorder = Color.DarkSlateBlue;
            CellBlank = Color.Black;
            CellBlockAlternate = Color.FromArgb(15, 15, 15);
            CellHouseSelect = Color.FromArgb(30, 30, 30);
            CellSelectFrame = Color.DarkOliveGreen;
            CellHighlightNone = SystemColors.GradientInactiveCaption;
            CellHighlightValue = Color.Lime;
            CellHighlightSpecial = Color.MediumSeaGreen;
            CellHighlightPivot = Color.LightSeaGreen;
            CellHighlightPincer = Color.Aquamarine;
            CellTextOnHighlightNone = Color.DimGray;
            CellTextOnHighlightValue = Color.DarkSlateGray;
            CellTextOnHighlightSpecial = Color.DarkSlateGray;
            CellTextOnHighlightPivot = Color.DarkSlateGray;
            CellTextOnHighlightPincer = Color.DarkSlateGray;
            AnswerGiven = Color.DarkOliveGreen;
            AnswerGuess = Color.DarkMagenta;
            AnswerInvalid = Color.Red;
            NoteHighlightNone = Color.Transparent;
            NoteHighlightInfo = Color.Plum;
            NoteHighlightStrong = Color.RoyalBlue;
            NoteHighlightWeak = Color.Yellow;
            NoteHighlightBad = Color.Red;
            NoteTextOnHighlightNone = Color.DimGray;
            NoteTextOnHighlightInfo = Color.DarkSlateGray;
            NoteTextOnHighlightStrong = Color.LightGray;
            NoteTextOnHighlightWeak = Color.DarkSlateGray;
            NoteTextOnHighlightBad = Color.LightGray;
        }
    }
}
