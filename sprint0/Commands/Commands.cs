using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Commands
{
    public class quitCommand:ICommand
    {
        Game1 _game;

        public quitCommand(Game1 game)
        {
            _game = game;

        }
        public void Execute() {
            _game.Exit();
        }

    }

    public class sprite1Command : ICommand
    {
        Game1 _game;

        public sprite1Command(Game1 game)
        {
            _game = game;

        }
        public void Execute()
        {
            _game.spriteIndex = 0;
        }

    }

    public class sprite2Command : ICommand
    {
        Game1 _game;

        public sprite2Command(Game1 game)
        {
            _game = game;

        }
        public void Execute()
        {
            _game.spriteIndex = 1;
        }

    }

    public class sprite3Command : ICommand
    {
        Game1 _game;

        public sprite3Command(Game1 game)
        {
            _game = game;

        }
        public void Execute()
        {
            _game.spriteIndex = 2;
        }

    }

    public class sprite4Command : ICommand
    {
        Game1 _game;

        public sprite4Command(Game1 game)
        {
            _game = game;

        }
        public void Execute()
        {
            _game.spriteIndex = 3;
        }

    }

}
