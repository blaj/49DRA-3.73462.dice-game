using System;
using DiceGame.Helpers;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DiceGame.Engine
{
    public class Button: GameElement
    {
        private SpriteFont _font;
        private bool _isHovering;
        private Texture2D _texture;

        public event EventHandler Click;
        public Color PenColour { get; set; }
        public Vector2i Position { get; set; }

        public bool isHide { get; set; }
        
        public Rectangle Rectangle
        {
            get
            {
                var x = Position.x;
                var y = Position.y;

                var width = Text.Length * 20;
                
                if (IsDrawStartCenter)
                {
                    x -= width / 2;
                    y -= _texture.Height / 2;
                }
                
                return new Rectangle(x, y, width, _texture.Height);
            }
        }
        
        public string Text { get; set; }
        public bool IsDrawStartCenter { get; set; }
        
        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;
            PenColour = Color.Black;
            isHide = false;
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isHide)
            {
                return;
            }
            
            var color = Color.White;

            if (_isHovering)
            {
                color = Color.Gray;
            }
            
            spriteBatch.Draw(_texture, Rectangle, color);

            if (string.IsNullOrEmpty(Text))
            {
                return;
            }
            
            var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
            var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);
                
            spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
        }

        public override void Update(GameTime gameTime)
        {
            if (isHide)
            {
                return;
            }
            
            var mouseRectangle = new Rectangle(InputHelper.GetMousePosition().X, InputHelper.GetMousePosition().Y, 1, 1);

            _isHovering = false;

            if (!mouseRectangle.Intersects(Rectangle))
            {
                return;
            }
            
            _isHovering = true;

            if (!InputHelper.IsNewLeftClick())
            {
                return;
            }

            if (Click == null)
            {
                return;
            }
            
            AssetManager.buttonClickAudio.Play();
            Click.Invoke(this, new EventArgs());
        }
    }
}