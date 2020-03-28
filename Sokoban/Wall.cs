using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Wall
    {
        public int x, y, size;

        public Wall(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }
    }
}
