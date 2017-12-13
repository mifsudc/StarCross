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
    /// Decaying player shot bullet
    /// </summary>
    public class Bullet : GameObject, IDecay
    {
        private int _ttl;

        public Bullet(Vector2 source, float rotation) : base(source,
            new Vector2( 15 * (float) Math.Cos(rotation), 15 * (float) Math.Sin(rotation) ),
            rotation, 0)
        {
            _ttl = 100;
            _tex = Resources.bullet;
        }

        public override void Update()
        {
            Pos += _vel;
            _rotation += _aMomentum;
            _ttl--;
        }

        public override void Draw(SpriteBatch spritebatch, Vector2 locality)
        {
            spritebatch.Draw(_tex, Pos + locality, _rotation, _centrePt, null);
        }

        public int TTL { get => _ttl; }

        // Unused overload
        public override void Draw(SpriteBatch spritebatch) { }
    }
}
