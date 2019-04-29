using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    /// <summary>
    /// Pretty ineffecient undo/redo approach, but it was super simple
    /// </summary>
    public static class ActionManager
    {
        private static int Index { get; set; }                          // where in the list of actions we are referencing
        private static List<string> _cellStates = new List<string>();   // list of states to play back and forth per undo/redo call

        public static bool Paused { get; set; }
        /// <summary>
        /// Ctor to setup index to deal with the first time the board is loaded (that acts as a action to store at Index 0
        /// </summary>
        static ActionManager()
        {
            Index = -1;
        }

        /// <summary>
        /// Clear the undo/redo history and set it anew as the passed in state
        /// </summary>
        /// <param name="cellState">State to set after clearing</param>
        public static void Reset(string cellState)
        {
            Index = -1;
            _cellStates.Clear();
            AddState(cellState);
        }

        /// <summary>
        /// Add another cell state to the history (but clearing future if undo/redo were being done between the last add and this one)
        /// </summary>
        /// <param name="cellState">JSON of the cells state</param>
        public static void AddState(string cellState)
        {
            if (Paused)
                return;
            
            // if another action, chop off the redo future since this would branch it and I don't want to deal with that
            if ((Index > -1) && (_cellStates.Count-1 > Index))
                _cellStates.RemoveRange(Index+1, _cellStates.Count - 1 - Index );

            _cellStates.Add(cellState);
            Index++;
        }

        /// <summary>
        /// Uwind the state pointer and return that JSON
        /// </summary>
        /// <returns>New state to use and render</returns>
        public static string Undo()
        {
            if (--Index < 0)
                Index = 0;
                
            return _cellStates[Index];
        }

        /// <summary>
        /// Advance the state pointer and return that JSON
        /// </summary>
        /// <returns>New state to use and render</returns>
        public static string Redo()
        {
            if (++Index > _cellStates.Count - 1)
                Index = _cellStates.Count - 1;

            return _cellStates[Index];
        }
    }
}
