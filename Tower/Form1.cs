using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tower.Properties;
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

        ProgressBar progressBarHero = new ProgressBar();
        ProgressBar progressBarEnemy = new ProgressBar();

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

        Hero myHero { get; set; }

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
            pictureEnemy.Size = new Size(SizeHeroEnemy, SizeHeroEnemy);
            pictureEnemy.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureHero.BackColor = Color.Red;
            pictureHero.Location = new Point(Left, 0);
            pictureHero.Size = new Size(SizeHeroEnemy, SizeHeroEnemy);
            pictureHero.SizeMode = PictureBoxSizeMode.StretchImage;

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

            timer1.Interval = 1000;
            timer2.Interval = 1000;

            timer1.Tick += timer1_Tick;
            timer2.Tick += timer2_Tick;

            progressBarHero.Location = new Point((SizeHeroEnemy / 2) - (progressBarHero.Width / 2), 250);
            progressBarHero.BackColor = Color.AntiqueWhite;

            progressBarEnemy.Location = new Point(Right - progressBarEnemy.Width - (progressBarEnemy.Width / 2), 250);
            progressBarEnemy.BackColor = Color.AntiqueWhite;

            panel1.Controls.Add(progressBarHero);
            panel1.Controls.Add(progressBarEnemy);
        }

        private void Enemys() 
        {
            var enemies = new List<Enemy>();

            enemies.Add(Enemy.CreateSkelet());
            enemies.Add(Enemy.CreateGoblin());
            enemies.Add(Enemy.CreateOrk());
            enemies.Add(Enemy.CreateBossTroll());

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
            myHero = new Hero("Игрок", 10, 50000, 10, 0.1f, 0.2f, 10, 0.05f);

            SelectWeapon(random.Next(0, 29));



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

            progressBarHero.Maximum = HealthHero;
            progressBarEnemy.Maximum = HealthEnemy;

            progressBarHero.Value = HealthHero;
            progressBarEnemy.Value = HealthEnemy;
            gameToStartToStop(true);
            
        }

        private void SelectEnemy(int x)
        {
            switch (x)
            { 
                case 0:
                    enemies.Add(Enemy.CreateSkelet());
                    pictureEnemy.Image = Resources.skelet;
                    break;
                case 1:
                    enemies.Add(Enemy.CreateGoblin());
                    pictureEnemy.Image = Resources.goblin;
                    break;
                case 2:
                    enemies.Add(Enemy.CreateOrk());
                    pictureEnemy.Image = Resources.ork;
                    break;
                case 3:
                    enemies.Add(Enemy.CreateBabayka());
                    pictureEnemy.Image = Resources.babayka;
                    break;
                case 4:
                    enemies.Add(Enemy.CreateZombie());
                    pictureEnemy.Image = Resources.zombie;
                    break;
                case 5:
                    enemies.Add(Enemy.CreateVampir());
                    pictureEnemy.Image = Resources.vampir;
                    break;
                case 6:
                    enemies.Add(Enemy.CreateBossDracon());
                    pictureEnemy.Image = Resources.dracon;
                    break;
                case 7:
                    enemies.Add(Enemy.CreateBossTroll());
                    pictureEnemy.Image = Resources.troll;
                    break;
                case 8:
                    enemies.Add(Enemy.CreateBossUnicorn());
                    pictureEnemy.Image = Resources.unicorn;
                    break;
                case 9:
                    enemies.Add(Enemy.CreateBossAbaahu());
                    pictureEnemy.Image = Resources.abaahu;
                    break;
                default:
                    break;
            }

            VivodEnemys(enemies);
        }

        private void SelectWeapon(int x)
        {
            switch (x)
            {
                case 0:
                    var sword = Weapon.CreateWeaponRareSword(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(sword);
                    break;
                case 1:
                    var dagger = Weapon.CreateWeaponRareDagger(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(dagger);
                    break;
                case 2:
                    var club = Weapon.CreateWeaponRareClub(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(club);
                    break;
                case 3:
                    var estoc = Weapon.CreateWeaponRareEstoc(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(estoc);
                    break;
                case 4:
                    var axe = Weapon.CreateWeaponRareAxe(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(axe);
                    break;

                case 5:
                    var sword1 = Weapon.CreateWeaponEpicSword(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(sword1);
                    break;
                case 6:
                    var dagger1 = Weapon.CreateWeaponEpicDagger(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(dagger1);
                    break;
                case 7:
                    var club1 = Weapon.CreateWeaponEpicClub(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(club1);
                    break;
                case 8:
                    var estoc1 = Weapon.CreateWeaponEpicEstoc(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(estoc1);
                    break;
                case 9:
                    var axe1 = Weapon.CreateWeaponEpicAxe(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(axe1);
                    break;


                case 10:
                    var sword2 = Weapon.CreateWeaponLegendarySword(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(sword2);
                    break;
                case 11:
                    var dagger2 = Weapon.CreateWeaponLegendaryDagger(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(dagger2);
                    break;
                case 12:
                    var club2 = Weapon.CreateWeaponLegendaryClub(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(club2);
                    break;
                case 13:
                    var estoc2 = Weapon.CreateWeaponLegendaryEstoc(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(estoc2);
                    break;
                case 14:
                    var axe2 = Weapon.CreateWeaponLegendaryAxe(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(axe2);
                    break;



                case 15:
                    var helmet = Armor.CreateArmorRareHelmet(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(helmet);
                    break;
                case 16:
                    var chest = Armor.CreateArmorRareChest(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(chest);
                    break;
                case 17:
                    var gloves = Armor.CreateArmorRareGloves(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(gloves);
                    break;
                case 18:
                    var pants = Armor.CreateArmorRarePants(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(pants);
                    break;
                case 19:
                    var boots = Armor.CreateArmorRareBoots(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(boots);
                    break;

                case 20:
                    var helmet1 = Armor.CreateArmorEpicHelmet(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(helmet1);
                    break;
                case 21:
                    var chest1 = Armor.CreateArmorEpicChest(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(chest1);
                    break;
                case 22:
                    var gloves1 = Armor.CreateArmorEpicGloves(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(gloves1);
                    break;
                case 23:
                    var pants1 = Armor.CreateArmorEpicPants();
                    break;
                case 24:
                    var boots1 = Armor.CreateArmorEpicBoots(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(boots1);
                    break;

                case 25:
                    var helmet2 = Armor.CreateArmorEpicHelmet(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(helmet2);
                    break;
                case 26:
                    var chest2 = Armor.CreateArmorLegendaryChest(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(chest2);
                    break;
                case 27:
                    var gloves2 = Armor.CreateArmorLegendaryGloves(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(gloves2);
                    break;
                case 28:
                    var pants2 = Armor.CreateArmorLegendaryPants(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(pants2);
                    break;
                case 29:
                    var boots2 = Armor.CreateArmorLegendaryBoots(); // Низкое качество, небольшая прибавка атаки
                    myHero.ChangeEquipment(boots2);
                    break;

                default:
                    break;
            }
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

        private void gameToStartToStop(bool trues)
        {
            if (trues)
            {
                timer1.Start();
                timer2.Start();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
            }
        }

        private void WinToEnemy()
        {
            if (HealthEnemy <= 0)
            {
                gameToStartToStop(false);
                MessageBox.Show("YOU WIN!");
                LutBox();
            }

            if (HealthHero <= 0)
            {
                gameToStartToStop(false);
                MessageBox.Show("YOU LoSE!");
            }
        }


        private void timer1_Tick(object sender, EventArgs e) //hero timer
        {
            if (ArmorEnemy > 0)
            {
                ArmorEnemy -= DamageHero;
            }
            else
            {
                HealthEnemy -= DamageHero;

                if (HealthEnemy < progressBarEnemy.Minimum)
                {
                    progressBarEnemy.Value = progressBarEnemy.Minimum;
                }
                else
                {
                    progressBarEnemy.Value = HealthEnemy;
                }
            }

            Console.WriteLine(NameEnemy.ToString() + ": " + HealthEnemy.ToString());

            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ArmorHero > 0)
            {
                ArmorHero -= DamageEnemy;
            }
            else
            {
                HealthHero -= DamageEnemy;

                if (HealthHero < progressBarHero.Minimum)
                {
                    progressBarHero.Value = progressBarHero.Minimum;
                }
                else
                {
                    progressBarHero.Value = HealthHero;
                }
            }

            Console.WriteLine(NameHero.ToString() + ": " + HealthHero.ToString());

            WinToEnemy();
        }

        private void LutBox()
        {
            var imageni1 = Resources.estoc_epic;
            var imageni2 = Resources.axe_epic;
            var imageni3 = Resources.estoc_legendary;

            Bitmap resizedImage1 = new Bitmap(imageni1, btnLut1.Width, btnLut1.Height);
            Bitmap resizedImage2 = new Bitmap(imageni2, btnLut2.Width, btnLut2.Height);
            Bitmap resizedImage3 = new Bitmap(imageni3, btnLut3.Width, btnLut3.Height);

            btnLut1.Image = resizedImage1;
            btnLut2.Image = resizedImage2;
            btnLut3.Image = resizedImage3;
        }
    }
}
