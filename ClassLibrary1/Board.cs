using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardModel
{
    public class Board
    {
        // standard board is 8x8
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }

        // constructor for board
        public Board(int s)
        {
            // initial size of board defined by s
            Size = s;

            // create a new 2D array of cells
            theGrid = new Cell[Size, Size];

            // fill the 2D array with new Cells, each with unique x and y coordinates 
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

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

            // step 2 - find all legal moves and make the cells "legal"
            switch (chessPiece)
            {
                case "Knight":
                    if (IsSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1))
                    {
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    }

                    if (IsSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1))
                    {
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    }

                    if (IsSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1))
                    {
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    }

                    if (IsSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1))
                    {
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    }

                    if (IsSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2))
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    }

                    if (IsSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2))
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    }

                    if (IsSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2))
                    {
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    }

                    if (IsSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2))
                    {
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    }
                    break;

                case "King":
                    break;

                case "Rook":
                    break;

                case "Bishop":
                    break;

                case "Queen":
                    break;

                default:
                    break;
            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }

        private bool IsSafe(int row, int column)
        {
            bool rowCheck = row >= 0 && row < Size;
            bool columnCheck = column >= 0 && column < Size;
            return rowCheck && columnCheck;
        }
    }
}
