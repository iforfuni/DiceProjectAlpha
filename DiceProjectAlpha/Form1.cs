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
        public Player BindedPlayer { get; set; }

        LogicController Controller;

        PictureBox[,] Map;
        public List<PictureBox> diceHolder = new List<PictureBox>();
        public Form1()
        {
            Controller = new LogicController();
            BindedPlayer = Controller.Player1;   
            Map = new PictureBox[Controller.TableWidth, Controller.TableHeight];
            InitializeComponent();

            diceHolder.Add(pictureBox1);
            diceHolder.Add(pictureBox2);
            diceHolder.Add(pictureBox3);
            diceHolder.Add(pictureBox4);
            diceHolder.Add(pictureBox5);
            diceHolder.Add(pictureBox6);
            diceHolder.Add(pictureBox7);
            diceHolder.Add(pictureBox8);
            diceHolder.Add(pictureBox9);
            diceHolder.Add(pictureBox10);
            diceHolder.Add(pictureBox11);
            diceHolder.Add(pictureBox12);

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
            int i = 0;
            foreach (var item in BindedPlayer.Dices)
            {
                diceHolder[i].Image = item.DiceImage;
                i++;
            }
            for (int  j = 0;  j <Controller.TableWidth;  j++)
            {
                for (int k = 0; k < Controller.TableHeight; k++)
                {
                    TileState test = Controller.Map[j, k].State;
                    Image help = Tile.TilePicturePaths[test];
                    Map[j, k].Image = help;
                }
            }
        }
        private void btStartGame_Click(object sender, EventArgs e)
        {
            StartGame();
            btStartGame.Visible = false;
        }
        private void StartGame() 
        {
            SetupMap();
            Controller.GameStateUpdate += OnGameStateUpdate;
            Controller.NewGame();
            
        }
        private void SetupMap() 
        {
            for (int i = 0; i < Controller.TableWidth; i++)
            {
                for (int j = 0; j < Controller.TableHeight; j++)
                {
                    PictureBox tmp = new PictureBox();
                    tmp.Location = new Point(i * 50, j * 50);
                    tmp.Height = 50;
                    tmp.Width = 50;
                    tmp.SizeMode = PictureBoxSizeMode.StretchImage;
                    Map[i, j] = tmp;
                    Controls.Add(tmp);
                    tmp.BringToFront();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (BindedPlayer.Dices.Count > 0)
            {
                BindedPlayer.Dices[0].IsSelected = true;
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            BindedPlayer.Dices[2].IsSelected = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            BindedPlayer.Dices[3].IsSelected = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            BindedPlayer.Dices[4].IsSelected = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            BindedPlayer.Dices[5].IsSelected = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            BindedPlayer.Dices[6].IsSelected = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            BindedPlayer.Dices[7].IsSelected = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            BindedPlayer.Dices[8].IsSelected = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            BindedPlayer.Dices[9].IsSelected = true;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            BindedPlayer.Dices[10].IsSelected = true;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            BindedPlayer.Dices[11].IsSelected = true;
        }
    }
}
