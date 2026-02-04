using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Commands;
using sprint0.Controllers;
using sprint0.Sprites;


namespace sprint0
{
    public class Game1 : Core
    {

        private Texture2D rei; // Texture
        SpriteFont font;

        ISprite text;

        private ISprite currentSprite;
        List<ISprite> sprites;
        public int spriteIndex;

        private KeyboardContoller keyboard;
        private MouseController mouse;

        public Rectangle screenBound;


        public Game1() : base("AWSL", 1280, 720, false)
        {

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {

            

            // Get the screen's center location
            var pos = new Vector2(Window.ClientBounds.Width*0.5f, Window.ClientBounds.Height*0.5f);
            rei = Content.Load<Texture2D>("image/rei");
            font = Content.Load<SpriteFont>("File");

            text = new textSprite(font,pos);
            sprites = new List<ISprite>();
            sprites.Add(new staticNonAniSprite(rei, pos));
            sprites.Add(new staticAniSprite(rei, pos));
            sprites.Add(new dynamicNonAniSprite(rei, pos));
            sprites.Add( new dynamicAniSprite(rei, pos));

            currentSprite = sprites[0];

            ICommand quit = new quitCommand(this);
            ICommand s1 = new sprite1Command(this);
            ICommand s2 = new sprite2Command(this);
            ICommand s3 = new sprite3Command(this);
            ICommand s4 = new sprite4Command(this);

            //236


            keyboard = new KeyboardContoller(quit, s1, s2, s3, s4);
            mouse = new MouseController(quit,s1,s2,s3,s4);

            

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || Keyboard.GetState().IsKeyDown(Keys.NumPad0))
                Exit();

               screenBound = new Rectangle(
                0,
                0,
                GraphicsDevice.PresentationParameters.BackBufferWidth,
                GraphicsDevice.PresentationParameters.BackBufferHeight
               );


            keyboard.Update(this);
            mouse.Update(this);
            currentSprite = sprites[spriteIndex];
            currentSprite.Update(gameTime,screenBound);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSeaGreen);
            

            // TODO: Add your drawing code here

            SpriteBatch.Begin();
            text.Draw(SpriteBatch);
            currentSprite.Draw(SpriteBatch);
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}