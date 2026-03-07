using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{


    class Hero
    {
        public string Name { get; set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }
        public int Health { get; private set; }
        public float AttackSpeed { get; private set; }
        public float CritDamage { get; private set; }
        public int CritChance { get; private set; }
        public float Evasion { get; private set; }

        public Equipment CurrentEquipment { get; private set; }

        public Hero(string name, int initialDamage,int initialHealth, int initialDefense, float initialAttackSpeed, float initialCriticalHitRate, int initialCritChance, float initialEvasion)
        {
            Name = name;
            Damage = initialDamage;
            Armor = initialDefense;
            Health = initialHealth;
            AttackSpeed = initialAttackSpeed;
            CritDamage = initialCriticalHitRate;
            CritChance = initialCritChance;
            Evasion = initialEvasion;
        }

        // Функция для смены снаряжения
        public void ChangeEquipment(Equipment newEquipment)
        {
            if (CurrentEquipment != null)
            {
                // Восстанавливаем предыдущие характеристики
                RevertPreviousEquipmentEffects();
            }

            // Применяем новое снаряжение
            ApplyNewEquipment(newEquipment);

            // Запоминаем текущее снаряжение
            CurrentEquipment = newEquipment;
        }

        // Внутренняя функция для применения характеристик снаряжения
        private void ApplyNewEquipment(Equipment equipment)
        {
            switch (equipment.Type)
            {
                case EquipmentType.Weapon:
                    Damage += equipment.BaseEffectValue;                 // Увеличиваем урон
                    CritDamage += equipment.StatBoost * 0.01f;// Преобразуем процентный бонус в десятичный коэффициент
                    break;

                case EquipmentType.Armor:
                    Armor += equipment.BaseEffectValue;                // Увеличиваем защиту
                    Evasion += equipment.StatBoost * 0.01f;
                    break;
            }
        }

        // Внутренняя функция для возврата предыдущих характеристик
        private void RevertPreviousEquipmentEffects()
        {
            switch (CurrentEquipment.Type)
            {
                case EquipmentType.Weapon:
                    Damage -= CurrentEquipment.BaseEffectValue;                  // Возврат прежнего урона
                    CritDamage -= CurrentEquipment.StatBoost * 0.01f; // Откатываем процентный бонус
                    break;

                case EquipmentType.Armor:
                    Armor -= CurrentEquipment.BaseEffectValue;                 // Возврат прежней защиты
                    Evasion -= CurrentEquipment.StatBoost * 0.01f;      // Откатываем процентный бонус
                    break;
            }
        }
    }
}
