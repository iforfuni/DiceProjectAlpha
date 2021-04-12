using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceProjectAlpha
{
    public enum TileState
    {
        Red,
        Blue,
        Neutral,
        Nothing,
    }
    
    public class Tile
    {

        public Character CharacterOnTile { get; set; }

        public TileState State { get; set; }

        static bool initialize = false;
        public static Dictionary<TileState,Image> TilePicturePaths = new Dictionary<TileState,Image>();

        public Tile(TileState state)
        {
            State = state;
        }
        public static void Innit()
        {
            if (initialize == false)
            {
                TilePicturePaths.Add(TileState.Red, Image.FromFile("Pictures/RedPathOriginal.png"));
                TilePicturePaths.Add(TileState.Blue, Image.FromFile("Pictures/BluePathOriginal.png"));
                TilePicturePaths.Add(TileState.Neutral, Image.FromFile("Pictures/NeutralPathOriginal.png"));
                TilePicturePaths.Add(TileState.Nothing, Image.FromFile("Pictures/NothingPathOriginal.png"));
                initialize = true;
            }
        }
    }
}
