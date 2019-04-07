using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class HtmlBoard : Board
    {
        private string _html;

        public string Html
        {
            get
            {
                if (_html == "")
                    throw new InvalidOperationException("No board exists");

                return _html;
            }
        }
        public HtmlBoard(int size) : base()
        {
            //_boardImage = new Bitmap(size, size);
        }

        public override void Render()
        {

        }

        public string ToHtml()
        {
            return "";
        }
    }
}
