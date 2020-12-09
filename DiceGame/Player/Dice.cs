using System.Collections.Generic;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DiceGame.Player
{
    public class Dice
    {
        public Vector2i position { get; set; }

        public Rectangle rectangle;

        public DiceType type { get; set; }
        public bool isHovered { get; set; }

        public Dice(DiceType type)
        {
            this.position = new Vector2i();
            this.rectangle = new Rectangle(position.x, position.y, 48, 48);
            this.type = type;
            this.isHovered = false;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(type.texture, rectangle, Color.White);

            if (isHovered)
            {
                spriteBatch.Draw(AssetManager.diceHoverTexture, rectangle, Color.White);
            }
        }

        public void update(Vector2i position)
        {
            this.position = position;
            this.rectangle.X = position.x;
            this.rectangle.Y = position.y;
        }

        public bool isIntersect(int x, int y)
        {
            return x > rectangle.X && x < rectangle.X + rectangle.Width && y > rectangle.Y &&
                   y < rectangle.Y + rectangle.Height;
        }

        public class DiceType
        {
            public static readonly DiceType MALE_ATTACK = new DiceType(AssetManager.diceMaleAttackTexture);
            public static readonly DiceType DISTANCE_ATTACK = new DiceType(AssetManager.diceDistanceAttackTexture);
            public static readonly DiceType MALE_BLOCK = new DiceType(AssetManager.diceMaleBlockTexture);
            public static readonly DiceType DISTANCE_BLOCK = new DiceType(AssetManager.diceDistanceBlockTexture);

            public static readonly List<DiceType> TYPES = new List<DiceType>()
            {
                MALE_ATTACK,
                MALE_BLOCK,
                DISTANCE_ATTACK,
                DISTANCE_BLOCK,
            };
            
            public Texture2D texture { get; set; }

            public DiceType(Texture2D texture)
            {
                this.texture = texture;
            }
        }
    }
}