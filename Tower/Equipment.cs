using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    enum EquipmentType
    {
        Weapon,   // Оружие
        Armor     // Броня
    }

    enum RarityType
    {
        Rare,   // Оружие
        Epic,
        Legendary     // Броня
    }

    enum Category
    {
        Helmet, 
        Chest,
        Gloves, 
        Pants, 
        Boots,

        Sword, 
        Dagger, 
        Club, 
        Estoc, 
        Axe
    }

    class Equipment
    {
        public string Name { get; set; }                   // Название снаряжения
        public EquipmentType Type { get; set; }            // Тип снаряжения (оружие или броня)
        public RarityType Rarity { get; set; }             // Ранг редкости
        public Category Category { get; set; }             // Ранг редкости
        public int BaseEffectValue { get; set; }           // Основное влияние снаряжения (урон или броня)
        public float StatBoost { get; set; }     // Дополнительный статистический прирост (например, критический шанс)

        public Equipment(string name, EquipmentType type, RarityType rarity, Category category, int effectValue, float statBoost)
        {
            Name = name;
            Type = type;
            Rarity = rarity;
            Category = category;
            BaseEffectValue = effectValue;
            StatBoost = statBoost;
        }
    }

    class Armor : Equipment 
    {
        public Armor(string name, RarityType rarity, Category category, int defenseBonus, float dodgeProbability)
            : base(name, EquipmentType.Armor, rarity, category, defenseBonus, dodgeProbability)
        {
            
        }

        public static Armor CreateArmorRareHelmet()
        {
            return new Armor("Редкий Шлем", RarityType.Rare, Category.Helmet, 10, 5); // Средняя защита
        }

        public static Armor CreateArmorRareChest()
        {
            return new Armor("Редкая Грудь", RarityType.Rare, Category.Chest, 15, 7); // Хорошая защита тела
        }

        public static Armor CreateArmorRareGloves()
        {
            return new Armor("Редкие Перчатки", RarityType.Rare, Category.Gloves, 8, 4); // Умеренный защитный потенциал рук
        }

        public static Armor CreateArmorRarePants()
        {
            return new Armor("Редкие Штаны", RarityType.Rare, Category.Pants, 12, 6); // Хорошо защищают ноги
        }

        public static Armor CreateArmorRareBoots()
        {
            return new Armor("Редкие Ботинки", RarityType.Rare, Category.Boots, 7, 3); // Прочная обувь
        }

        public static Armor CreateArmorEpicHelmet()
        {
            return new Armor("Эпический Шлем", RarityType.Epic, Category.Helmet, 15, 8); // Высокая защита головы
        }

        public static Armor CreateArmorEpicChest()
        {
            return new Armor("Эпическая Грудь", RarityType.Epic, Category.Chest, 20, 10); // Максимальная защита корпуса
        }

        public static Armor CreateArmorEpicGloves()
        {
            return new Armor("Эпические Перчатки", RarityType.Epic, Category.Gloves, 12, 6); // Повышенная прочность перчаток
        }

        public static Armor CreateArmorEpicPants()
        {
            return new Armor("Эпические Штаны", RarityType.Epic, Category.Pants, 18, 9); // Отличная защита ног
        }

        public static Armor CreateArmorEpicBoots()
        {
            return new Armor("Эпические Ботинки", RarityType.Epic, Category.Boots, 10, 5); // Надёжная обувь высокого качества
        }

        public static Armor CreateArmorLegendaryHelmet()
        {
            return new Armor("Легендарный Шлем", RarityType.Legendary, Category.Helmet, 20, 10); // Исключительная защита головы
        }

        public static Armor CreateArmorLegendaryChest()
        {
            return new Armor("Легендарная Грудь", RarityType.Legendary, Category.Chest, 25, 12); // Максимально эффективная защита туловища
        }

        public static Armor CreateArmorLegendaryGloves()
        {
            return new Armor("Легендарные Перчатки", RarityType.Legendary, Category.Gloves, 15, 8); // Лучшая защита кистей
        }

        public static Armor CreateArmorLegendaryPants()
        {
            return new Armor("Легендарные Штаны", RarityType.Legendary, Category.Pants, 22, 11); // Оптимальная защита нижних конечностей
        }

        public static Armor CreateArmorLegendaryBoots()
        {
            return new Armor("Легендарные Ботинки", RarityType.Legendary, Category.Boots, 12, 6); // Идеальная пара обуви
        }

    }
}
