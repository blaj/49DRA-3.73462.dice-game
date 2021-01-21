using System;
using System.Collections.Generic;
using DiceGame.Engine;
using DiceGame.Player;
using DiceGame.Utils;
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

        private Floor _floor;
        private Table _table;
        private Player.Player _player;
        private Computer _computer;
        private Battle _battle;

        private Button _nextDealButton;
        private Button _nextRoundButton;

        private EndScreen _endScreen;

        private Entity _whoLost;

        public GameState(DiceGame diceGame, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(
            diceGame, graphicsDevice, contentManager)
        {
            RoundNumber = 1;
            
            MediaPlayer.Play(AssetManager.inGameAudio);

            _floor = new Floor();
            _table = new Table();
            _player = new Player.Player();
            _computer = new Computer();
            _battle = new Battle(_player, _computer);

            var centerOfScreen = Config.Config.WINDOW_WIDHT / 2;

            _nextDealButton = new Button(AssetManager.buttonTexture, AssetManager.pressStartFont)
            {
                Position = new Vector2i(centerOfScreen, Config.Config.WINDOW_HEIGHT - 40),
                Text = "Nastepne rozdanie",
                IsDrawStartCenter = true,
            };
            _nextDealButton.Click += nextDealButtonClickEvent;
            
            _nextRoundButton = new Button(AssetManager.buttonTexture, AssetManager.pressStartFont)
            {
                Position = new Vector2i(centerOfScreen, Config.Config.WINDOW_HEIGHT - 40),
                Text = "Nastepna runda",
                IsDrawStartCenter = true,
                isHide = true
            };
            _nextRoundButton.Click += nextRoundButtonClickEvent;
            
            _endScreen = new EndScreen(_diceGame, _graphicsDevice, _contentManager);
            
            _gameElements = new List<GameElement>()
            {
                _floor,
                _table,
                _player,
                _computer,
                _battle,
                _nextRoundButton,
                _nextDealButton,
                _endScreen
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_whoLost != null)
            {
                _endScreen.isHide = false;
            }
            
            _gameElements.ForEach(element => element.Draw(gameTime, spriteBatch));
        }

        public override void Update(GameTime gameTime)
        {
            if (_player.Lifes.Count <= 0)
            {
                _whoLost = _player;
                _endScreen.whoLost = "Przegrales!!!";
            } else if (_computer.Lifes.Count <= 0)
            {
                _endScreen.whoLost = "Wygrales!!!";
                _whoLost = _computer;
            }
            
            if (_whoLost != null)
            {
                _nextDealButton.isHide = true;
                _nextRoundButton.isHide = true;
            }
            
            if (_battle.IsBattleEnable)
            {
                _nextRoundButton.isHide = false;
                _nextDealButton.isHide = true;
            }
            
            _player.isYourTurn = !_computer.isYourTurn;

            if (!_player.isYourTurn)
            {
                _player.isShuffleDice = true;
                _player.shuffleDice(false);
            }
            
            _gameElements.ForEach(element => element.Update(gameTime));
            StartBattle();
        }

        public override void Delete()
        {
            // MediaPlayer.Stop();
        }
        
        private void nextRoundButtonClickEvent(object sender, EventArgs eventArgs)
        {
            if (isAnyDiceChangePosition())
            {
                return;
            }
            
            _battle.IsBattleEnable = false;
            _battle.Reset();

            _nextDealButton.isHide = false;
            _nextRoundButton.isHide = true;

            _player.isShuffleDice = true;
            _player.shuffleDice(true);

            _computer.isShuffleDice = true;
            _computer.shuffleDice(true);

            RoundNumber = 1;
        }

        private void nextDealButtonClickEvent(object sender, EventArgs eventArgs)
        {
            if (_battle.IsBattleEnable)
            {
                return;
            }

            if (isAnyDiceChangePosition())
            {
                return;
            }

            RoundNumber++;

            _computer.isShuffleDice = true;
            _computer.shuffleDice(false);
            
            _computer.isYourTurn = true;
        }

        private void StartBattle()
        {
            if (RoundNumber > 3)
            {
                var hasAnyDiceAlreadyOnHand = false;
                
                foreach (var dice in _player.DiceOnHand.ToArray())
                {
                    _player.DiceOnHand.Remove(dice);
                    _player.DiceOnTable.Add(dice);
                    hasAnyDiceAlreadyOnHand = true;
                }
                
                foreach (var dice in _computer.DiceOnHand.ToArray())
                {
                    _computer.DiceOnHand.Remove(dice);
                    _computer.DiceOnTable.Add(dice);
                    hasAnyDiceAlreadyOnHand = true;
                }

                if (isAnyDiceChangePosition())
                {
                    return;
                }

                if (hasAnyDiceAlreadyOnHand)
                {
                    return;
                }
                
                _battle.PrepareDiceToBattle();
                
                _player.DiceOnHand = new List<Dice>();
                _player.DiceOnTable = new List<Dice>();
                _computer.DiceOnHand = new List<Dice>();
                _computer.DiceOnTable = new List<Dice>();
            }
        }

        private bool isAnyDiceChangePosition()
        {
            foreach (var dice in _player.DiceOnTable)
            {
                if (dice.isChangePosition())
                {
                    return true;
                }
            }
            
            foreach (var dice in _computer.DiceOnTable)
            {
                if (dice.isChangePosition())
                {
                    return true;
                }
            }

            return false;
        }
    }
}