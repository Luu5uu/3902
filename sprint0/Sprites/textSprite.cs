using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Net.Mime.MediaTypeNames;

namespace sprint0.Sprites
{
    public class textSprite:ISprite
    {

        SpriteFont _font;
        Vector2 origin;
        Vector2 _position;
        string message;


        public textSprite(SpriteFont font,Vector2 position)
        {
            _font = font;
            _position = position+new Vector2(0,80);
            message = "Zijun Lu \n https://docs.monogame.net/articles/getting_started/content_pipeline/adding_ttf_fonts.html";
            Vector2 textSize = font.MeasureString(message);
            origin = textSize * 0.5f;
        }

        public void Update(GameTime gameTime, Rectangle screenBound)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                _font,                   // font
                message,                // text
                _position,               // position
                Color.White,            // color
                0.0f,                   // rotation
                origin,                 // origin
                1.0f,                   // scale
                SpriteEffects.None,     // effects
                0.0f                    // layerDepth
);
        }
    }
}
