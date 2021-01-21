using System.IO;
using DiceGame.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Player
{
    public class Table : GameElement
    {
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AssetManager.tableTexture,
                new Rectangle(0, 0, Config.Config.WINDOW_WIDHT, Config.Config.WINDOW_HEIGHT), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}