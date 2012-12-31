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
        List<Keys> PressedKeys = new List<Keys>();
        public KeyboardManager()
        {

        }
        public bool CheckKeyState(Keys key, bool ClickOnceButton)
        {
            ks=Keyboard.GetState();
            for (int i = 0; i < PressedKeys.Count; i++)
            {
                if (ks.IsKeyUp(PressedKeys[i])) 
                {
                    PressedKeys.Remove(PressedKeys[i]);
                    i--;
                }
            }
            if (ClickOnceButton == false)
            {
                if (ks.IsKeyDown(key))
                {
                    return true;
                }
            }
            else
            {
                foreach (Keys pressedKey in PressedKeys)
                {
                    if (pressedKey == key)
                    {
                        return false;
                    }
                }
                if (ks.IsKeyDown(key))
                {
                    PressedKeys.Add(key);
                    return true;
                }
            }
            return false;
        }
    }
}
