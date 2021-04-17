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
        public List<Dice> Dices = new List<Dice>();

        public event EventHandler DiceChanged;

        public Player()
        {
            FillDiceList();

        }

        public void DiceRoll()
        {
            foreach (var dice in Dices)
            {
                dice.Roll();
            }
        }
        public void DiceSelect(int index)
        {
            if (Dices.Count > index)
            {
                if (IsMulligan)
                {
                    Dices[index].IsSelected = !Dices[index].IsSelected;
                    DiceChanged.Invoke(this, EventArgs.Empty);
                }
            }

        }
        public void RerollSelectedDices()
        {
            foreach (var dice in Dices)
            {
                if (dice.IsSelected)
                {
                    dice.IsSelected = false;
                    dice.Roll();
                    DiceChanged.Invoke(this, EventArgs.Empty);
                                        
                }
            }
        }
        public void MulliganEnder()
        {
            IsMulligan = false;
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
