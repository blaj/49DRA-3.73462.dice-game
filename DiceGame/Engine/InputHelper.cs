using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DiceGame.Helpers
{
    public class InputHelper
    {
        private static KeyboardState currentKeyboardState = new KeyboardState();
        private static KeyboardState lastKeyboardState = new KeyboardState();
        private static MouseState lastMouseState = new MouseState();
        private static MouseState currentMouseState = new MouseState();

        public static bool IsNewLeftClick()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed &&
                   lastMouseState.LeftButton == ButtonState.Released;
        }

        public static bool IsNewRightClick()
        {
            return currentMouseState.RightButton == ButtonState.Pressed &&
                   lastMouseState.RightButton == ButtonState.Released;
        }

        public static Point GetMousePosition()
        {
            return new Point(currentMouseState.X, currentMouseState.Y);    
        }

        public static bool IsNewKeyPress(params Keys[] keys)
        {
            return keys.Any(k => (currentKeyboardState.IsKeyDown(k) &&
                                  lastKeyboardState.IsKeyUp(k)));
        }

        public static bool IsCurrentlyPressed(params Keys[] keys)
        {
            return keys.Any(k => currentKeyboardState.IsKeyDown(k));
        }

        public static void UpdateStates()
        {
            UpdateKeyboardState();
            UpdateMouseState();
        }
        
        private static void UpdateKeyboardState()
        {
            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }

        private static void UpdateMouseState()
        {
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }
    }
}