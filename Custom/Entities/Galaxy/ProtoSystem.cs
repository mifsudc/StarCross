using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended;

namespace Custom
{
    /// <summary>
    /// Builder object for solar systems
    /// </summary>
    class ProtoSystem
    {
        private SystemState _system;

        public ProtoSystem()
        {
            _system = new SystemState();
        }

        /// <summary>
        /// Creates and adds a star to protosystem
        /// </summary>
        /// <param name="type">Type of star to create</param>
        public ProtoSystem AddStar(CelesObjType type)
        {
            float size = 1.5f, mass = 1f;
            // Create star
            switch (type)
            {
                case CelesObjType.OStar:
                    size = (float)GM.instance.rnd.Next(20, 25) / 10;
                    mass = (float)GM.instance.rnd.Next(10, 15) / 10;
                    break;
                case CelesObjType.BStar:
                    size = (float)GM.instance.rnd.Next(13, 17) / 10;
                    mass = (float)GM.instance.rnd.Next(8, 13) / 10;
                    break;
                case CelesObjType.AStar:
                    size = (float)GM.instance.rnd.Next(12, 15) / 10;
                    mass = (float)GM.instance.rnd.Next(7, 12) / 10;
                    break;
                case CelesObjType.FStar:
                    size = (float)GM.instance.rnd.Next(10, 17) / 10;
                    mass = (float)GM.instance.rnd.Next(10, 15) / 10;
                    break;
                case CelesObjType.GStar:
                    size = (float)GM.instance.rnd.Next(10, 15) / 10;
                    mass = (float)GM.instance.rnd.Next(10, 15) / 10;
                    break;
                case CelesObjType.KStar:
                    size = (float)GM.instance.rnd.Next(10, 15) / 10;
                    mass = (float)GM.instance.rnd.Next(10, 15) / 10;
                    break;
                case CelesObjType.MStar:
                    size = (float)GM.instance.rnd.Next(10, 25) / 10;
                    mass = (float)GM.instance.rnd.Next(10, 15) / 10;
                    break;
                case CelesObjType.BlackHole:
                    size = 0.3f;
                    mass = (float)GM.instance.rnd.Next(15, 20) / 10;
                    break;
                case CelesObjType.WhiteDwarf:
                    size = (float)GM.instance.rnd.Next(3, 7) / 10;
                    mass = (float)GM.instance.rnd.Next(5, 15) / 10;
                    break;
                case CelesObjType.Alien:
                    size = 1.2f;
                    mass = 0.01f;
                    break;
            }

            // Add to system
            _system.Star = _system.CreateGameObject(
                GameObjType.celestialObj,       // Create Star
                type,                           // Type of star
                mass,                           // Mass
                size                            // Size
            ) as CelestialObject;
            return this;
        }

        /// <summary>
        /// Creates and adds 300 asteroids to protosystem
        /// </summary>
        public ProtoSystem AddAsteroids()
        {
            int start = GM.instance.rnd.Next(500, 1000);            // Distance of asteroid belt
            int width = GM.instance.rnd.Next(100, 500);             // Width of belt
            for (int i = 0; i < 300; i++)
            {
                int r = GM.instance.rnd.Next(start, start + width); // Distance from centre
                float rand = (GM.instance.rnd.Next(360));
                float theta = rand / 180 * (float) Math.PI;         // Angle about centre in rads
                Vector2 pos = new Vector2( r * (float) Math.Cos( theta ), r * (float) Math.Sin( theta ) );

                // Add to system
                _system.CreateGameObject(
                    GameObjType.orbital,                            // Create orbital
                    pos + _system.Star.Pos,                         // Starting position
                    theta,                                          // Starting rotation
                    (float) GM.instance.rnd.Next(10) / 100,         // Angular momentum
                    GM.instance.ParticleBases["asteroid"],          // Type asteroid
                    GM.instance.rnd.Next(450, 550)                  // Orbital rotation rate
                );
            }
            return this;
        }

        /// <summary>
        /// Creates and adds 1-4 planets to protosystem
        /// </summary>
        public ProtoSystem AddPlanets()
        {
            for (int i = 0; i < GM.instance.rnd.Next(1, 4); i++)
            {
                int r = GM.instance.rnd.Next(700, 1500);                // Distance from centre
                float rand = (GM.instance.rnd.Next(360));
                float theta = rand / 180 * (float)Math.PI;              // Angle about centre in rads
                Vector2 pos = new Vector2(r * (float)Math.Cos(theta), r * (float)Math.Sin(theta));

                // Add to system
                _system.CreateGameObject(
                    GameObjType.orbital,                                // Create orbital
                    pos + _system.Star.Pos,                             // Starting position
                    theta,                                              // Starting rotation
                    ((float)GM.instance.rnd.Next(1, 10) - 5) / 1000,    // Angular momentum
                    GM.instance.ParticleBases["planet"],                // Type planet
                    800                                                 // Orbital rotation rate
                );
            }
            return this;
        }

        /// <summary>
        /// Creates and adds 1-4 aliens to protosystem
        /// </summary>
        public ProtoSystem AddAliens()
        {
            for (int i = 0; i < GM.instance.rnd.Next(1, 4); i++)
            {
                int r = GM.instance.rnd.Next(800, 1500);                // Distance from centre
                float rand = (GM.instance.rnd.Next(360));
                float theta = rand / 180 * (float)Math.PI;              // Angle about centre in rads
                Vector2 pos = new Vector2(r * (float)Math.Cos(theta), r * (float)Math.Sin(theta));

                // Add to system
                _system.CreateGameObject(
                    GameObjType.orbital,                                // Create orbital
                    pos + _system.Star.Pos,                             // Starting position
                    theta,                                              // Starting rotation
                    ((float)GM.instance.rnd.Next(1, 10) - 5) / 1000,    // Angular momentum
                    GM.instance.ParticleBases["alien"],                 // Type alien
                    800                                                 // Orbital rotation rate
                );
            }

            return this;
        }

        /// <summary>
        /// Creates and adds 600 accretion disk
        /// particles to protosystem
        /// </summary>
        public ProtoSystem AddDisc()
        {
            {
                for (int i = 0; i < 600; i++)
                {
                    int r = GM.instance.rnd.Next(150, 600);             // Distance from centre
                    float rand = (GM.instance.rnd.Next(360));
                    float theta = rand / 180 * (float)Math.PI;          // Angle about centre in rads
                    Vector2 pos = new Vector2(r * (float)Math.Cos(theta), r * (float)Math.Sin(theta));

                    // Add to system
                    _system.CreateGameObject(
                        GameObjType.orbital,                            // Create orbital
                        pos + _system.Star.Pos,                         // Starting position
                        theta,                                          // Starting rotation
                        (float)GM.instance.rnd.Next(10) / 100,          // Angular momentum
                        GM.instance.ParticleBases["accretion"],         // Type accretion particle
                        GM.instance.rnd.Next(50, 400)                   // Orbital rotation rate
                    );
                }
                return this;
            }
        }

        /// <summary>
        /// Builds the protosystem into a usable star-system
        /// </summary>
        /// <returns>The resultant star-system</returns>
        public SystemState Build()
        {
            _system.UnqueueObjects();
            _system.Objs.Add(GM.instance.User);
            return _system;
        }
    }
}
