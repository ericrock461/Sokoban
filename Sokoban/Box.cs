using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sokoban
{
    class Box
    {
        //public SolidBrush boxBrush;
        public int x, y, size;

        public Box(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }

        public void Move(string direction)
        {
            if (direction == "left")
            {
                x = x - 5;
            }
            if (direction == "right")
            {
                x = x + 5;
            }
        }

        public Boolean Collision(Box heroBox)
        {

            Rectangle heroRec = new Rectangle(heroBox.x, heroBox.y, heroBox.size, heroBox.size);

            {
                Rectangle boxRec = new Rectangle(x, y, size, size);

                // TODO - if hero goes into box, box moves in direction hero was moving

                if (heroRec.IntersectsWith(boxRec))
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
}
