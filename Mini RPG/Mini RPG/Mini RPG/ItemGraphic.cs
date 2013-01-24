using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mini_RPG
{
    class ItemGraphic : GraphicalObject
    {
        Item item;
        public ItemGraphic(string _textureName, Vector2 _position)
            : base(_textureName, _position)
        {
            item.GetItemFromLibrary(_textureName);
        }
        public void GetItemFromLibrary(string itemName)
        {

        }
    }
}
