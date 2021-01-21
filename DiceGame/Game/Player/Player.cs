using System;
using System.Linq;
using DiceGame.Helpers;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DiceGame.Player
{
    public class Player : Entity
    {
        public Player(): base()
        {
            lifePosition = new Vector2i(64, Config.Config.WINDOW_HEIGHT - 96);
            diceOnHandPosition = new Vector2i(Config.Config.WINDOW_WIDHT / 2, Config.Config.WINDOW_HEIGHT - 96);
            diceOnTablePosition = new Vector2i(Config.Config.WINDOW_WIDHT / 2, Config.Config.WINDOW_HEIGHT / 2 + 128);
            isYourTurn = false;
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
            
            var mouseState = Mouse.GetState();
            var isIntersect = dice.isIntersect(mouseState.X, mouseState.Y);

            if (InputHelper.IsNewLeftClick() && isIntersect)
            {
                AssetManager.diceClickAudio.Play();
                DiceOnHand.Remove(dice);
                DiceOnTable.Add(dice);
                isIntersect = false;
            }

            dice.IsHovered = isIntersect;
        }
    }
}