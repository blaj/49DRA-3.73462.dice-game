using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Player
{
    public class Player
    {
        private List<Dice> diceOnHand;
        private List<Dice> diceOnTable;

        public Player()
        {
            diceOnHand = new List<Dice>();
            diceOnHand.Add(new Dice(Dice.DiceType.MALE_ATTACK));
            diceOnHand.Add(new Dice(Dice.DiceType.DISTANCE_ATTACK));
            
            diceOnTable = new List<Dice>();
            diceOnTable.Add(new Dice(Dice.DiceType.MALE_ATTACK));
            diceOnTable.Add(new Dice(Dice.DiceType.DISTANCE_ATTACK));
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
        }

        public void update()
        {
            var rand = new Random();
            
            foreach (var dice in diceOnHand)
            {
                dice.position.x += rand.Next(-1, 5);
                dice.position.y += rand.Next(-1, 5);
                
                dice.update();
            }

            foreach (var dice in diceOnTable)
            {
                dice.position.x += rand.Next(-1, 5);
                dice.position.y += rand.Next(-1, 5);
                
                dice.update();
            }
        }
    }
}