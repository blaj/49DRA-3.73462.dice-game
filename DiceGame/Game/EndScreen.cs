using System;
using System.Collections.Generic;
using DiceGame.Engine;
using DiceGame.MainMenu;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Game
{
    public class EndScreen : GameElement
    {
        public bool isHide { get; set; }

        private Button _newGameButton;
        private Button _quitToMainMenuButton;
        private Text _whoWinText;

        private List<GameElement> _gameElements;

        public string whoLost { get; set; }
        
        protected DiceGame _diceGame;
        protected ContentManager _contentManager;
        protected GraphicsDevice _graphicsDevice;
        
        public EndScreen(DiceGame diceGame, GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            isHide = true;
            
            var centerOfScreen = Config.Config.WINDOW_WIDHT / 2;

            _newGameButton = new Button(AssetManager.buttonTexture, AssetManager.pressStartFont)
            {
                Position = new Vector2i(centerOfScreen, Config.Config.WINDOW_HEIGHT - 80),
                Text = "Nowa gra",
                IsDrawStartCenter = true,
                isHide = true
            };
            _newGameButton.Click += newGameButtonClickEvent;
            
            _quitToMainMenuButton = new Button(AssetManager.buttonTexture, AssetManager.pressStartFont)
            {
                Position = new Vector2i(centerOfScreen, Config.Config.WINDOW_HEIGHT - 40),
                Text = "Wyjscie do menu",
                IsDrawStartCenter = true,
                isHide = true
            };
            _quitToMainMenuButton.Click += quitToMainMenuClickEvent;
            
            _whoWinText = new Text(AssetManager.pressStartFont)
            {
                Position = new Vector2i(centerOfScreen, 64),
                IsDrawStartCenter = true
            };
            
            _gameElements = new List<GameElement>()
            {
                _newGameButton,
                _quitToMainMenuButton,
                _whoWinText
            };
            
            _diceGame = diceGame;
            _graphicsDevice = graphicsDevice;
            _contentManager = contentManager;
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isHide)
            {
                return;
            }
            
            spriteBatch.Draw(
                AssetManager.blackTexture, 
                new Rectangle(
                    0,
                    0,
                    Config.Config.WINDOW_WIDHT,
                    Config.Config.WINDOW_HEIGHT),
                Color.White * 0.5f);
            
            _gameElements.ForEach(element => element.Draw(gameTime, spriteBatch));
        }

        public override void Update(GameTime gameTime)
        {
            if (whoLost != null)
            {
                _whoWinText.TextString = whoLost;
                whoLost = null;
            }
            
            _newGameButton.isHide = isHide;
            _quitToMainMenuButton.isHide = isHide;
            
            _gameElements.ForEach(element => element.Update(gameTime));
        }
        
        private void newGameButtonClickEvent(object sender, EventArgs eventArgs)
        {
            _diceGame.ChangeState(new GameState(_diceGame, _graphicsDevice, _contentManager));
        }

        private void quitToMainMenuClickEvent(object sender, EventArgs eventArgs)
        {
            _diceGame.ChangeState(new MainMenuState(_diceGame, _graphicsDevice, _contentManager));
        }
    }
}