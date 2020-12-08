using System.Collections.Generic;
using System.IO;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Player
{
    public class Life
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
        };
        
        private SpriteBatch spriteBatch;

        public Texture2D texture { get; set; }
        public Vector2i position { get; set; }

        public Life()
        {
            this.texture = AssetManager.lifeTexture;
            this.position = new Vector2i();
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(position.x, position.y, 32, 32), Color.White);
        }

        public void update(Vector2i position)
        {
            this.position = position;
        }
    }
}