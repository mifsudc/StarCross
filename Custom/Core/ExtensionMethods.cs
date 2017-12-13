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
    /// Extension methods of the game
    /// </summary>
    static class ExtensionMethods
    {
        /// <summary>
        /// More usable draw function
        /// </summary>
        public static void Draw(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position, float rotation, Vector2 origin, Rectangle? source, float scale = 1.0f)
        {
            spriteBatch.Draw(texture, position, source, Color.White, rotation, origin, scale, SpriteEffects.None, 1);
        }
    }
}
