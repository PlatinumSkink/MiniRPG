using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    class Item
    {
        string use = "";
        int amount = 0;
        Texture2D symbol;

        public string AffectedStat
        {
            get { return use; }
            set { use = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public Item(string _textureName)
        {
            GetItemFromLibrary(_textureName);
        }
        public Item(string _textureName, string _AffectedStat, int _Amount)
        {
            AffectedStat = _AffectedStat;
            Amount = _Amount;
            Library.Load(_textureName);
        }

        public void GetItemFromLibrary(string itemName)
        {

        }
    }
}
