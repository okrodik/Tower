using System;
using System.Collections.Generic;
using System.IO.Ports;
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

        public Hero(string name = "name", int damage = 5, int armor = 0, int health = 25, float attackSpeed = 1.0f, float critDamage = 1.1f, int critChance = 5, int evasion = 5)
        {
            this.Name = name;
            this.Damage = damage;
            this.Armor = armor;
            this.Health = health;
            this.AttackSpeed = attackSpeed;
            this.CritDamage = critDamage;
            this.CritChance = critChance;
            this.Evasion = evasion;
        }
    }

    class Weapon : Hero()
    {

    }
}
