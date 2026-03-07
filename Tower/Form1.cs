using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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

        Random random = new Random();

        List<Enemy> enemies = new List<Enemy>();

        Timer timer1 = new Timer();
        Timer timer2 = new Timer();

        string NameHero = "";
        int DamageHero = 0;
        int ArmorHero = 0;
        int HealthHero = 0;
        float AttackSpeedHero = 0.0f;
        float CritDamageHero = 0.0f;
        int CritChanceHero = 0;
        float EvasionHero = 0;

        string NameEnemy = "";
        int DamageEnemy = 0;
        int ArmorEnemy = 0;
        int HealthEnemy = 0;
        float AttackSpeedEnemy = 0.0f;
        float CritDamageEnemy = 0.0f;
        int CritChanceEnemy = 0;
        float EvasionEnemy = 0;

        public Form1()
        {
            InitializeComponent();
            WindowsSetting();
            startGame();
        }

        private void WindowsSetting()
        {
            this.Size = new Size(1280, 720);

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


            timer1.Interval = 100;
            timer2.Interval = 100;

            timer1.Tick += timer1_Tick;
            timer2.Tick += timer2_Tick;

        }

        private void Enemys() 
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
            armors.Add(Armor.CreateArmorLegendaryGloves()); // Легендарные перчатки
            armors.Add(Armor.CreateArmorEpicChest());     // Эпическая грудная пластина
            armors.Add(Armor.CreateArmorLegendaryChest()); // Легендарные перчатки

            // Перебираем коллекцию и выводим информацию о каждом предмете брони
            foreach (var armor in armors)
            {
                Console.WriteLine($"{armor.Name}: Редкость={armor.Rarity}, Категория={armor.Category}, Защита={armor.BaseEffectValue}, Дополнительный бонус к скорости атаки={armor.StatBoost}");
            }

            // Создаем коллекцию предметов брони
            var weapon = new List<Weapon>();

            weapon.Add(Weapon.CreateWeaponEpicAxe());    // Редкий шлем
            weapon.Add(Weapon.CreateWeaponLegendaryEstoc()); // Легендарные перчатки

            // Перебираем коллекцию и выводим информацию о каждом предмете брони
            foreach (var armor in armors)
            {
                Console.WriteLine($"{armor.Name}: Редкость={armor.Rarity}, Категория={armor.Category}, Урон={armor.BaseEffectValue}, Шанс к критическому урону={armor.StatBoost}");
            }
        }

        private void Heroes()
        {
            // Создаем героя
            Hero myHero = new Hero("Игрок", 10, 5, 10, 0.1f, 0.2f, 10, 0.05f);

            // Создание оружия и брони
            Weapon sword = Weapon.CreateWeaponEpicAxe(); // Низкое качество, небольшая прибавка атаки
            Armor helmet = Armor.CreateArmorEpicChest(); // Минимальное улучшение защиты
            Weapon sword2 = Weapon.CreateWeaponLegendaryAxe();

            NameHero = myHero.Name;
            DamageHero = myHero.Damage;
            HealthHero = myHero.Health;
            ArmorHero = myHero.Armor;
            AttackSpeedHero = myHero.AttackSpeed;
            CritDamageHero = myHero.CritDamage;
            CritChanceHero = myHero.CritChance;
            EvasionHero = myHero.Evasion;

            richTextBox.Text += $"Имя героя {NameHero.ToString()}. \n";
            richTextBox.Text += $"Урон: {DamageHero.ToString()}. \n";
            richTextBox.Text += $"Жизнь:  {HealthHero.ToString()}. \n";
            richTextBox.Text += $"Броня:  {ArmorHero.ToString()}. \n";
            richTextBox.Text += $"Скорость атаки: {AttackSpeedHero.ToString()}. \n";
            richTextBox.Text += $"Множитель критической атаки: {CritDamageHero.ToString()}. \n";
            richTextBox.Text += $"Шанс критической атаки: {CritChanceHero.ToString()}. \n";
            richTextBox.Text += $"Шанс уклонения:{EvasionHero.ToString()}. \n";
        }


        private void startGame()
        {
            int x = random.Next(0, 9);
            Heroes();
            SelectEnemy(x);
            gameToStart();
            
        }

        private void SelectEnemy(int x)
        {
            switch (x)
            { 
                case 0:
                    enemies.Add(Enemy.CreateSkelet());
                    break;
                case 1:
                    enemies.Add(Enemy.CreateGoblin());
                    break;
                case 2:
                    enemies.Add(Enemy.CreateOrk());
                    break;
                case 3:
                    enemies.Add(Enemy.CreateBabayka());
                    break;
                case 4:
                    enemies.Add(Enemy.CreateZombie());
                    break;
                case 5:
                    enemies.Add(Enemy.CreateVampir());
                    break;
                case 6:
                    enemies.Add(Enemy.CreateBossDracon());
                    break;
                case 7:
                    enemies.Add(Enemy.CreateBossTrol());
                    break;
                case 8:
                    enemies.Add(Enemy.CreateBossUnicorn());
                    break;
                case 9:
                    enemies.Add(Enemy.CreateBossAbaahu());
                    break;
                default:
                    break;
            }

            VivodEnemys(enemies);
        }

        private void VivodEnemys(List<Enemy> enemi)
        {
            foreach (var enemy in enemi)
            {
                NameEnemy = enemy.Name;
                DamageEnemy = enemy.Damage;
                HealthEnemy = enemy.Health;
                ArmorEnemy = enemy.Armor;
                AttackSpeedEnemy = enemy.AttackSpeed;
                CritDamageEnemy = enemy.CritDamage;
                CritChanceEnemy = enemy.CritChance;
                EvasionEnemy = enemy.Evasion;

                richTextBox.Text += $"Имя врага {NameEnemy.ToString()}. \n";
                richTextBox.Text += $"Урон: {DamageEnemy.ToString()}. \n";
                richTextBox.Text += $"Жизнь:  {HealthEnemy.ToString()}. \n";
                richTextBox.Text += $"Броня:  {ArmorEnemy.ToString()}. \n";
                richTextBox.Text += $"Скорость атаки: {AttackSpeedEnemy.ToString()}. \n";
                richTextBox.Text += $"Множитель критической атаки: {CritDamageEnemy.ToString()}. \n";
                richTextBox.Text += $"Шанс критической атаки: {CritChanceEnemy.ToString()}. \n";
                richTextBox.Text += $"Шанс уклонения:{EvasionEnemy.ToString()}. \n";
            }
        }

        private void gameToStart()
        {
            timer1.Start();
            timer2.Start();
        }

        private void WinToEnemy()
        {
            
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            HealthEnemy -= DamageHero;

            richTextBox.Text = HealthEnemy.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
