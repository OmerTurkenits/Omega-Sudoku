using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject.UI
{
    public static class MainMenu
    {
        /// <summary>
        /// A function that displays the main menu UI of the program.
        /// </summary>
        public static void show()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Press '1' to input from keyboard\nPress '2' to input from file");
            Console.WriteLine("--------------------------------------");
            Console.Write("Choice: ");
            Console.ForegroundColor = Config.MAIN_COLOR;
        }

        /// <summary>
        /// A function that displays the text header of the main menu UI.
        /// </summary>
        public static void displayHeader()
        {
            Console.ForegroundColor = Config.MAIN_COLOR;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("  ______                                 __                ______                 __          __                      ______           __                             \r\n /      \\                               |  \\              /      \\               |  \\        |  \\                    /      \\         |  \\                            \r\n|  ▓▓▓▓▓▓\\______ ____   ______   ______ | ▓▓ _______     |  ▓▓▓▓▓▓\\__    __  ____| ▓▓ ______ | ▓▓   __ __    __     |  ▓▓▓▓▓▓\\ ______ | ▓▓__     __  ______   ______  \r\n| ▓▓  | ▓▓      \\    \\ /      \\ /      \\ \\▓ /       \\    | ▓▓___\\▓▓  \\  |  \\/      ▓▓/      \\| ▓▓  /  \\  \\  |  \\    | ▓▓___\\▓▓/      \\| ▓▓  \\   /  \\/      \\ /      \\ \r\n| ▓▓  | ▓▓ ▓▓▓▓▓▓\\▓▓▓▓\\  ▓▓▓▓▓▓\\  ▓▓▓▓▓▓\\  |  ▓▓▓▓▓▓▓     \\▓▓    \\| ▓▓  | ▓▓  ▓▓▓▓▓▓▓  ▓▓▓▓▓▓\\ ▓▓_/  ▓▓ ▓▓  | ▓▓     \\▓▓    \\|  ▓▓▓▓▓▓\\ ▓▓\\▓▓\\ /  ▓▓  ▓▓▓▓▓▓\\  ▓▓▓▓▓▓\\\r\n| ▓▓  | ▓▓ ▓▓ | ▓▓ | ▓▓ ▓▓    ▓▓ ▓▓   \\▓▓   \\▓▓    \\      _\\▓▓▓▓▓▓\\ ▓▓  | ▓▓ ▓▓  | ▓▓ ▓▓  | ▓▓ ▓▓   ▓▓| ▓▓  | ▓▓     _\\▓▓▓▓▓▓\\ ▓▓  | ▓▓ ▓▓ \\▓▓\\  ▓▓| ▓▓    ▓▓ ▓▓   \\▓▓\r\n| ▓▓__/ ▓▓ ▓▓ | ▓▓ | ▓▓ ▓▓▓▓▓▓▓▓ ▓▓         _\\▓▓▓▓▓▓\\    |  \\__| ▓▓ ▓▓__/ ▓▓ ▓▓__| ▓▓ ▓▓__/ ▓▓ ▓▓▓▓▓▓\\| ▓▓__/ ▓▓    |  \\__| ▓▓ ▓▓__/ ▓▓ ▓▓  \\▓▓ ▓▓ | ▓▓▓▓▓▓▓▓ ▓▓      \r\n \\▓▓    ▓▓ ▓▓ | ▓▓ | ▓▓\\▓▓     \\ ▓▓        |       ▓▓     \\▓▓    ▓▓\\▓▓    ▓▓\\▓▓    ▓▓\\▓▓    ▓▓ ▓▓  \\▓▓\\\\▓▓    ▓▓     \\▓▓    ▓▓\\▓▓    ▓▓ ▓▓   \\▓▓▓   \\▓▓     \\ ▓▓      \r\n  \\▓▓▓▓▓▓ \\▓▓  \\▓▓  \\▓▓ \\▓▓▓▓▓▓▓\\▓▓         \\▓▓▓▓▓▓▓       \\▓▓▓▓▓▓  \\▓▓▓▓▓▓  \\▓▓▓▓▓▓▓ \\▓▓▓▓▓▓ \\▓▓   \\▓▓ \\▓▓▓▓▓▓       \\▓▓▓▓▓▓  \\▓▓▓▓▓▓ \\▓▓    \\▓     \\▓▓▓▓▓▓▓\\▓▓      \r\n                                                                                                                                                                      \r\n                                                                                                                                                                      \r\n                                                                                                                                                                      \r\n");
            Console.ForegroundColor = Config.CONSOLE_WHITE;
            Console.WriteLine();
        }

    }
}
