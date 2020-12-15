using System;
using System.Collections.Generic;
using System.Linq;
using DiceGame.Engine;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Player
{
    public abstract class Entity: GameElement
    {
        protected List<Dice> DiceOnHand;
        protected List<Dice> DiceOnTable;
        protected List<Life> Lifes;

        protected List<GameElement> GameElements
        {
            get
            {
                var elements = new List<GameElement>();
                elements.AddRange(DiceOnHand);
                elements.AddRange(DiceOnTable);
                elements.AddRange(Lifes);
                
                return elements;
            }
        }

        protected Vector2i lifePosition { get; set; }
        protected Vector2i diceOnHandPosition { get; set; }
        protected Vector2i diceOnTablePosition { get; set; }

        public bool isYourTurn;
        public bool isShuffleDice;

        protected Entity()
        {
            DiceOnHand = new List<Dice>();
            DiceOnTable = new List<Dice>();
            Lifes = getFullLifes();
            
            lifePosition = new Vector2i();
            diceOnHandPosition = new Vector2i();
            diceOnTablePosition = new Vector2i();

            isYourTurn = false;
            isShuffleDice = true;

            shuffleDice(true);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            GameElements.ForEach(element => element.Draw(gameTime, spriteBatch));
        }

        public override void Update(GameTime gameTime)
        {
            GameElements.ForEach(element => element.Update(gameTime));
            
            DiceOnHand.Select((x, i) => new
            {
                item = x,
                index = i
            }).ToList().ForEach(dice =>
            {
                dice.item.Position = getDiceOnHandPosition(dice.index);
            });
            
            DiceOnTable.Select((x, i) => new
            {
                item = x,
                index = i
            }).ToList().ForEach(dice =>
            {
                dice.item.Position = getDiceOnTablePosition(dice.index);
            });
            
            Lifes.Select((x, i) => new
            {
                item = x,
                index = i
            }).ToList().ForEach(life =>
            {
                life.item.position = getLifePosition(life.index);
            });
        }

        private Vector2i getLifePosition(int currentIteration)
        {
            var xCol = (currentIteration) % 6;
            var yRow = (currentIteration) / 6;

            var x = xCol * 36 + lifePosition.x;
            var y = lifePosition.y - yRow * 36;
            return new Vector2i(x, y);
        }

        private Vector2i getDiceOnHandPosition(int currentIteration)
        {
            var x = diceOnHandPosition.x;

            if (currentIteration % 2 == 0)
            {
                x += 56 * ((currentIteration + 1) / 2);
            }
            else
            {
                x -= 56 * ((currentIteration + 1) / 2);
            }

            var y = diceOnHandPosition.y - 32;
            return new Vector2i(x, y);
        }

        private Vector2i getDiceOnTablePosition(int currentIteration)
        {
            var x = diceOnTablePosition.x;

            if (currentIteration % 2 == 0)
            {
                x += 56 * ((currentIteration + 1) / 2);
            }
            else
            {
                x -= 56 * ((currentIteration + 1) / 2);
            }

            var y = diceOnTablePosition.y;
            return new Vector2i(x, y);
        }

        private void shuffleDice(bool isInit)
        {
            if (!isShuffleDice)
            {
                return;
            }
            
            if (isInit)
            {
                DiceOnHand = new List<Dice>()
                {
                    new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                    new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                    new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                    new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                    new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                    new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                };
            }
            else
            {
                DiceOnHand.ForEach(dice =>
                    dice.Type = Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count)));
            }

            isShuffleDice = false;
        }

        private List<Life> getFullLifes()
        {
            return new List<Life>()
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
        }
    }
}