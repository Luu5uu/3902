
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;




namespace sprint0.Sprites
{
    public class staticNonAniSprite:ISprite
    {
        Texture2D _texture;
        Rectangle _rect;
        Vector2 _position;
        Vector2 originCenter;
 
        public staticNonAniSprite(Texture2D texture,Vector2 position)
        {
            _texture = texture;
            _rect = new Rectangle(2, 2, 64, 128);
            _position = position;
            originCenter = new Vector2(_rect.Width, _rect.Height) * 0.5f;
        }

        public void Update(GameTime gameTime,Rectangle screenBound)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,
                _position, 
                _rect,
                Color.White,
                0.0f,
                originCenter,
                1.0f,
                SpriteEffects.None,
                0.0f);
        }

        
    }
}
