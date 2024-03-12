using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoardModel
{
    public class Cell
    {
        //---------START--------- C# Chess Board 02 board cell classes -------------------------------
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool CurrentlyOccupied { get; set; }
        public bool LegalNextMove { get; set; }

        public Cell(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
        }
        //---------END--------- C# Chess Board 02 board cell classes -------------------------------

    }
}
