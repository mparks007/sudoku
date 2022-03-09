﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    // http://hodoku.sourceforge.net/en/techniques.php
    // http://sudopedia.enjoysudoku.com/Solving_Technique.html
    // https://www.sudokuwiki.org/Unique_Rectangles

    public enum Pattern
    {
        [Description("Naked Single")]
        NakedSingle,
        [Description("Naked Pair")]
        NakedPair,
        [Description("Naked Triple")]
        NakedTriple,
        [Description("Naked Quad")]
        NakedQuad,
        [Description("Hidden Single")]
        HiddenSingle,
        [Description("Hidden Pair")]
        HiddenPair,
        [Description("Hidden Triple")]
        HiddenTriple,
        [Description("Hidden Quad")]
        HiddenQuad,
        [Description("Pointing Pair/Triple")]
        PointingPairTriple,
        [Description("Box/Line Reduction")]
        BoxLineReduction,
        [Description("X-Wing")]
        XWing,
        [Description("Finned X-Wing")]
        FinnedXWing,
        [Description("Sashimi X-Wing")]
        SashimiXWing,
        [Description("Skyscraper")]
        Skyscraper,
        [Description("Two-String Kite")]
        TwoStringKite,
        [Description("XYZ-Wing")]
        XYZWing,
        [Description("W-Wing")]
        WWing,
        [Description("XY-Wing (Y-Wing)")]
        XYWing,
        [Description("Empty Rectangle")]
        EmptyRectangle,
        [Description("Deadly")]
        Deadly,
        [Description("Unique Rectangle Type 1")]
        UniqueRectangleType1,
        [Description("BugPlusOne")]
        BugPlusOne,
        [Description("Swordfish")]
        Swordfish
    }
}
