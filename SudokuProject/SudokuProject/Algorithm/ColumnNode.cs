using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    //A Column Node implementation.
    public class ColumnNode : DancingNode
    {
        public int size;
        public String name;

        //Column Node Constractor.
        public ColumnNode(String n) : base()
        {
            size = 0;
            name = n;
            column = this;
        }

        //A function that covers this columnNode's column.
        public void cover()
        {
            removeLeftRight();

            for (DancingNode i = bottom; i != this; i = i.bottom)
            {
                for (DancingNode j = i.right; j != i; j = j.right)
                {
                    j.removeTopBottom();
                    j.column.size--;
                }
            }
        }

        //A function that uncovers this columnNode's column.
        public void uncover()
        {
            for (DancingNode i = top; i != this; i = i.top)
            {
                for (DancingNode j = i.left; j != i; j  = j.left)
                {
                    j.column.size++;
                    j.reinsertTopBottom();
                }
            }

            reinsertLeftRight();
        }
    }

}
