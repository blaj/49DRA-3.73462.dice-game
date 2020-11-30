using System;
using System.IO;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Player
{
    public class Dice
    {
        private static readonly int WIDHT = 32;
        private static readonly int HEIGHT = 32;
        
        private SpriteBatch spriteBatch;
        public string image { get; set; }
        public Texture2D texture { get; set; }
        public Vector2i position { get; set; }
        public DiceType type { get; set; }

        public Dice(DiceType type)
        {
            this.image = "dice_image.png";
            this.type = type;
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
            spriteBatch.Draw(texture, new Rectangle(position.x, position.y, WIDHT * Config.Config.IMAGE_SCALE, HEIGHT * Config.Config.IMAGE_SCALE), Color.White);
        }

        public void update()
        {
            
        }

        public class DiceType
        {
            public static readonly DiceType MALE_ATTACK = new DiceType("icon_male_attack.png");
            public static readonly DiceType DISTANCE_ATTACK = new DiceType("icon_distance_attack.png");
            public static readonly DiceType MALE_BLOCK = new DiceType("icon_male_block.png");
            public static readonly DiceType DISTANCE_BLOCK = new DiceType("icon_distance_block.png");

            private string icon;

            public DiceType(string icon)
            {
                this.icon = icon;
            }
        }
    }
}