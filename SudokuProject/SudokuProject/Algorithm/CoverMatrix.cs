using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProj
{
    //The Cover Matrix Class implementation:
    public class CoverMatrix
    {
        //The Cover Matrix
        public byte[,] coverData;

        /// <summary>
        /// A CoverMatrix Constractor that gets a sudoku and creates a cover matrix accordingly.
        /// </summary>
        /// <param name="sudoku"> The sudoku object </param>
        public CoverMatrix(Sudoku sudoku)
        {
            //Creates the cover matrix
            byte[,] coverData = new byte[Config.SIZE * Config.SIZE * Config.SIZE, Config.SIZE * Config.SIZE * Config.CONSTRAINTS];
            
            //Run on the sudoku board
            for (int i = 0; i < Config.SIZE; i++){
                for (int j = 0; j < Config.SIZE; j++){
                    //Run on through each allowed number.
                    for (int num = 1; num <= Config.SIZE; num++){

                        //The current row
                        int row = (Config.SIZE) * j + (Config.SIZE) * (Config.SIZE) * i + (num - 1);

                        //The current constrains column Indices
                        int cellRestriction = (Config.SIZE) * i + j;
                        int ColumnRestriction = Config.SIZE * Config.SIZE + j * Config.SIZE + (num - 1);
                        int RowRestriction = 2 * Config.SIZE * Config.SIZE + i * Config.SIZE + (num - 1);
                        int squareRestriction = i / Config.SQUARE * Config.SQUARE + j / Config.SQUARE;
                        int BoxRestriction = 3 * Config.SIZE * Config.SIZE + squareRestriction * Config.SIZE + num - 1;

                        //All of the current constraints Indices
                        int[] constraintsIndices = {cellRestriction, ColumnRestriction, RowRestriction, BoxRestriction};

                        //If the current place's value is 0 or the current allowed number, fill the constrains cells with 1
                        if (sudoku.board[i, j] == 0 || sudoku.board[i, j] == num){
                            //Fill the cells it the constraints indexes places 
                            foreach (int constraint in constraintsIndices)
                                coverData[row, constraint] = 1;
                        }
                    }
                }
            }

            //Set this cover matrix as the new cover matrix
            this.coverData = coverData; 
        }


        
    }
}
        