using DiceGame.Engine;
using DiceGame.Game;
using DiceGame.Helpers;
using DiceGame.MainMenu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame
{
    public class DiceGame : Microsoft.Xna.Framework.Game
    {
        private readonly GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;

        private State _currentState;
        private State _nextState;

        public DiceGame()
        {
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            _graphicsDeviceManager.IsFullScreen = false;
            _graphicsDeviceManager.PreferredBackBufferWidth = Config.Config.WINDOW_WIDHT;
            _graphicsDeviceManager.PreferredBackBufferHeight = Config.Config.WINDOW_HEIGHT;
            _graphicsDeviceManager.ApplyChanges();
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            AssetManager.loadTextures(Content, GraphicsDevice);
            AssetManager.loadAudios(Content);
            AssetManager.loadFonts(Content);

            _currentState = new MainMenuState(this, GraphicsDevice, Content);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            _graphicsDeviceManager.GraphicsDevice.Clear(Color.Aquamarine);

            try
            {
                _currentState.Draw(gameTime, _spriteBatch);
            }
            finally
            {
                _spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            InputHelper.UpdateStates();
            
            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            
            _currentState.Update(gameTime);
            
            base.Update(gameTime);
        }
        
        public void ChangeState(State state)
        {
            _currentState.Delete();
            _nextState = state;
        }
    }
}