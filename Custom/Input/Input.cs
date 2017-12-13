using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Custom
{   
    /// <summary>
    /// All input methods and states are defined her
    /// </summary>
    public static class Input
    {
        /// <summary>
        /// State of keyboard last tick
        /// </summary>
        public static KeyboardState oldKeyboardState;

        /// <summary>
        /// State of keyboard this tick
        /// </summary>
        public static KeyboardState currentKeyboardState = Keyboard.GetState();

        /// <summary>
        /// State of Mouse last tick
        /// </summary>
        public static MouseState oldMouseState;

        /// <summary>
        /// State of mouse this tick
        /// </summary>
        public static MouseState currentMouseState = Mouse.GetState();

        /// <summary>
        /// Returns whether the key is down this tick
        /// </summary>
        public static bool KeyDown(Keys keyCode)
        {
            return currentKeyboardState.IsKeyDown(keyCode);
        }

        /// <summary>
        /// Returns whether the mouse is down this tick
        /// </summary>
        public static bool MouseDown()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Returns whether the key was pressed this tick
        /// </summary>
        public static bool KeyPressed(Keys keyCode)
        {
            return oldKeyboardState.IsKeyUp(keyCode) && currentKeyboardState.IsKeyDown(keyCode);
        }

        /// <summary>
        /// Returns location of mouse this tick
        /// </summary>
        public static Vector2 MousePos()
        {
            return currentMouseState.Position.ToVector2();
        }

        /// <summary>
        /// Updates old and current keyboard and mouse states
        /// </summary>
        public static void Update()
        {
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            oldMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }
    }
}
