using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tower
{
    public partial class Form1 : Form
    {
        Panel panel1 = new Panel();
        PictureBox pictureHero = new PictureBox();
        PictureBox pictureEnemy = new PictureBox();

        int SizeHeroEnemy = 200;

        RichTextBox richTextBox = new RichTextBox();

        Timer timerHero = new Timer();
        Timer timerEnemy = new Timer();

        Button btnLut1 = new Button();
        Button btnLut2 = new Button();
        Button btnLut3 = new Button();

        public Form1()
        {
            InitializeComponent();
            WindowsSetting();
            Vivod();
        }

        private void WindowsSetting()
        {
            panel1.BackColor = Color.AliceBlue;
            this.Controls.Add(panel1);
            panel1.Dock = DockStyle.Fill;

            pictureEnemy.BackColor = Color.Blue;
            pictureEnemy.Location = new Point(Right - SizeHeroEnemy, 0);
            pictureEnemy.Size = new Size(SizeHeroEnemy, 1000);

            pictureHero.BackColor = Color.Red;
            pictureHero.Location = new Point(Left, 0);
            pictureHero.Size = new Size(SizeHeroEnemy, 1000);

            richTextBox.BackColor = Color.LemonChiffon;
            richTextBox.Size = new Size(150, 200);
            richTextBox.Location = new Point(this.Width / 2 - richTextBox.Width / 2, 10);

            btnLut1.Location = new Point((this.Width / 2 - btnLut1.Width / 2) - 130, (this.Height / 2) + 100);
            btnLut2.Location = new Point(this.Width / 2 - btnLut2.Width / 2, (this.Height / 2) + 100);
            btnLut3.Location = new Point((this.Width / 2 - btnLut3.Width / 2) + 130, (this.Height / 2) + 100);

            btnLut1.Size = new Size(80, 80);
            btnLut2.Size = new Size(80, 80);
            btnLut3.Size = new Size(80, 80);

            panel1.Controls.Add(pictureHero);
            panel1.Controls.Add(pictureEnemy);
            panel1.Controls.Add(richTextBox);

            panel1.Controls.Add(btnLut1);
            panel1.Controls.Add(btnLut2);
            panel1.Controls.Add(btnLut3);
        }

        private void Vivod() 
        {
            var enemies = new List<Enemy>();

            enemies.Add(Enemy.CreateSkelet());
            enemies.Add(Enemy.CreateGoblin());
            enemies.Add(Enemy.CreateOrk());
            enemies.Add(Enemy.CreateBossTrol());

            foreach (var enemy in enemies)
                Console.WriteLine($"{enemy.Name}: Урон={enemy.Damage}, Броня={enemy.Armor}, Здоровье={enemy.Health}, Скорость атака={enemy.AttackSpeed}, Критический урон множитель={enemy.CritDamage}, Шанс крита={enemy.CritChance}, Уклоение={enemy.Evasion}");

            // Создаем коллекцию предметов брони
            var armors = new List<Armor>();
            armors.Add(Armor.CreateArmorRareHelmet());    // Редкий шлем
            armors.Add(Armor.CreateArmorEpicChest());     // Эпическая грудная пластина
            armors.Add(Armor.CreateArmorLegendaryGloves()); // Легендарные перчатки

            // Перебираем коллекцию и выводим информацию о каждом предмете брони
            foreach (var armor in armors)
            {
                Console.WriteLine($"{armor.Name}: Категория={armor.EquipmentType}, Броня={armor.DefenseBonus}, Вес={armor.Weight}, Дополнительный бонус={armor.AdditionalStatBoost}");
            }
        }
    }
}
