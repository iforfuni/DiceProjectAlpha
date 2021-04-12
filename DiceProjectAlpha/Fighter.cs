using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceProjectAlpha
{
    
    public class Fighter : Character
    {
        public override Image Portrait { get => portrait; set => portrait = value; }
        private Image portrait;
        public Fighter()
        {
            Attack = 30;
            Health = 30;
            Portrait = Image.FromFile("Pictures/Fighter.png");

        }

        
    }
    
}
