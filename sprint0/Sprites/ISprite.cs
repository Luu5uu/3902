
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace sprint0.Sprites
{
    public interface ISprite
    {
        public void Update(GameTime gameTime, Rectangle screenBound);
        public void Draw(SpriteBatch spriteBatch);
    }
}
