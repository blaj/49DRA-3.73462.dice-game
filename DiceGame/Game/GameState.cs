using System.Collections.Generic;
using DiceGame.Engine;
using DiceGame.Helpers;
using DiceGame.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace DiceGame.Game
{
    public class GameState : State
    {
        private readonly List<GameElement> _gameElements;
        private Entity whichTurn;
        
        public static int RoundNumber { get; set; } = 1;

        public GameState(DiceGame diceGame, GraphicsDevice graphicsDevice, ContentManager contentManager,
            InputHelper inputHelper) : base(diceGame, graphicsDevice, contentManager, inputHelper)
        {
            MediaPlayer.Play(AssetManager.inGameAudio);
            
            var floor = new Floor();
            var table = new Table();
            var player = new Player.Player();
            var computer = new Computer();
            var battle = new Battle();

            _gameElements = new List<GameElement>()
            {
                floor,
                table,
                player,
                computer,
                battle
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _gameElements.ForEach(element => element.Draw(gameTime, spriteBatch));
        }

        public override void Update(GameTime gameTime)
        {
            _gameElements.ForEach(element => element.Update(gameTime));
        }

        public override void Delete()
        {
            // MediaPlayer.Stop();
        }
    }
}