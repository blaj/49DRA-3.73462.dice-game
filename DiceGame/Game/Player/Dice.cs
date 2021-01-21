using System;
using System.Collections.Generic;
using DiceGame.Engine;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DiceGame.Player
{
    public class Dice: GameElement
    {
        public Vector2i Position { get; set; }
        public Vector2i TargetPosition { get; set; }

        public Rectangle Rectangle
        {
            get => new Rectangle(Position.x, Position.y, 48, 48);
            set => Rectangle = value;
        }
        public DiceType Type { get; set; }
        public bool IsHovered { get; set; }

        public Dice(DiceType type)
        {
            Position = new Vector2i();
            Type = type;
            IsHovered = false;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Type.texture, Rectangle, Color.White);

            if (IsHovered)
            {
                spriteBatch.Draw(AssetManager.diceHoverTexture, Rectangle, Color.White);
            }
        }

        public override void Update(GameTime gameTime)
        {
            MoveDiceToTargetPosition();
        }

        public bool isIntersect(int x, int y)
        {
            return x > Rectangle.X && x < Rectangle.X + Rectangle.Width && y > Rectangle.Y &&
                   y < Rectangle.Y + Rectangle.Height;
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
            
            public static readonly List<DiceType> ATTACK_TYPES = new List<DiceType>()
            {
                MALE_ATTACK,
                DISTANCE_ATTACK
            };
            
            public static readonly List<DiceType> BLOCK_TYPES = new List<DiceType>()
            {
                MALE_BLOCK,
                DISTANCE_BLOCK
            };
            
            public Texture2D texture { get; }

            private DiceType(Texture2D texture)
            {
                this.texture = texture;
            }
        }

        public bool isChangePosition()
        {
            if (TargetPosition == null)
            {
                return false;
            }
            
            return TargetPosition.x != Position.x || TargetPosition.y != Position.y;
        }

        private void MoveDiceToTargetPosition()
        {
            if (TargetPosition == null)
            {
                return;
            }
            
            if (TargetPosition.x > Position.x)
            {
                Position.x++;
            }
            else if (TargetPosition.x < Position.x)
            {
                Position.x--;
            }

            if (TargetPosition.y > Position.y)
            {
                Position.y++;
            }
            else if (TargetPosition.y < Position.y)
            {
                Position.y--;
            }

            if (TargetPosition.x == Position.x && TargetPosition.y == Position.y)
            {
                TargetPosition = null;
            }
        }
    }
}