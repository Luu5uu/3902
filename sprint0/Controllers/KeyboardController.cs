using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Commands;

namespace sprint0.Controllers
{
    public class KeyboardContoller : IController
    {
        KeyboardState previous = Keyboard.GetState();
        public int spritIndex = 0;
        ICommand _quit, _s1, _s2, _s3, _s4;

        public KeyboardContoller(ICommand quit, ICommand s1, ICommand s2, ICommand s3, ICommand s4)
        {
            _quit = quit;
            _s1 = s1;
            _s2 = s2;
            _s3 = s3;
            _s4 = s4;
        }


        public KeyboardContoller()
        {
            previous = Keyboard.GetState();
        }

        public void Update(Game1 game)
        {
            KeyboardState current = Keyboard.GetState();

            if (isPressed(current, Keys.NumPad0) || isPressed(current, Keys.D0)) _quit.Execute();
            else if (isPressed(current, Keys.NumPad1) || isPressed(current,Keys.D1))
            {
                _s1.Execute();
            }
            else if (isPressed(current, Keys.NumPad2) || isPressed(current, Keys.D2))
            {
                _s2.Execute();

            }
            else if (isPressed(current, Keys.NumPad3) || isPressed(current, Keys.D3))
            {
                _s3.Execute();

            }
            else if (isPressed(current, Keys.NumPad4) || isPressed(current, Keys.D4))
            {
                _s4.Execute();

            }

            previous = current;

        }

        public bool isPressed(KeyboardState current, Keys key)
        {
            return current.IsKeyDown(key) && previous.IsKeyUp(key);
        }
    }
}
