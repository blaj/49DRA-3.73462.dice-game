using Microsoft.Xna.Framework;

namespace DiceGame.Utils
{
    public class Vector2i
    {
        public int x { get; set; }
        
        public int y { get; set; }

        public Vector2i()
        {
            this.x = 0;
            this.y = 0;
        }

        public Vector2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}