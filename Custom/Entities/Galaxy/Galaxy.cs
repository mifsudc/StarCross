using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Custom
{
    /// <summary>
    /// Rotating feature of the galaxy view
    /// </summary>
    public class Galaxy : GameObject
    {
        public Galaxy() : base( new Vector2(), new Vector2(), 0f, -0.001f )
        {
            _tex = Resources.galaxy;
            _centrePt = new Vector2(_tex.Width / 2, _tex.Height / 2);
            _pos.X = Constant.screenWidth / 2;
            _pos.Y = Constant.screenHeight / 2;
        }

        public override void Update()
        {
            Rotate(_aMomentum);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_tex, _pos, _rotation, _centrePt, null, 2.7f);
        }

        // Unused overload
        public override void Draw(SpriteBatch spritebatch, Vector2 locality) { }
    }
}
