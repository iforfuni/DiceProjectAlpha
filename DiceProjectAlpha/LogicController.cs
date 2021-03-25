using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceProjectAlpha
{
    public class LogicController
    {
        public int TableWidth { get; set; } = 15;
        public int TableHeight { get; set; } = 21;
        public int DiceStartAmount { get; set; } = 2;
        
        public event EventHandler GameStateUpdate; 
        
        
        public List<Dice> Dices = new List<Dice>();
        public Tile[,] Map;
        
        public LogicController()
        {
            Tile.Innit();
            Map = new Tile[TableWidth, TableHeight];
        }
        public void NewGame()
        {
            FillDiceList();
            SetupMap();
            DiceRoll();

            GameStateUpdate.Invoke(this,EventArgs.Empty);
        }

        private void FillDiceList()
        { 

            for (int i = 0; i < DiceStartAmount; i++)
            {
                Dices.Add(new Dice());
            }
        }
        private void DiceRoll()
        {
            foreach (var dice in Dices)
            {
                dice.Roll();
            }
        }
        private void SetupMap()
        { 
            
        }
    }
}
