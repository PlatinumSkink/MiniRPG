using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Mini_RPG
{
    class KeyboardManager
    {
        KeyboardState ks;
        public KeyboardManager()
        {

        }
        public bool CheckKeyState(Keys key)
        {
            ks=Keyboard.GetState();
            if (ks.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }
    }
}
