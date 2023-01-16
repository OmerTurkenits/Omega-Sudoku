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
        public abstract string read();

    }
}
