using SudokuProject.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    internal class Program
    {
        //The Programs Entry Point:
        static void Main(string[] args)
        {
            //increasing the console char limit to 'Config.CHAR_LIMIT'
            Console.SetIn(new StreamReader(Console.OpenStandardInput(Config.CHAR_LIMIT)));

            //Increasing the console's window size to 'CONSOLE_WIDTH', 'CONSOLE_HEIGHT'
            Console.SetWindowSize(Config.CONSOLE_WIDTH, Config.CONSOLE_HEIGHT);

            //Changing the console's title text
            Console.Title = Config.TITLE_TEXT;

            //Shows the menu.
            MainMenu.show();

            //Starts program's process.
            SudokuSolverModule.start();
        }

    }
}
