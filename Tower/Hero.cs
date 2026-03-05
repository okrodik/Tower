using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    class Hero : Unit
    {
        public string Name { get; set; }

        public Equipment CurrentEquipment { get; private set; }

        // Уровень героя
        public int Level { get; private set; }


    }
}
