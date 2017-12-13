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
    /// A single game actor. Player controlled or NPC status
    /// is dependant upon type of input controller
    /// </summary>
    public class Actor : GameObject, IGravitable
    {
        private ForceController fCont;

        public Actor(ActorType acType) : base()
        {
            _tex = Resources.actor;
            _centrePt = new Vector2(_tex.Width / 2, _tex.Height / 2);
            switch (acType)
            {
                case ActorType.pc:
                    fCont = new PlayerController();
                    break;
                case ActorType.npc:
                    // fCont = new BotController();
                    break;
            }
        }
        
        public override void Update()
        {
            Force f = fCont.Update();
            // accelerate/rotate on input
            if (f.Up)
            {
                Accelerate( new Vector2((float)Math.Cos(_rotation) / 40, (float)Math.Sin(_rotation) / 40) );
                ShootExhaust();
            }
            if (f.Down)
            {
                _vel *= 0.9f;
            }
            if (f.Left)
            {
                Rotate(-0.05f);
            }
            if (f.Right)
            {
                Rotate(0.05f);
            }
            // Test reset position
            if (Input.KeyPressed(Keys.R))
            {
                Pos = new Vector2(1501, 1501);
                _vel = new Vector2(0, 0);
            }
            // Shoot bullet
            if (Input.KeyPressed(Keys.Space) && GM.instance.State.Shoot == null)
            {
                GM.instance.State.CreateGameObject(GameObjType.bullet, Pos, _rotation);
            }

            // test return to galaxy
            if (Input.KeyPressed(Keys.Back))
            {
                ReturnToGalaxy();
            }

            Pos += _vel;
            Rotate(_aMomentum);

            // Return to galaxy if at edge of solar system
            if (!GM.instance.MapBounds.Contains(Pos))
            {
                ReturnToGalaxy();
            }
        }

        public override void Draw(SpriteBatch spritebatch, Vector2 locality)
        {
            spritebatch.Draw(_tex, Pos + locality, _rotation, _centrePt, null);
            spritebatch.DrawString(Resources.testFont, String.Concat("Pos: ", Pos.ToString()), new Vector2(100, 100), Color.White);
            spritebatch.DrawString(Resources.testFont, String.Concat("Spd: ", _vel.Length().ToString()), new Vector2(100, 150), Color.White);

        }

        /// <summary>
        /// Accelerates the player towards a point
        /// </summary>
        /// <param name="force">Point of acceleration</param>
        public void BeAttracted(Vector2 force)
        {
            _vel += force;
        }

        /// <summary>
        /// Accelerates the player away from a point
        /// </summary>
        /// <param name="force">Point of acceleration</param>
        public void BeRepulsed(Vector2 force)
        {
            _vel -= force;
        }

        /// <summary>
        /// Fires an exhaust particle from the back
        /// of the player's ship
        /// </summary>
        private void ShootExhaust()
        {
            var exhaustDir = _rotation + ((GM.instance.rnd.Next(0, 31) - 15) * Math.PI / 80);                                    // Exhaust direction is pi/8 about ship axis of rotation
            GM.instance.State.CreateGameObject(
                GameObjType.particle,                  // Create particle
                new Vector2(                           // Particle initial position back of ship
                    Pos.X - _centrePt.X * (float)Math.Cos(_rotation),
                    Pos.Y - _centrePt.Y * (float)Math.Sin(_rotation)
                ), 
                new Vector2(                           // Particle velocity reciprocal to thrust
                    0 - (float)Math.Cos(exhaustDir) * 10,
                    0 - (float)Math.Sin(exhaustDir) * 10
                ),                         
                _rotation, 0f,                                                                                                   // particle rotation and aMom moot
                30,                                    // Time to live in frames
                GM.instance.ParticleBases["exhaust"]); // Particle is an exhaust particle
        }

        // Unused overload
        public override void Draw(SpriteBatch spritebatch) { }

        /// <summary>
        /// Returns the player to the
        /// galaxy view
        /// </summary>
        public void ReturnToGalaxy()
        {
            GM.instance.State = GM.instance.Gal;
            Pos = new Vector2(100, 100);
            _vel = new Vector2();
        }
    }

    /// <summary>
    /// Type of actor:
    ///     - Player
    ///     - Bot
    /// </summary>
    public enum ActorType
    {
        pc,
        npc
    }
}