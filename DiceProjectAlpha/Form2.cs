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
    public partial class Form2 : Form
    {
        public Player BindedPlayer { get; set; }

        LogicController Controller;

        PictureBox[,] Map;
        public List<PictureBox> diceHolder = new List<PictureBox>();
        public Form2(LogicController controller)
        {
            Controller = controller;
            BindedPlayer = Controller.Player2;   
            Map = new PictureBox[Controller.TableWidth, Controller.TableHeight];

            InitializeComponent();
            Controller.GameStateUpdate += OnGameStateUpdate;
            BindedPlayer.DiceChanged += OnDiceChange;

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
            //this.FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
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
                    if (Controller.Map[j, k].CharacterOnTile is null)
                    {
                        TileState test = Controller.Map[j, k].State;
                        Image help = Tile.TilePicturePaths[test];
                        Map[j, k].Image = help;
                    }
                    else
                    {
                        Map[j, k].Image = Controller.Map[j,k].CharacterOnTile.Portrait;
                    }
                    
                }
            }
            if (BindedPlayer == Controller.CurrentPlayer)
            {
                TurnIndicator.Visible = true;
            }
            else if (BindedPlayer != Controller.CurrentPlayer)
            {
                TurnIndicator.Visible = false;
            }
        }
        private void OnDiceChange(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in BindedPlayer.Dices)
            {
                diceHolder[i].Image = item.DiceImage;
                i++;
                SelectionChange(i,item.IsSelected);
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
        #region UselessShit

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BindedPlayer.DiceSelect(0);
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            BindedPlayer.DiceSelect(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            BindedPlayer.DiceSelect(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            BindedPlayer.DiceSelect(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            BindedPlayer.DiceSelect(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            BindedPlayer.DiceSelect(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            BindedPlayer.DiceSelect(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            BindedPlayer.DiceSelect(7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            BindedPlayer.DiceSelect(8);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            BindedPlayer.DiceSelect(9);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            BindedPlayer.DiceSelect(10);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            BindedPlayer.DiceSelect(11);
        }

        private void buttonMulligan_Click(object sender, EventArgs e)
        {
            BindedPlayer.RerollSelectedDices();
            BindedPlayer.MulliganEnder();
        }
        private void SelectionChange(int index, bool l)
        {
            switch (index)
            {
                case 1: 
                    PB1selecter.Visible = l;
                    break;
                case 2: 
                    PB2selecter.Visible = l;
                    break;
                case 3:
                    PB3selecter.Visible = l;
                    break;
                case 4:
                    PB4selecter.Visible = l;
                    break;
                case 5:
                    PB5selecter.Visible = l;
                    break;
                case 6:
                    PB6selecter.Visible = l;
                    break;
                case 7:
                    PB7selecter.Visible = l;
                    break;
                case 8:
                    PB8selecter.Visible = l;
                    break;
                case 9:
                    PB9selecter.Visible = l;
                    break;
                case 10:
                    PB10selecter.Visible = l;
                    break;
                case 11:
                    PB11selecter.Visible = l;
                    break;
                case 12:
                    PB12selecter.Visible = l;
                    break;
                default:
                    break;
            }
        }
#endregion 
        private void BT_EndTurn_Click(object sender, EventArgs e)
        {
            Controller.EndTurn(BindedPlayer);
            
        }
    }
}
