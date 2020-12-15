using System;
using System.Collections.Generic;
using DiceGame.Engine;
using DiceGame.Game;
using DiceGame.Helpers;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace DiceGame.MainMenu
{
    public class MainMenuState : State
    {
        private List<GameElement> _gameElements;

        public MainMenuState(DiceGame diceGame, GraphicsDevice graphicsDevice, ContentManager contentManager,
            InputHelper inputHelper) : base(
            diceGame, graphicsDevice, contentManager, inputHelper)
        {
            MediaPlayer.Play(AssetManager.mainMenuAudio);

            var centerOfScreen = Config.Config.WINDOW_WIDHT / 2;
            
            var newGameButton = new Button(AssetManager.buttonTexture, AssetManager.pressStartFont)
            {
                Position = new Vector2i(centerOfScreen, 300),
                Text = "New game",
                IsDrawStartCenter = true
            };
            newGameButton.Click += newGameButtonClickEvent;
            
            var exitButton = new Button(AssetManager.buttonTexture, AssetManager.pressStartFont)
            {
                Position = new Vector2i(centerOfScreen, 400),
                Text = "Quit game",
                IsDrawStartCenter = true
            };
            exitButton.Click += exitButtonClickEvent;
            
            var gameNameText = new Text(AssetManager.pressStartFont)
            {
                Position = new Vector2i(centerOfScreen, 64),
                TextString = "DiceGame",
                IsDrawStartCenter = true
            };
            
            _gameElements = new List<GameElement>()
            {
                newGameButton,
                exitButton,
                gameNameText
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

        private void newGameButtonClickEvent(object sender, EventArgs eventArgs)
        {
            _diceGame.ChangeState(new GameState(_diceGame, _graphicsDevice, _contentManager, _inputHelper));
        }

        private void exitButtonClickEvent(object sender, EventArgs eventArgs)
        {
            _diceGame.Exit();
        }
    }
}