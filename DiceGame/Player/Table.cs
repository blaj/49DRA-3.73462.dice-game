using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Player
{
    public class Table: GameElement
    {
        private SpriteBatch spriteBatch;

        public string image { get; set; }
        public Texture2D texture { get; set; }

        public Table()
        {
            this.image = "table.png";
        }

        public void loadContent(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            
            var stream = new FileStream("Content/" + this.image, FileMode.Open);
            texture = Texture2D.FromStream(graphicsDevice, stream);
            stream.Close();
        }
        
        public void draw()
        {
            spriteBatch.Draw(texture, new Rectangle(0, 0, Config.Config.WINDOW_WIDHT, Config.Config.WINDOW_HEIGHT), Color.White);
        }

        public void update()
        {
        }
    }
}