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
        public int Defense { get; private set; }
        public float CriticalHitRate { get; private set; }
        public float EvadeRate { get; private set; }
        public Equipment CurrentEquipment { get; private set; }

        public Hero(string name, int initialDamage, int initialDefense, float criticalHitRate, float evadeRate)
        {
            Name = name;
            Damage = initialDamage;
            Defense = initialDefense;
            CriticalHitRate = criticalHitRate;
            EvadeRate = evadeRate;
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
                    CriticalHitRate += equipment.BaseEffectValue * 0.01f;// Преобразуем процентный бонус в десятичный коэффициент
                    break;

                case EquipmentType.Armor:
                    Defense += equipment.BaseEffectValue;                // Увеличиваем защиту
                    EvadeRate += equipment.BaseEffectValue * 0.01f;     // Преобразуем процентный бонус в десятичный коэффициент
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
                    CriticalHitRate -= CurrentEquipment.BaseEffectValue * 0.01f; // Откатываем процентный бонус
                    break;

                case EquipmentType.Armor:
                    Defense -= CurrentEquipment.BaseEffectValue;                 // Возврат прежней защиты
                    EvadeRate -= CurrentEquipment.BaseEffectValue * 0.01f;      // Откатываем процентный бонус
                    break;
            }
        }
    }
}
