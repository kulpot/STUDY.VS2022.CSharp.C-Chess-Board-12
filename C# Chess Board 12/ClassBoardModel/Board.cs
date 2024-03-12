using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoardModel
{
    public class Board
    {
        //---------START--------- C# Chess Board 02 board cell classes -------------------------------
        // the size of the board usually 8x8
        public int Size { get; set; }

        // 2d array of type cell.
        public Cell[,] theGrid { get; set; }
        
        // constructor
        public Board(int s)
        {
            // initial size of the board is defined by parameter s.
            Size = s;

            // create a new 2D array of type cell.
            theGrid = new Cell[Size, Size];

            // fill the 2D array with new Cells, each with unique x and y coordinates.
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }
        //---------END--------- C# Chess Board 02 board cell classes -------------------------------

        //--------START---------- C# Chess Board Game Part 07 challenges ------------------------------------------

        public bool isSafe(int x, int y)
        {
            if(x < 0 || x >= Size || y < 0 || y >= Size)
            {
                // Console.WriteLine("Pos " + x + ", " + y + " is NOT safe.");
                return false;
            }
            else
            {
                // Console.WriteLine("Pos " + x + ", " + y + " is safe.");
                return true;
            }
        }

        //--------END---------- C# Chess Board Game Part 07 challenges ------------------------------------------

        //-------START----------- C# Chess Board 03 next legal moves -------------------------------------------------
        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            // step 1 - clear all previous legal moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }

            // step 2 - find all legal moves and mark the cells as "legal"

            switch (chessPiece)
            {
                case "Knight":
                    if(isSafe(currentCell.RowNumber -2, currentCell.ColumnNumber -1))
                    theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    break;

                case "King":
                    if(isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1))
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 0].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    break;

                case "Rook":
                    break;

                case "Bishop":
                    break;

                case "Queen":
                    break;

                case "Pawn":
                    if (isSafe(currentCell.RowNumber - 0, currentCell.ColumnNumber + 1))
                    theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    break;
                default:
                    break;
            }
            //--------START---------- C# Chess Board Game 06 place piece -------------------------------------------------------
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
            //---------END--------- C# Chess Board Game 06 place piece -------------------------------------------------------

        }
        //--------END---------- C# Chess Board 03 next legal moves -------------------------------------------------

    }
}
