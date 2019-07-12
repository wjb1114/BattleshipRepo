using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Ship
    {
        string name;
        int size;

        public Ship(string shipName, int shipSize)
        {
            size = shipSize;
            name = shipName;
        }
    }
}
