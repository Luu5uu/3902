
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace sprint0.Sprites
{
    internal class staticAniSprite:ISprite
    {

        private Texture2D _texture;
        Vector2 _position;
        Vector2 origin;

        public List<Rectangle> frames;
        public int currentFrame;

        public TimeSpan delay;
        public TimeSpan timer;
        

        public staticAniSprite(Texture2D texture,Vector2 position)
        {
            _texture = texture;
            _position = position;

            frames = new List<Rectangle>();
            frames.Add(new Rectangle(338, 2, 64, 128));
            frames.Add(new Rectangle(406,2, 64, 128));
            frames.Add(new Rectangle(474,2,64, 128));
            currentFrame = 0;

            origin = new Vector2(frames[0].Width, frames[0].Height) * 0.5f;

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
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,
                _position,
                frames[currentFrame],
                Color.White,
                0.0f,
                origin,
                1.0f,
                SpriteEffects.None,
                0.0f);
        }

    }
    }

