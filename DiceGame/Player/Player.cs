using System;
using System.Collections.Generic;
using System.Linq;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DiceGame.Player
{
    public class Player: Entity
    {
        public Player()
        {
            diceOnHand = new List<Dice>();
            diceOnTable = new List<Dice>();
            lifes = Life.FULL_LIFE;

            shuffleDice();
        }

        public void draw(SpriteBatch spriteBatch)
        {
            foreach (var dice in diceOnHand)
            {
                dice.draw(spriteBatch);
            }

            foreach (var dice in diceOnTable)
            {
                dice.draw(spriteBatch);
            }

            foreach (var life in lifes)
            {
                life.draw(spriteBatch);
            }
        }

        public void update()
        {
            var mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                shuffleDice();
            }
            
            diceOnHand.Select((x, i) => new
            {
                item = x,
                index = i
            }).ToList().ForEach(dice =>
            {
                dice.item.update(getDiceOnHandPosition(dice.index));
            });

            diceOnTable.Select((x, i) => new
            {
                item = x,
                index = i
            }).ToList().ForEach(dice =>
            {
                dice.item.update(getDiceOnTablePosition(dice.index));
            });

            lifes.Select((x, i) => new
            {
                item = x,
                index = i
            }).ToList().ForEach(life =>
            {
                life.item.update(getLifePosition(life.index));
            });
        }

        private Vector2i getLifePosition(int currentIteration)
        {
            var xCol = (currentIteration) % 6;
            var yRow = (currentIteration) / 6;

            var x = xCol * 36 + 64;
            var y = Config.Config.WINDOW_HEIGHT - yRow * 36 - 96;
            return new Vector2i(x, y);
        }

        private Vector2i getDiceOnHandPosition(int currentIteration)
        {
            var x = Config.Config.WINDOW_WIDHT / 2;

            if (currentIteration % 2 == 0)
            {
                x += 56 * ((currentIteration + 1) / 2);
            }
            else
            {
                x -= 56 * ((currentIteration + 1) / 2);
            }
            
            var y = Config.Config.WINDOW_HEIGHT - 96 - 32;
            return new Vector2i(x, y);
        }

        private Vector2i getDiceOnTablePosition(int currentIteration)
        {
            var x = Config.Config.WINDOW_WIDHT / 2;

            if (currentIteration % 2 == 0)
            {
                x += 56 * ((currentIteration + 1) / 2);
            }
            else
            {
                x -= 56 * ((currentIteration + 1) / 2);
            }
            
            var y = Config.Config.WINDOW_HEIGHT / 2 + 128;
            return new Vector2i(x, y);
        }

        private void shuffleDice()
        {
            diceOnHand = new List<Dice>()
            {
                new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
            };
            
            diceOnTable = new List<Dice>()
            {
                new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
                new Dice(Dice.DiceType.TYPES.ElementAt(new Random().Next(0, Dice.DiceType.TYPES.Count))),
            };
        }
    }
}