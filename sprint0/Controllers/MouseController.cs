using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using sprint0.Commands;

namespace sprint0.Controllers
{
    internal class MouseController:IController
    {
        MouseState previous = Mouse.GetState();
        ICommand _quit, _s1, _s2, _s3, _s4;
        public MouseController(ICommand quit, ICommand s1, ICommand s2, ICommand s3, ICommand s4)
        {
            _quit = quit;
            _s1 = s1;
            _s2 = s2;
            _s3 = s3;
            _s4 = s4;
        }


        public void Update(Game1 game)
        {
            int halfWidth = game.screenBound.Width /2;
            int halfHeight = game.screenBound.Height / 2;

            MouseState current = Mouse.GetState();
            int mouseX = current.X;
            int mouseY = current.Y;

            if(current.RightButton == ButtonState.Pressed) _quit.Execute();
            else if (mouseX < halfWidth && mouseY < halfHeight && isPressed(current)) _s1.Execute();
            else if(mouseX > halfWidth && mouseY < halfHeight && isPressed(current)) _s2.Execute();
            else if(mouseX < halfWidth && mouseY > halfHeight && isPressed(current)) _s3.Execute();
            else if (mouseX > halfWidth && mouseY > halfHeight && isPressed(current)) _s4.Execute();
            previous = current;

        }

        public bool isPressed(MouseState current)
        {
            return current.LeftButton == ButtonState.Pressed && previous.LeftButton == ButtonState.Released;
        }
    }
}
