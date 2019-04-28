using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public sealed class Fonts
    {
        private static readonly Lazy<Fonts> lazy = new Lazy<Fonts>(() => new Fonts());

        public static Fonts Instance { get { return lazy.Value; } }

        public string Answer { get; set; }
        public string Note { get; set; }

        private Fonts()
        {
            Answer = "Century Gothic";
            Note = "Arial";
        }
    }
}
