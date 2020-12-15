using System;
using DiceGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DiceGame.Engine
{
    public class Button: GameElement
    {
        private MouseState _currentMouseState;
        private SpriteFont _font;
        private bool _isHovering;
        private MouseState _previousMouseState;
        private Texture2D _texture;

        public event EventHandler Click;
        public Color PenColour { get; set; }
        public Vector2i Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                var x = Position.x;
                var y = Position.y;

                if (IsDrawStartCenter)
                {
                    x -= _texture.Width / 2;
                    y -= _texture.Height / 2;
                }
                
                return new Rectangle(x, y, _texture.Width, _texture.Height);
            }
        }
        
        public string Text { get; set; }
        public bool IsDrawStartCenter { get; set; }
        
        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;
            PenColour = Color.Black;
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;

            if (_isHovering)
            {
                color = Color.Gray;
            }
            
            spriteBatch.Draw(_texture, Rectangle, color);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);
                
                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            
            var mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
                {
                    if (Click != null)
                    {
                        AssetManager.buttonClickAudio.Play();
                        Click.Invoke(this, new EventArgs());
                    }
                }
            }
        }
    }
}