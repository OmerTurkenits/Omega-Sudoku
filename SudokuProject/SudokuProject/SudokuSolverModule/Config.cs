using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    //Project Configurations:
    public class Config
    {
        //The allowed sizes of sudokus.
        public static int[] ALLOWED_SIZES = {9, 16, 25};
        //The size of the current sudoku.
        public static int SIZE;
        //The number of constrains a sudoku has.
        public const int CONSTRAINTS = 4;
        //The square size of the current sudoku.
        public static int SQUARE;
        //Console's char limit.
        public const int CHAR_LIMIT = 8192;
        //Console's window width.
        public const int CONSOLE_WIDTH = 200;
        //Console's window height.
        public const int CONSOLE_HEIGHT = 50;
        //Console's Title text.
        public const string TITLE_TEXT = "Omer's Sudoku Solver";
        //Console white color.
        public const ConsoleColor CONSOLE_WHITE = ConsoleColor.White;
        //Console cyan color.
        public const ConsoleColor CONSOLE_CYAN = ConsoleColor.Cyan;

    }
}
