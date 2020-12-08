using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Player
{
    public class Table
    {
        public Texture2D texture { get; set; }

        public Table()
        {
            texture = AssetManager.tableTexture;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(0, 0, Config.Config.WINDOW_WIDHT, Config.Config.WINDOW_HEIGHT), Color.White);
        }

        public void update()
        {
        }
    }
}