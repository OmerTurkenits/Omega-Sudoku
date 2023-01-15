using System;
using SudokuProject.Readers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{ 
    //A Command Line Reader implementation:
    public class CLIReader : Reader
    {
        public override string read()
        {
            String input;
            Console.WriteLine("Input From Keyboard:");
            input = Console.ReadLine();

            //Calls the convert function on the input.
            return input;
        }
    }
}
