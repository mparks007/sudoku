﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class frmMain : Form
    {
        private Graphics _gr;                                       // to snag the Form's graphics object for use in Render call vs. snagging it every time Render is called
        private int _xOffset = 20;                                  // how far over from Form's left edge to start painting the board
        private int _yOffset = 20;                                  // how far down from Form's top edge to start painting the board
        private ModifierKey _modifierKey = ModifierKey.None;        // keeping track of alt, shift, ctrl state at the time of early key trapping and normal keypress events
        private frmColorDialog _frmColors = new frmColorDialog();   // form to allow selection of custom colors
        private string _initialBoard;                               // board that is initially set when the app loads (last, default, hardcode default)...so Reset can jump back to this board

        private readonly string _lastBoard = "lastboard.json";
        private readonly string _defaultBoard = "defaultboard.json";

        // components for click/doubleclick hack code :(
        private Timer _doubleClickTimer = new Timer();
        private bool _isFirstClick = true;
        private bool _isRightClick;
        private bool _isLeftClick;
        private bool _isMiddleClick;
        private bool _isDoubleClick;
        private int _milliseconds;
        private int _clickX;
        private int _clickY;

        /// <summary>
        /// Standard WinForms ctor for one-time setup things 
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            _gr = CreateGraphics();

            _frmColors.SetCallBack(ColorUIUpdateAndRender);

            SetupCustomControls();
            SetupPatternFinderControls();

            // setup time for click/doubleclick hack code :(
            _doubleClickTimer.Interval = 35;
            _doubleClickTimer.Tick += new EventHandler(doubleClickTimer_Tick);

            Game.CreateInstance(BoardType.Bitmap, cellSize: 60);

            // for startup board, don't count towards undo/redo queue
            ActionManager.Pause();
            SetupInitialBoard();
            ActionManager.Resume(((BitmapBoard)Game.Board).CellsAsJSON());

            Render();
        }

        /// <summary>
        /// Try to load last board, then try default board, then fall back to hard coded startup board
        ///   Also, save this initial board for reset option 
        /// </summary>
        private void SetupInitialBoard()
        {
            if (File.Exists(_lastBoard))
            {
                _initialBoard = File.ReadAllText(_lastBoard);
                ((BitmapBoard)Game.Board).LoadCells(_initialBoard);
            }
            else if (File.Exists(_defaultBoard))
            {
                _initialBoard = File.ReadAllText(_defaultBoard);
                ((BitmapBoard)Game.Board).LoadCells(_initialBoard);
            }
            else
            {
                Game.Board.SetDefaultState();
                _initialBoard = Game.Board.CellsAsJSON();
            }
        }

        /// <summary>
        /// Setup various button/checkbox controls to the appropriate text and coloring
        /// </summary>
        private void SetupCustomControls()
        {
            // listen for numbers clicking
            pnlFocusNumber.NumberClicked += pnlSetNumbers_NumberClicked;

            // component setup for Cell Highlight control
            pnlCellHighlightPicker.SetButtonTags((int)CellHighlightType.None, (int)CellHighlightType.Value, (int)CellHighlightType.Special, (int)CellHighlightType.Pivot, (int)CellHighlightType.Pincer);
            pnlCellHighlightPicker.SetButtonText(CellHighlightType.None.Description(), CellHighlightType.Value.Description(), CellHighlightType.Special.Description(), CellHighlightType.Pivot.Description(), CellHighlightType.Pincer.Description());
            pnlCellHighlightPicker.SetButtonColors(Colors.Instance.CellHighlightNone, Colors.Instance.CellHighlightValue, Colors.Instance.CellHighlightSpecial, Colors.Instance.CellHighlightPivot, Colors.Instance.CellHighlightPincer);
            pnlCellHighlightPicker.SetButtonFontColors(Colors.Instance.CellTextOnHighlightNone, Colors.Instance.CellTextOnHighlightValue, Colors.Instance.CellTextOnHighlightSpecial, Colors.Instance.CellTextOnHighlightPivot, Colors.Instance.CellTextOnHighlightPincer);
            pnlCellHighlightPicker.ButtonClicked += pnlCellHighlightPicker_Clicked;

            // component setup for Note Highlight control
            pnlNoteHighlightPicker.SetButtonTags((int)NoteHighlightType.None, (int)NoteHighlightType.Info, (int)NoteHighlightType.Strong, (int)NoteHighlightType.Weak, (int)NoteHighlightType.Bad);
            pnlNoteHighlightPicker.SetButtonText(NoteHighlightType.None.Description(), NoteHighlightType.Info.Description(), NoteHighlightType.Strong.Description(), NoteHighlightType.Weak.Description(), NoteHighlightType.Bad.Description());
            pnlNoteHighlightPicker.SetButtonColors(Colors.Instance.NoteHighlightNone, Colors.Instance.NoteHighlightInfo, Colors.Instance.NoteHighlightStrong, Colors.Instance.NoteHighlightWeak, Colors.Instance.NoteHighlightBad);
            pnlNoteHighlightPicker.SetButtonFontColors(Colors.Instance.NoteTextOnHighlightNone, Colors.Instance.NoteTextOnHighlightInfo, Colors.Instance.NoteTextOnHighlightStrong, Colors.Instance.NoteTextOnHighlightWeak, Colors.Instance.NoteTextOnHighlightBad);
            pnlNoteHighlightPicker.ButtonClicked += pnlNoteHighlightPicker_Clicked;

            // [options buttons setup]
            //  for highlight click mode
            chkHighlightClickMode.SetButtonText(HighlightClickMode.Cell.Description(), HighlightClickMode.Note.Description(), HighlightClickMode.Manual.Description());
            chkHighlightClickMode.ButtonClicked += chkHighlightClickMode_ButtonClicked;
            //  for givens lock option
            chkGivensLock.SetButtonText(YesNo.No.Description(), YesNo.Yes.Description());
            chkGivensLock.ButtonClicked += chkGivensLock_ButtonClicked;
            //  for notes lock option
            chkNotesHold.SetButtonText(YesNo.No.Description(), YesNo.Yes.Description());
            //  for highlight value selected value mode
            chkHighlightHavingValue.SetButtonText(HighlightValueMode.NotesOnly.Description(), HighlightValueMode.NumbersAndNotes.Description(), HighlightValueMode.Off.Description());
            chkHighlightHavingValue.ButtonClicked += chkHighlightHavingValue_ButtonClicked;
            //  for number keys mode
            chkNumberKeysMode.SetButtonText(NumberKeysMode.Numbers.Description(), NumberKeysMode.Notes.Description());
            //  for remove old notes mode
            chkRemoveOldNotes.SetButtonText(YesNo.No.Description(), YesNo.Yes.Description());
            chkRemoveOldNotes.ButtonClicked += chkRemoveOldNotes_ButtonClicked;
            //  for validation mode
            chkValidationMode.SetButtonText(ValidationMode.Numbers.Description(), ValidationMode.Notes.Description(), ValidationMode.Off.Description());
            chkValidationMode.ButtonClicked += chkValidationMode_ButtonClicked;
            //  for validation mode
            chkColorScheme.SetButtonText(ColorScheme.Light.Description(), ColorScheme.Dark.Description(), ColorScheme.Custom.Description());
            chkColorScheme.ButtonClicked += chkColorScheme_ButtonClicked;
        }

        /// <summary>
        /// Setup the Patterns combo box
        /// </summary>
        private void SetupPatternFinderControls()
        {
            cbxPatterns.Items.Clear();
            cbxPatterns.DisplayMember = "Key";
            cbxPatterns.ValueMember = "Value";

            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.NakedSingle.Description(), Pattern.NakedSingle));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.NakedPair.Description(), Pattern.NakedPair));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.NakedTriple.Description(), Pattern.NakedTriple));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.NakedQuad.Description(), Pattern.NakedQuad));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.NakedQuint.Description(), Pattern.NakedQuint));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.HiddenSingle.Description(), Pattern.HiddenSingle));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.HiddenPair.Description(), Pattern.HiddenPair));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.HiddenTriple.Description(), Pattern.HiddenTriple));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.HiddenQuad.Description(), Pattern.HiddenQuad));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.HiddenQuint.Description(), Pattern.HiddenQuint));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.XWing.Description(), Pattern.XWing));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.Swordfish.Description(), Pattern.Swordfish));
            //cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.FinnedXWing.Description(), Pattern.FinnedXWing));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.Skyscraper.Description(), Pattern.Skyscraper));
            //cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.TwoStringKite.Description(), Pattern.TwoStringKite));

            cbxPatterns.SelectedIndex = 0;

            cbxFindResults.Items.Clear();
            cbxFindResults.DisplayMember = "Key";
            cbxFindResults.ValueMember = "Value";
        }

        /// <summary>
        /// Common method to redraw the board based on current state
        /// </summary>
        private void Render()
        {
            Game.Board.Render();

            // now paint the board directly on the Form
            PaintEventArgs e = new PaintEventArgs(_gr, new Rectangle(0, 0, Width, Height));
            e.Graphics.DrawImageUnscaled(((BitmapBoard)Game.Board).Image, _xOffset, _yOffset);  // Offset x/y to prevent board from being in the far upper left (0,0) of the form 
        }

        /// <summary>
        /// Callback/Event from cell click mode to track mode and to manipulate the UI a bit per mode
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void chkHighlightClickMode_ButtonClicked(object sender, EventArgs e)
        {
            switch (chkHighlightClickMode.CheckState)
            {
                case CheckState.Unchecked:
                    pnlCellHighlightPicker.Visible = true;
                    pnlNoteHighlightPicker.Visible = false;
                    pnlHiNumbersList.Visible = false;
                    break;
                case CheckState.Checked:
                    pnlNoteHighlightPicker.Visible = true;
                    pnlNoteHighlightPicker.Top = 40;
                    pnlCellHighlightPicker.Visible = false;
                    pnlHiNumbersList.Visible = false;
                    break;
                case CheckState.Indeterminate:
                    pnlCellHighlightPicker.Visible = true;
                    pnlNoteHighlightPicker.Visible = true;
                    pnlNoteHighlightPicker.Top = 71;
                    pnlHiNumbersList.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Callback/Event from givnes lock option 
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void chkGivensLock_ButtonClicked(object sender, EventArgs e)
        {
            Board.GivensLock = (YesNo)chkGivensLock.CheckState;
        }

        /// <summary>
        /// Callback/Event from Cell Highlight control to maybe trigger highlighting
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void pnlCellHighlightPicker_Clicked(object sender, EventArgs e)
        {
            // if shift click on the X, clear all cell hightlights
            if (pnlCellHighlightPicker.ClearSelected && (Control.ModifierKeys == Keys.Shift))
            {
                ActionManager.Pause();

                Game.Board.HighlightCellsWithNoteOrNumber(-1);
                Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

                ActionManager.Resume(((BitmapBoard)Game.Board).CellsAsJSON());
                Render();
            }
            else if (chkHighlightClickMode.CheckState == (CheckState)HighlightClickMode.Manual)
            {
                Game.Board.HighlightSelectedCell((CellHighlightType)pnlCellHighlightPicker.ActiveValue);
                Render();
            }
        }
 
        /// <summary>
        /// Callback/Event from Note Highlight control to maybe trigger highlighting
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void pnlNoteHighlightPicker_Clicked(object sender, EventArgs e)
        {
            // if shift click on the X, clear all note hightlights
            if (pnlNoteHighlightPicker.ClearSelected && (Control.ModifierKeys == Keys.Shift))
            {
                Game.Board.ClearNoteHighlights();
                Render();
            }
            else if ((chkHighlightClickMode.CheckState == (CheckState)HighlightClickMode.Manual) && !Game.Board.SelectedCell.HasAnswer) // if every click needs to update the selected cell (manual mode) && the cell has note visable (no answer set)
            {
                Game.Board.HighlightNote(pnlHiNumbersList.ActiveValue, (NoteHighlightType)pnlNoteHighlightPicker.ActiveValue);
                Render();
            }
        }

        /// <summary>
        /// Set the current cell to the selected number (as a Given or Guess)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnSetNumber_Click(object sender, EventArgs e)
        {
            ActionManager.Pause();

            if (chkGivensLock.Checked)
                Game.Board.SetGiven(pnlFocusNumber.ActiveValue);
            else
                Game.Board.SetGuess(pnlFocusNumber.ActiveValue);

            Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

            ActionManager.Resume(((BitmapBoard)Game.Board).CellsAsJSON());
            Render();
            CheckForSolved();
        }

        /// <summary>
        /// Callback/Event from Set Numbers control to maybe trigger value highlight
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void pnlSetNumbers_NumberClicked(object sender, EventArgs e)
        {
            Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);
            Render();
        }

        /// <summary>
        /// Toggle select note on/off in the selected cell
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnToggleNote_Click(object sender, EventArgs e)
        {
            ActionManager.Pause();

            Game.Board.ToggleNote(pnlFocusNumber.ActiveValue);
            Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

            ActionManager.Resume(((BitmapBoard)Game.Board).CellsAsJSON());
            Render();
        }

        /// <summary>
        /// Selecting a different Pattern
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void cbxPatterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxFindResults.Items.Clear();
        }

        /// <summary>
        /// Find the pattern selected in the patter combo box
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            cbxFindResults.Items.Clear();

            // try to find patterns for the selected type
            List<FindResult> results = Game.Board.Finder.Find(Game.Board, ((KeyValuePair<string, Pattern>)cbxPatterns.SelectedItem).Value);

            // load list of all results
            foreach (FindResult result in results)
                cbxFindResults.Items.Add(new KeyValuePair<string, FindResult>(result.ToString(), result));

            // if found any patterns, might as well select the first one, otherwise, clear potential highlights of last one
            if (cbxFindResults.Items.Count > 0)
                cbxFindResults.SelectedIndex = 0;
            else
            {
                Game.Board.HighlightCellsWithNoteOrNumber(-1);
                Game.Board.ClearNoteHighlights();
                Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);
            }
        }

        /// <summary>
        /// Selected a found pattern, so highlight based on the cells in the results
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void cbxFindResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionManager.Pause();

            // clear prior highlighting, even patterns! clear all note highlights. maybe re-highlight
            Game.Board.HighlightCellsWithNoteOrNumber(-1);
            Game.Board.ClearNoteHighlights();
            Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

            // snag the search result from the cbx
            FindResult result = ((KeyValuePair<string, FindResult>)cbxFindResults.SelectedItem).Value;
                        
            // go through all the found candidate cells and highlight accordingly (cells and the notes in them)
            foreach (KeyValuePair<Cell, CellHighlightType> candidateCell in result.CandidateCells)
            {
                Game.Board.HighlightCell(candidateCell.Key.Row, candidateCell.Key.Column, candidateCell.Value);
                Game.Board.HighlightNotes(candidateCell.Key.Row, candidateCell.Key.Column, result.CandidateNotes, NoteHighlightType.Info);
            }

            // go through all the cells that have eliminatable notes and highlight accordingly
            foreach (Cell eliminationCell in result.EliminationCells)
            {
                Game.Board.HighlightNotes(eliminationCell.Row, eliminationCell.Column, result.EliminationNotes, NoteHighlightType.Bad);
            }

            ActionManager.Resume(((BitmapBoard)Game.Board).CellsAsJSON());
            Render();
        }

        /// <summary>
        /// Callback/Event from Value Highlight control
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void chkHighlightHavingValue_ButtonClicked(object sender, EventArgs e)
        {
            Board.HighlightValueMode = (HighlightValueMode)chkHighlightHavingValue.CheckState;

            if ((Game.Board != null) && (Board.HighlightValueMode == HighlightValueMode.Off))
                Game.Board.HighlightCellsWithNoteOrNumber(0);
            else
                Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

            Render();
        }

        /// <summary>
        /// Callback/Event from option to remove old notes or not
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void chkRemoveOldNotes_ButtonClicked(Object sender, EventArgs e)
        {
            // inner-board logic needs to know of this option
            Board.RemoveOldNotes = (YesNo)chkRemoveOldNotes.CheckState;

            if ((Game.Board != null) && (Board.RemoveOldNotes == YesNo.Yes))
            {
                ActionManager.Pause();

                Game.Board.RemoveNotes();
                Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

                ActionManager.Resume(((BitmapBoard)Game.Board).CellsAsJSON());
                Render();
            }
        }

        /// <summary>
        /// Callback/Event from validation options changing
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void chkValidationMode_ButtonClicked(Object sender, EventArgs e)
        {
            Board.ValidationMode = (ValidationMode)chkValidationMode.CheckState;
            if ((Game.Board != null) && (Board.ValidationMode != ValidationMode.Off))
            {
                Game.Board.CheckAndMarkDupes();
                Render();
            }
        }

        /// <summary>
        /// Callback/Event from color scheme options changing
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void chkColorScheme_ButtonClicked(Object sender, EventArgs e)
        {
            if (Game.Board != null)
            {
                switch (chkColorScheme.CheckState)
                {
                    case CheckState.Unchecked:
                        btnColorDialog.Visible = false;
                        Colors.Instance.SetLight();
                        break;
                    case CheckState.Checked:
                        btnColorDialog.Visible = false;
                        Colors.Instance.SetDark();
                        break;
                    case CheckState.Indeterminate:
                        btnColorDialog.Visible = true;
                        _frmColors.SetCustom();
                        break;
                }

                // do some common UI element color updates then render boad based on latest choices
                ColorUIUpdateAndRender();
            }
        }

        /// <summary>
        /// Do some common UI element color updates then render boad based on latest choices
        /// </summary>
        public void ColorUIUpdateAndRender()
        {
            pnlCellHighlightPicker.SetButtonColors(Colors.Instance.CellHighlightNone, Colors.Instance.CellHighlightValue, Colors.Instance.CellHighlightSpecial, Colors.Instance.CellHighlightPivot, Colors.Instance.CellHighlightPincer);
            pnlCellHighlightPicker.SetButtonFontColors(Colors.Instance.CellTextOnHighlightNone, Colors.Instance.CellTextOnHighlightValue, Colors.Instance.CellTextOnHighlightSpecial, Colors.Instance.CellTextOnHighlightPivot, Colors.Instance.CellTextOnHighlightPincer);
            pnlNoteHighlightPicker.SetButtonColors(Colors.Instance.NoteHighlightNone, Colors.Instance.NoteHighlightInfo, Colors.Instance.NoteHighlightStrong, Colors.Instance.NoteHighlightWeak, Colors.Instance.NoteHighlightBad);
            pnlNoteHighlightPicker.SetButtonFontColors(Colors.Instance.NoteTextOnHighlightNone, Colors.Instance.NoteTextOnHighlightInfo, Colors.Instance.NoteTextOnHighlightStrong, Colors.Instance.NoteTextOnHighlightWeak, Colors.Instance.NoteTextOnHighlightBad);

            Render();
        }

        /// <summary>
        /// Click the color dialog ellipsis button to pop up the custom colors form (as Modal)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnColorDialog_Click(object sender, EventArgs e)
        {
            _frmColors.ShowDialog();
        }

        /// <summary>
        /// Some keys act funky on Forms and move through various controls regardless of tabstop settings so I am trapping them early, pretending was KeyDown, then eating the key to avoid further form processing 
        /// Also, I am having to remember (but not trap/eat) the modifier keys (alt, shift, ctrl) to pass them down to mouse click events
        /// </summary>
        /// <param name="msg">Don't care, just passed along</param>
        /// <param name="keyData">Which key was pressed</param>
        /// <returns>Force True if I chose to eat the key or stanadard bool if I let it flow into base class processing</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            _modifierKey = ModifierKey.None;

            switch (keyData)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.End:
                case Keys.Home:
                    // send directly to KeyDown since returning True here would prevent KeyDown from getting these keystrokes
                    frmMain_KeyDown(this, new KeyEventArgs(keyData));
                    return true;
                case (Keys.Shift | Keys.ShiftKey):
                    _modifierKey |= ModifierKey.Shift;
                    break;
                case (Keys.Alt | Keys.Menu):
                    _modifierKey |= ModifierKey.Alt;
                    break;
                case (Keys.Control | Keys.ControlKey):
                    _modifierKey |= ModifierKey.Control;
                    break;
            }

            // otherwise, process as normal (which will get non-eaten keys over to KeyDown automatically)
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Handle all the key events we care about, converting their value to built-in enumerations
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms key-event args</param>
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            UserInput input = UserInput.None;
            int numPressed = (int)e.KeyValue;

            // maybe convert numpad nums to normal nums
            if ((e.KeyValue >= (int)Keys.NumPad1) && (e.KeyValue <= (int)Keys.NumPad9))
                numPressed = e.KeyValue - 48;

            // if a non-zero number key, remember it (any better way to do this check?)
            if (int.TryParse(((char)numPressed).ToString(), out numPressed) && (numPressed != 0))
            {
                // convert to custom number enum
                UserInput[] possibleNums = { UserInput.One, UserInput.Two, UserInput.Three, UserInput.Four, UserInput.Five, UserInput.Six, UserInput.Seven, UserInput.Eight, UserInput.Nine };
                input = possibleNums[numPressed - 1];
            }
            else // non-number
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        input = UserInput.UpArrow;
                        break;
                    case Keys.Down:
                        input = UserInput.DownArrow;
                        break;
                    case Keys.Left:
                        input = UserInput.LeftArrow;
                        break;
                    case Keys.Right:
                        input = UserInput.RightArrow;
                        break;
                    case Keys.Home:
                        input = UserInput.Home;
                        break;
                    case Keys.End:
                        input = UserInput.End;
                        break;
                    case Keys.Delete:
                    case Keys.Back:
                        input = UserInput.Delete;
                        break;
                    case Keys.Z:
                        input = UserInput.Z;
                        break;
                    case Keys.Y:
                        input = UserInput.Y;
                        break;
                    case Keys.R:
                        input = UserInput.R;
                        break;
                }
            }

            // if pressed something worthwhile
            if (input != UserInput.None)
            {
                // trap the modifier keys too
                _modifierKey = ModifierKey.None;
                if (e.Shift)
                {
                    // Shift while in Numbers mode is Notes mode (so turn shift on in the modifiers flags)
                    if (!chkNumberKeysMode.Checked)
                        _modifierKey |= ModifierKey.Shift;
                }
                else
                {
                    // Non-Shift while in Notes mode means do note (so turn shift on in the modifiers flags)
                    if (chkNumberKeysMode.Checked)
                        _modifierKey |= ModifierKey.Shift;
                }

                if (e.Alt)
                    _modifierKey |= ModifierKey.Alt;

                if (e.Control)
                {
                    _modifierKey |= ModifierKey.Control;

                    // For Control-#, pretend the user selected that # as focus number
                    if ((input >= UserInput.One) && (input <= UserInput.Nine))
                    {
                        pnlFocusNumber.SimulateClick((int)input);

                        // but don't pass the key press down to cells since don't need ctrl-# to be cell based, just this outer form number selector
                        return;
                    }

                    // ctrl-z and ctrl-y
                    if (input == UserInput.Z)
                    {
                        Undo();
                        return;
                    }
                    else if (input == UserInput.Y)
                    {
                        Redo();
                        return;
                    }
                }

                // if special reset key state
                if (e.Control && e.Alt && e.Shift && (input == UserInput.R))
                {
                    Reset();                    
                    return;
                }

                ActionManager.Pause();

                Game.Board.HandleKeyUserInput(input, _modifierKey);

                // pressed a number OR just deleted main number, exposing potential notes), update highlighting
                if ((numPressed != 0) || (input == UserInput.Delete))
                    Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

                ActionManager.Resume(((BitmapBoard)Game.Board).CellsAsJSON());
                Render();
                CheckForSolved();
            }
        }

        // dabbling with undo/redo.  no major plans yet
        private void Undo()
        {
            ((BitmapBoard)Game.Board).LoadCells(ActionManager.Undo());
            
            Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

            Render();
            CheckForSolved();
        }

        // dabbling with undo/redo.  no major plans yet
        private void Redo()
        {
            ((BitmapBoard)Game.Board).LoadCells(ActionManager.Redo());

            Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

            Render();
            CheckForSolved();
        }

        /// <summary>
        /// Put board back to whatever it had on app start
        /// </summary>
        private void Reset()
        {
            ((BitmapBoard)Game.Board).LoadCells(_initialBoard);

            Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

            Render();
            CheckForSolved();
        }

        /// <summary>
        /// Check if board solved
        /// </summary>
        public void CheckForSolved()
        {
            if (Game.Board.IsBoardSolved())
                MessageBox.Show("Congratulations!", "Solved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// When the Main Form wants to repaint, also Render the latest board
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms paint-event args</param>
        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        /// <summary>
        /// Trapping Mouse Down as a part of the hack to determine Single vs. Double-Click, otherwise Single-Click was always being trapped regardless of trying Double-Click (what is a better way?)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    _isRightClick = true;
                    _isLeftClick = false;
                    _isMiddleClick = false;
                    break;
                case MouseButtons.Left:
                    _isRightClick = false;
                    _isLeftClick = true;
                    _isMiddleClick = false;
                    break;
                case MouseButtons.Middle:
                    _isRightClick = false;
                    _isLeftClick = false;
                    _isMiddleClick = true;
                    break;
                default:
                    _isRightClick = false;
                    _isLeftClick = false;
                    _isMiddleClick = false;
                    break;
            }

            // if first time in here, consider this will be a single click
            if (_isFirstClick)
            {
                _isFirstClick = false;

                // offset since the args x/y are FORM-based and I want the board area instead, which is NOT at 0,0 in the form
                _clickX = ((MouseEventArgs)e).X - _xOffset;
                _clickY = ((MouseEventArgs)e).Y - _yOffset;

                _doubleClickTimer.Start();
            }
            else // another click came in before the click processing in the Timer event dealt with the prior click
            {
                // if second click was fast enough to beat the built in double-click timing, flag as double
                if (_milliseconds < SystemInformation.DoubleClickTime)
                    _isDoubleClick = true;
            }
        }

        /// <summary>
        /// Timer firing to deal with the Single vs. Double-Click hack (did a second click come in fast enough to be considered a double-click?)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms timer-event args</param>
        void doubleClickTimer_Tick(object sender, EventArgs e)
        {
            _milliseconds += 150;

            // if the timer has reached the double click time limit
            if (_milliseconds >= SystemInformation.DoubleClickTime)
            {
                _doubleClickTimer.Stop();

                BitmapBoard board = (BitmapBoard)Game.Board;

                // if clicked in the board area of the form
                if ((_clickX >= 0) && (_clickX < board.BoardSize) && (_clickY >= 0) && (_clickY < board.BoardSize))
                {
                    ActionManager.Pause();

                    if (_isDoubleClick)
                    {
                        ((BitmapBoard)Game.Board).HandlePixelXYClick(UserInput.DoubleClick, _modifierKey, _clickX, _clickY);

                        // maybe just double-clicked a note to become the guess, so see how it should highlight
                        if ((chkHighlightHavingValue.CheckState == (CheckState)HighlightValueMode.NumbersAndNotes) && (Game.Board.SelectedCell.Value == pnlFocusNumber.ActiveValue))
                            Game.Board.HighlightSelectedCell(CellHighlightType.Value);
                        else
                            Game.Board.HighlightSelectedCell(CellHighlightType.None);

                        // if has a guess/given and old notes are to be cleared, do that
                        if (Game.Board.SelectedCell.HasAnswer && (Board.RemoveOldNotes == YesNo.Yes))
                        {
                            Game.Board.RemoveNotes(Game.Board.SelectedCell.Value);
                            Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);
                        }

                        Render();
                        CheckForSolved();
                    }
                    else if (_isRightClick)
                    {
                        ((BitmapBoard)Game.Board).HandlePixelXYClick(UserInput.RightClick, _modifierKey, _clickX, _clickY);

                        // if has a guess value, delete it
                        if (Game.Board.SelectedCell.HasAnswer && (Game.Board.SelectedCell.IsGiven.HasValue && !Game.Board.SelectedCell.IsGiven.Value))
                            frmMain_KeyDown(this, new KeyEventArgs(Keys.Delete));

                        Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

                        Render();
                    }
                    else if (_isLeftClick)
                    {
                        ((BitmapBoard)Game.Board).HandlePixelXYClick(UserInput.LeftClick, _modifierKey, _clickX, _clickY);

                        // if set note on click is on, do that
                        if (chkNotesHold.Checked)
                        {
                            Game.Board.ToggleNote(pnlFocusNumber.ActiveValue);
                            Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);
                        }

                        // do special highlighting if Control WASN'T clicked (Control-Left click is for special strong/week coloring done in HandleXYClick)
                        if ((_modifierKey & ModifierKey.Control) == 0)
                        {
                            if (chkHighlightClickMode.CheckState == (CheckState)HighlightClickMode.Cell)
                                Game.Board.HighlightSelectedCell((CellHighlightType)pnlCellHighlightPicker.ActiveValue);
                            else if ((chkHighlightClickMode.CheckState == (CheckState)HighlightClickMode.Note) && !Game.Board.SelectedCell.HasAnswer)
                                Game.Board.HighlightSelectedNote((NoteHighlightType)pnlNoteHighlightPicker.ActiveValue);
                        }

                        Render();
                    }
                    else if (_isMiddleClick)
                    {
                        ((BitmapBoard)Game.Board).HandlePixelXYClick(UserInput.MiddleClick, _modifierKey, _clickX, _clickY);

                        //// do special highlighting if Control WASN'T clicked (Control-Left click is for special strong/week coloring done in HandleXYClick)
                        //if ((_modifierKey & ModifierKey.Control) == 0)
                        //{
                        //    if (chkHighlightClickMode.CheckState == (CheckState)HighlightClickMode.Cell)
                        //        Game.Board.HighlightCell((CellHighlightType)pnlCellHighlightPicker.ActiveValue);
                        //    else if ((chkHighlightClickMode.CheckState == (CheckState)HighlightClickMode.Note) && !Game.Board.SelectedCell.HasAnswer)
                        //        Game.Board.HighlightSelectedNote((NoteHighlightType)pnlNoteHighlightPicker.ActiveValue);
                        //}

                        Render();
                    }

                    ActionManager.Resume(((BitmapBoard)Game.Board).CellsAsJSON());
                }

                // allow the MouseDown event handler to process clicks again
                _isFirstClick = true;
                _isDoubleClick = false;
                _milliseconds = 0;
            }
        }

        /// <summary>
        /// Needing to reset the state of the active modifier after the click is done so it doesn't think one is still down since KeyUp doesn't get just modifier un-presses
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            _modifierKey = ModifierKey.None;
            if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                _modifierKey |= ModifierKey.Shift;
            if ((ModifierKeys & Keys.Control) == Keys.Control)
                _modifierKey |= ModifierKey.Control;
            if ((ModifierKeys & Keys.Alt) == Keys.Alt)
                _modifierKey |= ModifierKey.Alt;
        }

        /// <summary>
        /// Save the current board
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dlgExport.ShowDialog() == DialogResult.OK)
                File.WriteAllText(dlgExport.FileName, Game.Board.CellsAsJSON());
        }

        /// <summary>
        /// Load a board
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dlgImport.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ((BitmapBoard)Game.Board).LoadCells(File.ReadAllText(dlgImport.FileName));

                    cbxFindResults.Items.Clear();

                    // reset and setup the undo/redo list based on the newly loaded board
                    ActionManager.Reset(((BitmapBoard)Game.Board).CellsAsJSON());

                    Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);
                    Render();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load saved board.\n\nException: " + ex.Message, "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// Form is closing, so save current board behind the scenes
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms closing-event args</param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(_lastBoard, Game.Board.CellsAsJSON());
        }
    }
}
