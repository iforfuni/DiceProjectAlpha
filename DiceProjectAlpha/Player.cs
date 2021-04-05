using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceProjectAlpha
{
    
    public class Player
    {
        public bool IsMulligan { get; set; } = true;
        public Player()
        {
            FillDiceList();

        }
        public List<Dice> Dices = new List<Dice>();
        public void DiceRoll()
        {
            foreach (var dice in Dices)
            {
                dice.Roll();
            }
        }
        public void DiceSelect(int index) 
        {
            if (Dices.Count>index)
            {
                if (IsMulligan)
                {
                    Dices[index].IsSelected = !Dices[index].IsSelected;
                }
            }
            
        }
        private void FillDiceList()
        {

            for (int i = 0; i < LogicController.DiceStartAmount; i++)
            {
                Dices.Add(new Dice());
            }
        }

    }
}
