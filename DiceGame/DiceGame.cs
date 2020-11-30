using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame
{
    public class DiceGame : Game
    {
        private GraphicsDeviceManager graphicsDeviceManager;
        private SpriteBatch spriteBatch;

        private Player.Player player;

        public DiceGame()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            graphicsDeviceManager.IsFullScreen = false;
            graphicsDeviceManager.PreferredBackBufferWidth = Config.Config.WINDOW_WIDHT;
            graphicsDeviceManager.PreferredBackBufferHeight = Config.Config.WINDOW_HEIGHT;
            graphicsDeviceManager.ApplyChanges();

            player = new Player.Player();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.loadContent(GraphicsDevice, spriteBatch);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            graphicsDeviceManager.GraphicsDevice.Clear(Color.Aquamarine);

            try
            {
                player.draw();
            }
            finally
            {
                spriteBatch.End();
            }
            
            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            player.update();
            
            base.Update(gameTime);
        }
    }
}