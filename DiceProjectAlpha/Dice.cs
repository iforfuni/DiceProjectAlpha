using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceProjectAlpha
{
    public class Dice
    {
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
                picturelist.Add("Pictures/DiceFaces6.png");

            }
        }
        public int Roll(PictureBox pb) 
        {
            int helper = r.Next(1, 7);
            pb.Image = Image.FromFile(picturelist[helper-1]);
            return helper;

        }  
    }
}
