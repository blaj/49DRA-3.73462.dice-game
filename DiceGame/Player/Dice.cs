using System;
using System.Collections.Generic;
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
        
        public Vector2i position { get; set; }
        public DiceType type { get; set; }

        public Dice(DiceType type)
        {
            this.type = type;
            this.position = new Vector2i();
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(type.texture, new Rectangle(position.x, position.y, 48, 48), Color.White);
        }

        public void update(Vector2i position)
        {
            this.position = position;
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