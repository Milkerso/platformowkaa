using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShooter.States
{
    public abstract class State
    {
        protected global::Game1 _game;

        protected ContentManager _content;
        private Game1 game;
        private ContentManager content;

        public State(global::Game1 game, ContentManager content)
        {
            _game = game;

            _content = content;
        }

        protected State(Game1 game, ContentManager content)
        {
            this.game = game;
            this.content = content;
        }

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void PostUpdate(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}