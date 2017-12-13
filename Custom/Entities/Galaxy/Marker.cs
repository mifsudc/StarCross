using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended;

namespace Custom
{
    /// <summary>
    /// Galaxy view marker of solar systems.
    /// Corresponds to one solar system
    /// </summary>
    class Marker : Orbital
    {
        private SystemState _starSystem;

        public Marker(Vector2 pos) : base(pos, 0, 0, GM.instance.ParticleBases["marker"], 1000)
        {
            _tex = Resources.marker;
            _centrePt = new Vector2(_tex.Width / 2, _tex.Height / 2);
            _accelPoint = new Vector2(Constant.screenWidth / 2, Constant.screenHeight / 2);
            _accel = (_accelPoint - _pos) / _rotRate / _rotRate;
            _vel = (_accelPoint - _pos).PerpendicularCounterClockwise() / _rotRate;
            _starSystem = GM.instance.Builder.BuildSystem();
        }

        public override void Update()
        {
            _accel = (_accelPoint - _pos) / _rotRate / _rotRate;
            _vel += _accel;
            _pos += _vel;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_tex, _pos, _rotation, _centrePt, null);
        }

        /// <summary>
        /// Checks if mouse clicked in marker bounds.
        /// If so, transports player to associated star-system
        /// </summary>
        public void RecieveNotice(Vector2 MousePos)
        {
            Rectangle check = _tex.Bounds;
            check.Location = new Vector2(_pos.X - _tex.Width , _pos.Y - (_tex.Height / 2)).ToPoint();
            if (check.Contains(MousePos))
            {
                GM.instance.State = _starSystem;
            }
        }

        // Unused overload
        public override void Draw(SpriteBatch spritebatch, Vector2 locality) { }
    }
}
