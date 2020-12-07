using Microsoft.Xna.Framework.Graphics;

namespace DiceGame
{
    public interface GameElement
    {
        public void loadContent(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch);

        public void draw();

        public void update();
    }
}