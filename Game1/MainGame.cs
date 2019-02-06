using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnakeClassic_Csharp_dev.pl
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        public int Score { get; set; }
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //scenes
        MenuScene menuScene;
        GameScene gameScene;
        GameOverScene gameOverScene;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            //create new objects
            menuScene = new MenuScene(this);
            gameScene = new GameScene(this);
            gameOverScene = new GameOverScene(this);
            //if desktop
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            //show menu
            MenuState.IsShowGameScene = true;
            MenuState.IsShowGameOverScene = true;
            MenuState.IsShowMainMenuScene = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //show only one scene
            if (MenuState.IsShowMainMenuScene)
                menuScene.Update();
            if (MenuState.IsShowGameScene)
                gameScene.Update(gameTime);
            if (MenuState.IsShowGameOverScene)
                gameOverScene.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //show only one scene
            if (MenuState.IsShowMainMenuScene)
                menuScene.Draw(spriteBatch, gameTime);
            if (MenuState.IsShowGameScene)
                gameScene.Draw(spriteBatch, gameTime);
            if (MenuState.IsShowGameOverScene)
                gameOverScene.Draw(spriteBatch, gameTime);
            base.Draw(gameTime);
        }
    }
}
