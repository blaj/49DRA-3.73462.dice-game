using DiceGame.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Game
{
    public class Floor: GameElement
    {
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var amountWidth = Config.Config.WINDOW_WIDHT / 128;
            var amountHeight = Config.Config.WINDOW_HEIGHT / 128;
            
            for (int i = 0; i <= amountWidth; i++)
            {
                for (int j = 0; j <= amountHeight; j++)
                {
                    var x = i * 128;
                    var y = j * 128;
                    spriteBatch.Draw(
                        AssetManager.floorTexture, 
                        new Rectangle(
                            x,
                            y,
                            128,
                            128),
                        Color.White);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}