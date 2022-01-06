using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Snake_Game
{
    class Fruit
    {
        public int FruitX { get; set; }
        public int FruitY { get; set; }
        public int OldFruitX { get; set; }
        public int OldFruitY { get; set; }
        public string FruitSymbol { get; set; }

        public Fruit(string fruitSymbol, int fruitX, int fruitY)
        {
            FruitSymbol = fruitSymbol;
            FruitX = fruitX;
            FruitY = fruitY;
        }
    }
}
