using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceProjectAlpha
{
    public partial class Form1 : Form
    {
        LogicController Controller;

        int TableWidth = 15;
        int TableHeight = 21;
        PictureBox[,] Map;
        
        public Form1()
        {
            Map = new PictureBox[TableWidth, TableHeight];
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Character joe = new Character(3);
            MessageBox.Show(joe.Health.ToString());
            joe.TakeDamage(2);
            MessageBox.Show(joe.Health.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Character bob = new Character();
            bob.Attack = 1;
            Character karen = new Character();
            karen.Attack = 3;
            MessageBox.Show("Bob's attack: " + bob.Attack);
            MessageBox.Show("Karen's attack: " + karen.Attack);
            bob.Maxhp = 10;
            bob.Health = 10;
            karen.Health = 3;
            karen.DealDamage(bob);
            MessageBox.Show("Karen attacked bob. Bob's remaining life: " + bob.Health);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Character Juanita = new Character();
            Juanita.Maxhp = 11;
            Juanita.Health = 5;
            MessageBox.Show(Juanita.Health.ToString());
            Juanita.Regen(40);
            MessageBox.Show(Juanita.Health.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Character Carlos = new Character();
            Character John = new Character();
            Carlos.Team = "Red";
            John.Team = "Blue";
            Carlos.Heal = 2;
            John.Maxhp = 5;
            John.Health = 4;
            Carlos.GiveHeal(John);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Character> deck = new List<Character>();
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                Character peepeepoopoo = new Character();
                peepeepoopoo.Maxhp = r.Next(1, 11);
                deck.Add(peepeepoopoo);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Fighter Juan = new Fighter();
            MessageBox.Show("Juan támadási értéke: " + Juan.Attack.ToString());
            Character Karen = new Character();
            Karen.Maxhp = 3;
            Karen.Health = 1;
            Juan.DealDamage(Karen);
            MessageBox.Show(Karen.Health + " ennyi maradt Karenből :)");
        }
        private void Alejandro()
        { 
            for (int i = 0; i < TableWidth; i++)
            {
                for (int j = 0; j < TableHeight; j++)
                { 
                    PictureBox tmp = new PictureBox();
                    tmp.Location = new Point(i*45,j*45);
                    tmp.Height = 45;
                    tmp.Width = 45;
                    tmp.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (j == 0)
                    {
                        tmp.Image = Tile.TilePicturePaths[TileState.Red];
                    }
                    else if (j == TableHeight - 1)
                    {
                        tmp.Image = Tile.TilePicturePaths[TileState.Blue];
                    }
                    else if (j == TableHeight / 2)
                    {
                        tmp.Image = Tile.TilePicturePaths[TileState.Neutral];
                    }
                    else
                    {
                        tmp.Image = Tile.TilePicturePaths[TileState.Nothing];
                    }
                    Map[i, j] = tmp;
                    Controls.Add(tmp);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Tile.Innit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            SpawnUnit(r.Next(0,TableWidth), r.Next(0,TableHeight), TileState.Knight);

        }
        public bool SpawnUnit(int x, int y, TileState mob)
        {
            if (x>TableWidth||y>TableHeight|| x<0 || y<0)
            {
                return false;
            }
            Map[x,y].Image = Tile.TilePicturePaths[mob];

            return true;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnGameStateUpdate(object sender, EventArgs e)
        {
            pictureBox1.Image = Controller.Dices[0].DiceImage;
        }
        private void btStartGame_Click(object sender, EventArgs e)
        {
            StartGame();
            btStartGame.Visible = false;
        }
        private void StartGame() 
        {
            Controller = new LogicController();
            Controller.GameStateUpdate += OnGameStateUpdate;
            Controller.NewGame();
        }

    }
}
