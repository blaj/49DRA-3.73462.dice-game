using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame
{
    public class DiceGame : Game
    {
        private GraphicsDeviceManager graphicsDeviceManager;
        private SpriteBatch spriteBatch;

        public DiceGame()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.Aquamarine);
            
            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}