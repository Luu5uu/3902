using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Sprites
{
    internal class dynamicNonAniSprite:ISprite
    {

        Texture2D _texture;
        Rectangle _rect;
        Vector2 _position;
        Vector2 originCenter;
        float speed = 5.0f;
        private int dirY = 1;
        SpriteEffects effect = SpriteEffects.None;

        public Rectangle spriteBound
        {
            get
            {
                return new Rectangle(
                    (int)(_position.X - originCenter.X),
                    (int)(_position.Y - originCenter.Y),
                    _rect.Width,
                    _rect.Height
                );
            }
        }



        public dynamicNonAniSprite(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _rect = new Rectangle(204, 654, 64, 128);
            _position = position;
            originCenter = new Vector2(_rect.Width, _rect.Height) * 0.5f;


        }

        

        public void Update(GameTime gameTime, Rectangle screenBound)
        {
            if (spriteBound.Bottom >= screenBound.Bottom)
            {
                dirY = -1;
                effect = SpriteEffects.None;

            }
            if (spriteBound.Top <= screenBound.Top)
            {
                dirY = 1;
                effect = SpriteEffects.FlipVertically;
            }

            _position.Y += dirY * speed;

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
                effect,
                0.0f);
        }

    }
}
