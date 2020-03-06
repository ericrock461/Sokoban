using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sokoban
{
    class Dot
    {
        public int x, y, size;

        public Dot(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }

        public Boolean Collision(Dot box)
        {

            // TODO - game win when all dots are covered by boxes

            Rectangle dotRec = new Rectangle(x, y, size, size);


            Rectangle boxRec = new Rectangle(box.x, box.y, box.size, box.size);


            if (boxRec.IntersectsWith(dotRec))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
