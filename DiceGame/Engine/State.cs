using DiceGame.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Engine
{
    public abstract class State
    {
        protected DiceGame _diceGame;
        protected ContentManager _contentManager;
        protected GraphicsDevice _graphicsDevice;
        protected InputHelper _inputHelper;

        public State(DiceGame diceGame, GraphicsDevice graphicsDevice, ContentManager contentManager, InputHelper inputHelper)
        {
            _diceGame = diceGame;
            _graphicsDevice = graphicsDevice;
            _contentManager = contentManager;
            _inputHelper = inputHelper;
        }
        
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);

        public abstract void Delete();
    }
}