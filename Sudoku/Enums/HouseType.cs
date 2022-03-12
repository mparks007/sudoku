using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sudoku
{
    public enum HouseType
    {
        [Description("N/A")]
        None,
        [Description("Row")]
        Row,
        [Description("Column")]
        Column,
        [Description("Block")]
        Block
    }
}
