using System;
using System.Collections.Generic;
using DiceGame.Engine;
using DiceGame.Player;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Game
{
    public class Battle: GameElement
    {
        private List<Dice> _playerDices;
        private List<Dice> _computerDices;

        private Dictionary<Dice.DiceType, int> _playerDiceTypeCount;
        private Dictionary<Dice.DiceType, int> _computerDiceTypeCount;
        
        private Entity _player;
        private Entity _computer;

        public bool IsBattlePrepared;
        public bool IsBattleEnable;

        public Battle(Entity player, Entity computer)
        {
            _playerDices = new List<Dice>();
            _computerDices = new List<Dice>();
            
            _playerDiceTypeCount = new Dictionary<Dice.DiceType, int>();
            _computerDiceTypeCount = new Dictionary<Dice.DiceType, int>();
            
            _player = player;
            _computer = computer;
            
            IsBattleEnable = false;
            IsBattlePrepared = false;
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var computerDice in _computerDices)
            {
                computerDice.Draw(gameTime, spriteBatch);
            }

            foreach (var playerDice in _playerDices)
            {
                playerDice.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            _computerDices.ForEach(dice =>
            {
                dice.Update(gameTime);
            });
            
            _playerDices.ForEach(dice =>
            {
                dice.Update(gameTime);
            });
        }

        public void PrepareDiceToBattle()
        {
            if (IsBattlePrepared)
            {
                return;
            }

            if (isAnyDiceChangePosition())
            {
                return;
            }
            
            CopyDice();
            SetDiceTargetPosition();

            IsBattlePrepared = true;
            
            StartBattle();
        }

        private void StartBattle()
        {
            IsBattleEnable = true;

            var playerHealthToSub = 0;
            var computerHealthToSub = 0;

            foreach (var keyValuePairPlayerDice in _playerDiceTypeCount)
            {
                if (keyValuePairPlayerDice.Key.Equals(Dice.DiceType.MALE_ATTACK))
                {
                    computerHealthToSub += keyValuePairPlayerDice.Value;

                    if (_computerDiceTypeCount.ContainsKey(Dice.DiceType.MALE_BLOCK))
                    {
                        computerHealthToSub -= _computerDiceTypeCount[Dice.DiceType.MALE_BLOCK];
                    }
                }
                
                if (keyValuePairPlayerDice.Key.Equals(Dice.DiceType.DISTANCE_ATTACK))
                {
                    computerHealthToSub += keyValuePairPlayerDice.Value;

                    if (_computerDiceTypeCount.ContainsKey(Dice.DiceType.DISTANCE_BLOCK))
                    {
                        computerHealthToSub -= _computerDiceTypeCount[Dice.DiceType.DISTANCE_BLOCK];
                    }
                }
            }
            
            foreach (var keyValuePairComputerDice in _computerDiceTypeCount)
            {
                if (keyValuePairComputerDice.Key.Equals(Dice.DiceType.MALE_ATTACK))
                {
                    playerHealthToSub += keyValuePairComputerDice.Value;

                    if (_playerDiceTypeCount.ContainsKey(Dice.DiceType.MALE_BLOCK))
                    {
                        playerHealthToSub -= _playerDiceTypeCount[Dice.DiceType.MALE_BLOCK];
                    }
                }
                
                if (keyValuePairComputerDice.Key.Equals(Dice.DiceType.DISTANCE_ATTACK))
                {
                    playerHealthToSub += keyValuePairComputerDice.Value;

                    if (_playerDiceTypeCount.ContainsKey(Dice.DiceType.DISTANCE_BLOCK))
                    {
                        playerHealthToSub -= _playerDiceTypeCount[Dice.DiceType.DISTANCE_BLOCK];
                    }
                }
            }

            playerHealthToSub = Math.Abs(playerHealthToSub);
            playerHealthToSub = Math.Max(0, playerHealthToSub);
            if (playerHealthToSub > _player.Lifes.Count)
            {
                playerHealthToSub = _player.Lifes.Count;
            }

            computerHealthToSub = Math.Abs(computerHealthToSub);
            computerHealthToSub = Math.Max(0, computerHealthToSub);
            if (computerHealthToSub > _computer.Lifes.Count)
            {
                computerHealthToSub = _computer.Lifes.Count;
            }
            
            _player.Lifes.RemoveRange(0, playerHealthToSub);
            _computer.Lifes.RemoveRange(0, computerHealthToSub);
        }

        private void CopyDice()
        {
            _player.DiceOnTable.ForEach(dice =>
            {
                _playerDices.Add(dice);

                if (_playerDiceTypeCount.ContainsKey(dice.Type))
                {
                    _playerDiceTypeCount[dice.Type] += 1;
                }
                else
                {
                    _playerDiceTypeCount.Add(dice.Type, 1);
                }
            });
            
            _computer.DiceOnTable.ForEach(dice =>
            {
                _computerDices.Add(dice);

                if (_computerDiceTypeCount.ContainsKey(dice.Type))
                {
                    _computerDiceTypeCount[dice.Type] += 1;
                }
                else
                {
                    _computerDiceTypeCount.Add(dice.Type, 1);
                }
            });
        }

        private void SetDiceTargetPosition()
        {
            foreach (var computerDice in _computerDices)
            {
                computerDice.TargetPosition = new Vector2i(computerDice.Position.x, computerDice.Position.y + 50);
            }

            foreach (var playerDice in _playerDices)
            {
                playerDice.TargetPosition = new Vector2i(playerDice.Position.x, playerDice.Position.y - 50);
            }
        }

        public void Reset()
        {
            IsBattleEnable = false;
            IsBattlePrepared = false;
            
            _playerDices = new List<Dice>();
            _computerDices = new List<Dice>();
            
            _playerDiceTypeCount = new Dictionary<Dice.DiceType, int>();
            _computerDiceTypeCount = new Dictionary<Dice.DiceType, int>();
        }
        
        private bool isAnyDiceChangePosition()
        {
            foreach (var dice in _playerDices)
            {
                if (dice.isChangePosition())
                {
                    return true;
                }
            }
            
            foreach (var dice in _computerDices)
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