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
            if (direction == "left" && x > 0)
            {
                x = x - 75;
            }
            if (direction == "up" && y > 0)
            {
                y = y - 75;
            }
            if (direction == "right" && x < 375)
            {
                x = x + 75;
            }
            if (direction == "down" && y < 375)
            {
                y = y + 75;
            }
        }

        public Boolean Collision(Box heroBox)
        {

            Rectangle heroRec = new Rectangle(heroBox.x, heroBox.y, heroBox.size, heroBox.size);

            Rectangle boxRec = new Rectangle(x, y, size, size);


            //if hero.intersectsWith (b) && "direction" = true 
            // b = "direction" //(box will move same direction as hero


            //TODO 

            if (heroRec.IntersectsWith(boxRec))
            {
                /*if (x < 240 && leftArrowDown == true)
                {
                    return true;
                }
                else 
                {
                    return false;
                }*/
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
