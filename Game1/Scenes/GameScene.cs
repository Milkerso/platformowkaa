using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SnakeClassic_Csharp_dev.pl
{
    class GameScene : DrawableGameComponent
    {
        Game game;
        bool IsStart = true;
        int BlockSize;

        Texture2D PlayerBodyTexture;
        Texture2D ItemTexture;
        Texture2D BackgroundTexture;

        Rectangle recItem;
        Rectangle recBackground;


        //snake
        int BodyIndex = 0;
        List<Rectangle> recPlayerBody = new List<Rectangle>();
        bool IsMoveToDown = false, IsMoveToTop = false, IsMoveToLeft = false, IsMoveToRight = false;
        public GameScene(Game game) : base(game)
        {
            this.game = game;
            LoadContent();
        }

        protected override void LoadContent()
        {
            PlayerBodyTexture = game.Content.Load<Texture2D>("Player/Player");
            ItemTexture = game.Content.Load<Texture2D>("Menu/Item");
            BackgroundTexture = game.Content.Load<Texture2D>("Background/background");
          
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //show background
            spriteBatch.Draw(BackgroundTexture, recBackground, Color.White);
            //show HeadSnake
            spriteBatch.Draw(PlayerBodyTexture, recPlayerBody[0], Color.Red);
            //show body
            int i = 0;
    
            //show item
            spriteBatch.Draw(ItemTexture, recItem, Color.Green);
            //show score
          
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            if (IsStart)
            {
                //clear list
                recPlayerBody.Clear();
                //
                CalculateItemsSize();
                AddBodyBlock();
                GenerateNewItem();
                IsStart = false;
            }
            HandlingPlayerController();
            UpdatePlayerPosition(gameTime);
            CheckCollision();
            CheckIsPlayerInWindow();
        }

        private void CalculateItemsSize()
        {
            recBackground.Width = GraphicsDevice.Viewport.Width;
            recBackground.Height = GraphicsDevice.Viewport.Height;
            recBackground.X = 0; recBackground.Y = 0;
            //
            BlockSize = GraphicsDevice.Viewport.Width / 32 + GraphicsDevice.Viewport.Height / 32;
            recItem.Height = BlockSize; recItem.Width = BlockSize;
        }

        private void AddBodyBlock()
        {
            if (IsStart)
                recPlayerBody.Add(new Rectangle(200, 200, BlockSize, BlockSize));
            else
            {
                ++BodyIndex;
                if (IsMoveToDown)
                {
                    recPlayerBody.Add(new Rectangle(recPlayerBody[BodyIndex - 1].X, recPlayerBody[BodyIndex - 1].Y - recPlayerBody[BodyIndex - 1].Height, BlockSize, BlockSize));
                }
                if (IsMoveToTop)
                {
                    recPlayerBody.Add(new Rectangle(recPlayerBody[BodyIndex - 1].X, recPlayerBody[BodyIndex - 1].Y + recPlayerBody[BodyIndex - 1].Height, BlockSize, BlockSize));
                }
                if (IsMoveToRight)
                {
                    recPlayerBody.Add(new Rectangle(recPlayerBody[BodyIndex - 1].X - recPlayerBody[BodyIndex - 1].Width, recPlayerBody[BodyIndex - 1].Y, BlockSize, BlockSize));
                }
                if (IsMoveToLeft)
                {
                    recPlayerBody.Add(new Rectangle(recPlayerBody[BodyIndex - 1].X + recPlayerBody[BodyIndex - 1].Width, recPlayerBody[BodyIndex - 1].Y, BlockSize, BlockSize));
                }
                GenerateNewItem();
            }
        }

        private void HandlingPlayerController()
        {
            KeyboardState state = Keyboard.GetState();
            if ((state.IsKeyDown(Keys.Down)) && (!IsMoveToTop))
            {
               
                recPlayerBody[0] = new Rectangle(recPlayerBody[0].X, recPlayerBody[0].Y + recPlayerBody[0].Height/5, BlockSize, BlockSize);
            }
            else if ((state.IsKeyDown(Keys.Up)) && (!IsMoveToDown))
            {
                recPlayerBody[0] = new Rectangle(recPlayerBody[0].X, recPlayerBody[0].Y - recPlayerBody[0].Height/5, BlockSize, BlockSize);
            }
            else if ((state.IsKeyDown(Keys.Left)) && (!IsMoveToRight))
            {
                recPlayerBody[0] = new Rectangle(recPlayerBody[0].X - recPlayerBody[0].Width/5, recPlayerBody[0].Y, BlockSize, BlockSize);
            }
            else if ((state.IsKeyDown(Keys.Right)) && (!IsMoveToLeft))
            {
                recPlayerBody[0] = new Rectangle(recPlayerBody[0].X + recPlayerBody[0].Width/5, recPlayerBody[0].Y, BlockSize, BlockSize);
            }
        }

        private void UpdatePlayerPosition(GameTime gameTime)
        {
            
          
            
            
        }

        private void CheckIsPlayerInWindow()
        {
            if (recPlayerBody[0].X >= GraphicsDevice.Viewport.Width)
                GameOver();
            if (recPlayerBody[0].Y >= GraphicsDevice.Viewport.Height)
                GameOver();
            if (recPlayerBody[0].X < 0 - recPlayerBody[0].Width)
                GameOver(); ;
            if (recPlayerBody[0].Y < 0 - recPlayerBody[0].Height)
                GameOver();
        }

        private void CheckCollision()
        {
            if (recPlayerBody[0].Intersects(recItem))
            {
                AddBodyBlock();
            }
         
        }

        Random random = new Random();
        private void GenerateNewItem()
        {
            //generate item
            recItem.X = random.Next(GraphicsDevice.Viewport.Width - recItem.Width);
            recItem.Y = random.Next(GraphicsDevice.Viewport.Height - recItem.Height);
        }

        private void GameOver()
        {
            IsMoveToDown = false; IsMoveToTop = false; IsMoveToRight = false; IsMoveToLeft = false;
            game.Window.AllowUserResizing = true;
            Score.GameScore = BodyIndex; //set value to Score
            BodyIndex = 0;
            IsStart = true;

            MenuState.IsShowGameOverScene = true;
        }
    }

    public class Score
    {
        public static int GameScore { get; set; }
    }
}

