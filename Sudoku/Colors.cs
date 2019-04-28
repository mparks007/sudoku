using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class Colors
    {
        public static Color BoardBorder;
        public static Color BlockBorder;
        public static Color CellBorder;
        public static Color CellBlank;
        public static Color CellBlockAlternate;
        public static Color CellHouseSelect;
        public static Color CellSelectFrame;
        public static Color CellHighlightNone;
        public static Color CellHighlightValue;
        public static Color CellHighlightSpecial;
        public static Color CellHighlightPivot;
        public static Color CellHighlightPincer;
        public static Color CellTextOnHighlightNone;
        public static Color CellTextOnHighlightValue;
        public static Color CellTextOnHighlightSpecial;
        public static Color CellTextOnHighlightPivot;
        public static Color CellTextOnHighlightPincer;
        public static Color AnswerGiven;
        public static Color AnswerGuess;
        public static Color AnswerInvalid;
        public static Color NoteHighlightNone;
        public static Color NoteHighlightInfo;
        public static Color NoteHighlightStrong;
        public static Color NoteHighlightWeak;
        public static Color NoteHighlightBad;
        public static Color NoteTextOnHighlightNone;
        public static Color NoteTextOnHighlightInfo;
        public static Color NoteTextOnHighlightStrong;
        public static Color NoteTextOnHighlightWeak;
        public static Color NoteTextOnHighlightBad;

        static Colors()
        {
            SetLight();
        }

        public static void SetLight()
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

        public static void SetDark()
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
