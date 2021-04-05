using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceProjectAlpha
{
    public enum DiceValues
    {
        Move,
        Mana,
        Save,
        Land,
        Resource,
    }
    public class Dice
    {
        public bool IsSelected { get; set; } = false;
        public Image DiceImage { get; set; }
        public DiceValues DiceValue { get; set; }
        static Random r = new Random();
        static List<string> picturelist;
        public Dice()
        {
            if (picturelist == null)
            {
                picturelist = new List<string>();
                picturelist.Add("Pictures/DiceFaces1.png");
                picturelist.Add("Pictures/DiceFaces2.png");
                picturelist.Add("Pictures/DiceFaces3.png");
                picturelist.Add("Pictures/DiceFaces4.png");
                picturelist.Add("Pictures/DiceFaces5.png");
            }
        }
        public void Roll()
        {
            int helper = r.Next(1, 6);
            DiceImage = Image.FromFile(picturelist[helper - 1]);
            DiceValue = DiceValueConverter(helper);
        }
        private DiceValues DiceValueConverter(int value)
        {
            switch (value)
            {
                case 1: 
                    return DiceValues.Land;
                case 2:
                    return DiceValues.Mana;
                case 3:
                    return DiceValues.Move;
                case 4:
                    return DiceValues.Save;
                case 5:
                    return DiceValues.Resource;
                default: 
                    return DiceValues.Land;
            }
        }
    }
}
