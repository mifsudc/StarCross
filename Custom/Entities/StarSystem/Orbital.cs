using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Input;

namespace Custom
{
    /// <summary>
    /// Star orbiting destructible object
    /// </summary>
    class Orbital : GameObject
    {
        protected ParticleBase _particleBase;
        protected int _rotRate;
        protected Vector2 _accelPoint, _accel;

        public Orbital(Vector2 pos, float rot, float aMom, ParticleBase particleBase, int rotRate)
        {
            _pos = pos;
            _rotation = rot;
            _aMomentum = aMom;
            _particleBase = particleBase;
            _rotRate = rotRate;
            _accelPoint = new Vector2(1500, 1500);
            _accel = (_accelPoint - _pos) / _rotRate / _rotRate;
            _vel = (_accelPoint - _pos).PerpendicularCounterClockwise() / _rotRate;
        }

        public override void Draw(SpriteBatch spritebatch, Vector2 locality)
        {
            spritebatch.Draw(_particleBase.Tex, Pos + locality, null, _particleBase.Colour, _rotation, _particleBase.CentrePt, _particleBase.Size, SpriteEffects.None, 1f);
        }

        public override void Update()
        {
            _accel = (_accelPoint - _pos) / _rotRate / _rotRate;
            Accelerate(_accel);
            _pos += _vel;
            Rotate(_aMomentum);
        }

        // Unused overload
        public override void Draw(SpriteBatch spritebatch) { }

        // Shoots 50 explosion particles in a circle
        public void Explode()
        {
            for (int i = 0; i < 50; i++)
            {
                var dir = (GM.instance.rnd.Next(360)) * Math.PI / 180;
                var spd = (GM.instance.rnd.Next(10, 30));
                GM.instance.State.CreateGameObject(
                    GameObjType.particle,                               // Create particle
                    new Vector2(                                        // Position
                        Pos.X - _centrePt.X * (float)Math.Cos(_rotation),
                        Pos.Y - _centrePt.Y * (float)Math.Sin(_rotation)
                    ), 
                    new Vector2(                                        // Velocity random
                        0 - (float)Math.Cos(dir) * spd,
                        0 - (float)Math.Sin(dir) * spd
                    ),
                    _rotation, 0f,                                      // Particle rotation and aMom moot
                    20,                                                 // Time to live in frames
                    GM.instance.ParticleBases["exhaust"]);              // Explosion particle same as exhaust
            }
        }
    }
}
