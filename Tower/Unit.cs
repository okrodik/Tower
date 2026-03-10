using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    class Unit
    {
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Health { get; set; }
        public float AttackSpeed { get; set; }
        public float CritDamage { get; set; }
        public int CritChance { get; set; }
        public int Evasion { get; set; }

        public Unit(int damage = 5, int armor = 0, int health = 25, float attackSpeed = 1.0f, float critDamage = 1.1f, int critChance = 5, int evasion = 5)
        {
            this.Damage = damage;
            this.Armor = armor;
            this.Health = health;
            this.AttackSpeed = attackSpeed;
            this.CritDamage = critDamage;
            this.CritChance = critChance;
            this.Evasion = evasion;
        }
    }

    class Enemy : Unit
    {
        // Дополнительные переменные, характерные именно для врагов
        public string Name { get; private set; }          // Имя врага
        public bool IsAlive { get; private set; }         // Флаг живости

        // Конструктор Enemy, принимающий дополнительные параметры

        // Конструктор Enemy (закрыт, чтобы вызвать только через статические методы)
        private Enemy(string name, int damage, int armor, int health, float attackSpeed, float critDamage, int critChance, int evasion)
            : base(damage, armor, health, attackSpeed, critDamage, critChance, evasion)
        {
            this.Name = name;
            this.IsAlive = true;
        }


        public static Enemy CreateSkelet()
        {
            return new Enemy("Скелет", 5, 3, 20, 1.5f, 1.1f, 10, 10); // Самый слабый
        }

        public static Enemy CreateGoblin()
        {
            return new Enemy("Гоблин", 8, 5, 30, 2f, 1.5f, 10, 5); // Хитрый и быстрый
        }

        public static Enemy CreateOrk()
        {
            return new Enemy("Орк", 13, 5, 50, 1.0f, 1.2f, 10, 3); // Орк сильнее гоблина
        }

        public static Enemy CreateBabayka()
        {
            return new Enemy("Бабайка", 20, 5, 150, 1.0f, 1.4f, 20, 5); // Самый слабый
        }

        public static Enemy CreateZombie()
        {
            return new Enemy("Зомби", 30, 5, 200, 2f, 1.5f, 10, 5); // Хитрый и быстрый
        }

        public static Enemy CreateVampir()
        {
            return new Enemy("Вампир", 150, 5, 300, 1.0f, 1.2f, 10, 3); // Орк сильнее гоблина
        }

        public static Enemy CreateBossDracon()
        {
            return new Enemy("Босс Дракон", 20, 10, 1000, 1.0f, 1.4f, 20, 5); // Босс 8го этажа
        }

        public static Enemy CreateBossTroll()
        {
            return new Enemy("Босс троль", 20, 5, 80, 1.0f, 1.4f, 20, 5); // Босс 4го этажа
        }

        public static Enemy CreateBossUnicorn()
        {
            return new Enemy("Босс единорог", 20, 5, 100, 1.0f, 1.4f, 20, 5); // Босс 8го этажа
        }

        public static Enemy CreateBossAbaahu()
        {
            return new Enemy("Босс абааьы", 20, 5, 2000, 1.0f, 1.4f, 20, 5); // Босс 4го этажа
        }
    }
}
