using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Sprites
{
    internal class dynamicAniSprite:ISprite
    {
        private Texture2D _texture;
       // Rectangle _rect;
        Vector2 _position;
        Vector2 originCenter;

        public List<Rectangle> frames;
        public int currentFrame;

        public TimeSpan delay;
        public TimeSpan timer;

        float speed = 3.0f;
        private int dirY = 1;
        SpriteEffects effect = SpriteEffects.FlipHorizontally;

        public Rectangle spriteBound
        {
            get
            {
                return new Rectangle(
                    (int)(_position.X - originCenter.X),
                    (int)(_position.Y - originCenter.Y),
                    64,
                    128
                );
            }
        }


        public dynamicAniSprite(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;

            frames = new List<Rectangle>();
            //frames.Add(new Rectangle(2, 262, 64, 128));
            frames.Add(new Rectangle(70, 262, 64, 128));
            frames.Add(new Rectangle(138, 262, 62, 128));
            currentFrame = 0;

            originCenter = new Vector2(frames[0].Width, frames[0].Height) * 0.5f;

            delay = TimeSpan.FromSeconds(0.5);
            timer = TimeSpan.Zero;
        }



        public void Update(GameTime gameTime, Rectangle screenBound)
        {
            timer += gameTime.ElapsedGameTime;
            if (timer >= delay)
            {
                timer -= delay;
                currentFrame++;

                if (currentFrame >= frames.Count)
                {
                    currentFrame = 0;
                }
            }

            if (spriteBound.Right >= screenBound.Right)
            {
                dirY = -1;
                effect = SpriteEffects.None;
            }
            if (spriteBound.Left <= screenBound.Left)
            {
                dirY = 1;
                effect = SpriteEffects.FlipHorizontally;
            }

            _position.X += dirY * speed;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,
                _position,
                frames[currentFrame],
                Color.White,
                0.0f,
                originCenter,
                1.0f,
                effect,
                0.0f);
        }

    }
}
