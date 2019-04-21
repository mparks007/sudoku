using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class BoardAction
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Number { get; set; }
        public ActionType ActionType { get; set; }
    }

    public static class ActionManager
    {
        public static int Index { get; set; }
        private static List<BoardAction> _actions = new List<BoardAction>();

        public static void Add(BoardAction action)
        {
            Index++;
            _actions.Add(action);
        }

        public static void Undo()
        {
            Index--;
            if (Index < 0)
            { 
                Index = 0;
                return;
            }

            var lastAction = _actions[Index];
            switch (lastAction.ActionType)
            {
                case ActionType.SetGuess:
                    Game.Board.SelectCellAtRowCol(lastAction.Row, lastAction.Column);
                    Game.Board.HandleKeyUserInput(UserInput.Delete, 0);
                    break;
            }
        }

        public static void Redo()
        {
            if (Index > _actions.Count - 1)
            {
                Index = _actions.Count - 1;
                return;
            }

            var lastAction = _actions[Index];
            switch (lastAction.ActionType)
            {
                case ActionType.Delete:
                    //Game.Board.SelectCellAtRowCol(lastAction.Row, lastAction.Column);
                    //Game.Board.HandleKeyUserInput(UserInput.Delete, 0);
                    break;
            }
        }
    }
}
