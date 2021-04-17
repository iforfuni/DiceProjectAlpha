using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceProjectAlpha
{
    public class LogicController
    {

        public int TableWidth { get; set; } = 15;
        public int TableHeight { get; set; } = 21;
        public static int DiceStartAmount { get; set; } = 2;
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentPlayer { get; set; }

        public event EventHandler GameStateUpdate;


        public Tile[,] Map;

        public LogicController()
        {
            Tile.Innit();
            Map = new Tile[TableWidth, TableHeight];
            Player1 = new Player();
            Player2 = new Player();
            CurrentPlayer = Player1;

        }
        public void NewGame()
        {
            SetupMap();
            DiceRoll();
            GameStateUpdate.Invoke(this, EventArgs.Empty);
        }

        private void DiceRoll()
        {
            CurrentPlayer.DiceRoll();

        }
        private void SetupMap()
        {
            for (int i = 0; i < TableWidth; i++)
            {
                for (int j = 0; j < TableHeight; j++)
                {
                    if (j==0)
                    {
                        Map[i, j] = new Tile(TileState.Red);
                    }
                    else if (j == TableHeight - 1)
                    {
                        Map[i, j] = new Tile(TileState.Blue);
                    }
                    else if(j == TableHeight/2)      
                    {
                        Map[i, j] = new Tile(TileState.Neutral);
                    }
                    else
                    {
                        Map[i, j] = new Tile(TileState.Nothing);
                    }
                }
            }
        }
        public void SummonMonster(int x, int y, Character mob)
        {
            
            Map[x, y].CharacterOnTile = mob;
            GameStateUpdate.Invoke(this, EventArgs.Empty);

        }
        public void EndTurn(Player player)
        {
            if (CurrentPlayer==player)
            {
                if (Player1 == CurrentPlayer)
                {
                    CurrentPlayer = Player2;
                }
                else
                {
                    CurrentPlayer = Player1;
                }
            }
            GameStateUpdate.Invoke(this,EventArgs.Empty);
        }
    }
}
