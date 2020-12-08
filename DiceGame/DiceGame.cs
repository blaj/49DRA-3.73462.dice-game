using System.IO;
using DiceGame.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame
{
    public class DiceGame : Game
    {
        private GraphicsDeviceManager graphicsDeviceManager;
        private SpriteBatch spriteBatch;

        private Table table;
        private Player.Player player;

        private Texture2D floorTexture;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            AssetManager.loadTextures(GraphicsDevice);
            floorTexture = AssetManager.floorTexture;
            
            table = new Table();
            player = new Player.Player();
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            graphicsDeviceManager.GraphicsDevice.Clear(Color.Aquamarine);

            try
            {
                drawFloor(GraphicsDevice, spriteBatch);
                table.draw(spriteBatch);
                player.draw(spriteBatch);
            }
            finally
            {
                spriteBatch.End();
            }
            
            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            table.update();
            player.update();
            
            base.Update(gameTime);
        }

        private void drawFloor(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            var amountWidth = Config.Config.WINDOW_WIDHT / 128;
            var amountHeight = Config.Config.WINDOW_HEIGHT / 128;
            
            for (int i = 0; i <= amountWidth; i++)
            {
                for (int j = 0; j <= amountHeight; j++)
                {
                    var x = i * 128;
                    var y = j * 128;
                    spriteBatch.Draw(
                        floorTexture, 
                        new Rectangle(
                            x,
                            y,
                            128,
                            128),
                        Color.White);
                }
            }
        }
    }
}