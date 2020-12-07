using System.Collections.Generic;
using System.IO;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Player
{
    public class Life : GameElement
    { 
        public static List<Life> FULL_LIFE = new List<Life>()
        {
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life(),
            new Life()
        };
        
        private SpriteBatch spriteBatch;

        public string image { get; set; }
        public Texture2D texture { get; set; }
        public Vector2i position { get; set; }

        public Life()
        {
            this.image = "icon_life.png";
            this.position = new Vector2i();
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
            spriteBatch.Draw(texture, new Rectangle(position.x, position.y, 48, 48), Color.White);
        }

        public void update()
        {
        }
    }
}