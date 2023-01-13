using SudokuProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    //A Reader abstract class implementation:
    public abstract class Reader
    {
        public abstract byte[,] read();

        //A function that converts a string to a sudoku board.
        public static byte[,] convert(String input)
        {
            double size = Math.Sqrt(input.Length);

            //Checks if the size of the sudoku isn't in the ALLOWED_SIZES list.
            if (!Config.ALLOWED_SIZES.Contains((int)size))
                throw new InvalidSudokuSizeException();

            //Creates the matrix.
            byte[,] board = new byte[(int)size, (int)size];

            //Sets the sudoku's values.
            Config.SIZE = (int)size;
            Config.SQUARE = (int)Math.Sqrt((int)size);

            //Input the values from the string to the matrix.
            for (int i = 0; i < (int)size; i++)
                for (int j = 0; j < (int)size; j++)
                    board[i,j] = (byte)(input[i * (int)size + j] - '0');
           
            return board;
        }

    }
}
