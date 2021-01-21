using System;
using System.Linq;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Player
{
    public class Computer: Entity
    {
        public Computer() : base()
        {
            lifePosition = new Vector2i(Config.Config.WINDOW_WIDHT - 280, 128);
            diceOnHandPosition = new Vector2i(Config.Config.WINDOW_WIDHT / 2, 96);
            diceOnTablePosition = new Vector2i(Config.Config.WINDOW_WIDHT / 2, 128);
            isYourTurn = true;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            DiceOnHand.Select((x, i) => new
            {
                item = x,
                index = i
            }).ToList().ForEach(dice =>
            {
                controlDice(dice.item);
            });
        }

        private void controlDice(Dice dice)
        {
            if (!isYourTurn)
            {
                return;
            }

            var randomTurns = new Random().Next(0, DiceOnHand.Count);

            for (var i = 0; i < randomTurns; i++)
            {
                var randomDiceOnHand = DiceOnHand.ElementAt(new Random().Next(0, DiceOnHand.Count));

                DiceOnHand.Remove(randomDiceOnHand);
                DiceOnTable.Add(randomDiceOnHand);
            }

            isYourTurn = false;
        }
    }
}