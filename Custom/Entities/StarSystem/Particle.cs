using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Custom
{
    /// <summary>
    /// Decaying point particle
    /// </summary>
    public class Particle : GameObject, IDecay
    {
        private int _ttl;
        private ParticleBase _particleBase;

        public Particle(Vector2 pos, Vector2 vel, float rot, float aMom, int ttl, ParticleBase particleBase)
        {
            _pos = pos;
            _vel = vel;
            _rotation = rot;
            _aMomentum = aMom;
            _ttl = ttl;
            _particleBase = particleBase;
        }

        public override void Update()
        {
            _ttl--;
            _pos += _vel;
            _rotation += _aMomentum;
        }

        public override void Draw(SpriteBatch spritebatch, Vector2 locality)
        {
            spritebatch.Draw(_particleBase.Tex, Pos + locality, null, _particleBase.Colour, _rotation, _centrePt, _particleBase.Size, SpriteEffects.None, 1f);
        }

        public int TTL { get => _ttl; }

        // Unused overload
        public override void Draw(SpriteBatch spritebatch) { }
    }
}