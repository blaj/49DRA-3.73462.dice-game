using System;
using System.Collections.Generic;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Player
{
    public class Player: GameElement
    {
        private List<Dice> diceOnHand;
        private List<Dice> diceOnTable;
        private List<Life> lifes;

        public Player()
        {
            diceOnHand = new List<Dice>();
            
            var dice1 = new Dice(Dice.DiceType.MALE_ATTACK);
            dice1.position = new Vector2i(1280 - 16 * 8, 720 - 16 * 8);
            
            var dice2 = new Dice(Dice.DiceType.MALE_ATTACK);
            dice2.position = new Vector2i(16 + 64 + 32, 16);
            
            var dice3 = new Dice(Dice.DiceType.MALE_ATTACK);
            dice3.position = new Vector2i(16 + 64 + 64 + 32 + 32, 16);
            
            var dice4 = new Dice(Dice.DiceType.MALE_ATTACK);
            dice4.position = new Vector2i(16 + 64 + 64 + 64 + 32 + 32 + 32, 16);

            diceOnHand.Add(dice1);
            diceOnHand.Add(dice2);
            diceOnHand.Add(dice3);
            diceOnHand.Add(dice4);
            
            diceOnTable = new List<Dice>();

            this.lifes = Life.FULL_LIFE;
        }

        public void loadContent(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            foreach (var dice in diceOnHand)
            {
                dice.loadContent(graphicsDevice, spriteBatch);
            }

            foreach (var dice in diceOnTable)
            {
                dice.loadContent(graphicsDevice, spriteBatch);
            }

            foreach (var life in lifes)
            {
                life.loadContent(graphicsDevice, spriteBatch);
            }
        }
        
        public void draw()
        {
            foreach (var dice in diceOnHand)
            {
                dice.draw();
            }

            foreach (var dice in diceOnTable)
            {
                dice.draw();
            }

            foreach (var life in lifes)
            {
                life.draw();
            }
        }

        public void update()
        {
            foreach (var dice in diceOnHand)
            {
                dice.update();
            }

            foreach (var dice in diceOnTable)
            {
                dice.update();
            }

            foreach (var life in lifes)
            {
                life.update();
            }
        }
    }
}