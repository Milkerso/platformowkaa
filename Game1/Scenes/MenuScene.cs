using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnakeClassic_Csharp_dev.pl
{
    class MenuScene : DrawableGameComponent
    {
        Game game;

        Texture2D PlayButtonTexture;
        Texture2D ExitButtonTexture;
        Texture2D LogoTexture;

        Rectangle recPlayButton;
        Rectangle recExitButton;
        Rectangle recLogo;

        Color PlayButtonColor = Color.White;
        Color ExitButtonColor = Color.White;

        MouseState mouseState;
        Rectangle Cursor;

        public MenuScene(Game game) : base(game)
        {
            this.game = game;
            LoadContent();
        }

        protected override void LoadContent()
        {
            PlayButtonTexture = game.Content.Load<Texture2D>("PlayButton");
            ExitButtonTexture = game.Content.Load<Texture2D>("ExitButton");
            LogoTexture = game.Content.Load<Texture2D>("button");
        }
      
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(LogoTexture, recLogo, Color.White);
            spriteBatch.Draw(PlayButtonTexture, recPlayButton, PlayButtonColor);
            spriteBatch.Draw(ExitButtonTexture, recExitButton, ExitButtonColor);
            spriteBatch.End();
        }

        public void Update()
        {
            CalculateItemsPositions();
            CalculateItemsSize();
            UpdateCursorPosition();
            ButtonsEvents();
        }

        //methods

        private void CalculateItemsSize()
        {
            /*Calculate buttons size */
            int Height = GraphicsDevice.Viewport.Height / 7;
            int Width = GraphicsDevice.Viewport.Width / 4;
            recPlayButton.Height = Height;
            recPlayButton.Width = Width;
            //
            recExitButton.Height = Height;
            recExitButton.Width = Width;
            /* Calculate logo size */
            recLogo.Height = GraphicsDevice.Viewport.Height / 4;
            recLogo.Width = GraphicsDevice.Viewport.Width / 2;
            //
        }

        private void CalculateItemsPositions()
        {
            recLogo.X = GraphicsDevice.Viewport.Width / 2 - recLogo.Width / 2;
            /* Calculate button position */
            int positionx = GraphicsDevice.Viewport.Width / 2 - recPlayButton.Width / 2;
            //
            recPlayButton.X = positionx;
            recPlayButton.Y = recLogo.Height + recPlayButton.Height / 3;
            //
            //
            recExitButton.X = positionx;
            recExitButton.Y = recPlayButton.Y + 12 * recPlayButton.Height / 10;
            //      
        }

        private void UpdateCursorPosition()
        {
            /* Update Cursor position by Mouse */
            mouseState = Mouse.GetState();
            Cursor.X = mouseState.X; Cursor.Y = mouseState.Y;
        }

        private void ButtonsEvents()
        {
            if ((recPlayButton.Intersects(Cursor)))
            {
                PlayButtonColor = Color.Green;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    PlayButtonColor = Color.Red;
                    MenuState.IsShowGameScene = true;
                    game.Window.AllowUserResizing = false; ;
                }
            }
            else
                PlayButtonColor = Color.White;

            if ((recExitButton.Intersects(Cursor)))
            {
                ExitButtonColor = Color.Green;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    ExitButtonColor = Color.Red;
                    game.Exit();
                }
            }
            else
                ExitButtonColor = Color.White;
        }
    }
}
