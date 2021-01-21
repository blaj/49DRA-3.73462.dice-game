using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiceGame.Engine
{
    public class Text: GameElement
    {
        private SpriteFont _font;

        public Vector2i Position { get; set; }
        public Color PenColour { get; set; }
        public string TextString { get; set; }
        public bool IsDrawStartCenter { get; set; }

        public Text(SpriteFont font)
        {
            _font = font;
            PenColour = Color.Black;
            IsDrawStartCenter = false;
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var x = Position.x;
            var y = Position.y;

            if (IsDrawStartCenter)
            {
                x -= (int) _font.MeasureString(TextString).X / 2;
                y -= (int) _font.MeasureString(TextString).Y / 2;
            }
            
            spriteBatch.DrawString(_font, TextString, new Vector2(x, y), PenColour);
        }

        public override void Update(GameTime gameTime)
        {
        }

        public enum StartDrawDirection
        {
            
        }
    }
}