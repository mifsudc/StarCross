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
    /// Base game-state class
    /// </summary>
    abstract class GameState
    {
        public List<GameObject> Objs;
        public List<GameObject> CreationQueue;
        public List<Orbital> Orbs;
        public Bullet Shoot;

        public GameState()
        {
            Objs = new List<GameObject>();
            CreationQueue = new List<GameObject>();
            Orbs = new List<Orbital>();
        }

        public abstract void Update();
        public abstract void Render(SpriteBatch spriteBatch);

        /// <summary>
        /// Create a game object and add it to the object registry
        /// </summary>
        /// <param name="type">Type of object to be created</param>
        /// <param name="args">Args for object constructor. Refer to comments</param>
        public GameObject CreateGameObject(GameObjType type, params object[] args)
        {
            // Untyped resultant variable
            GameObject result = null;

            switch (type)
            {
                case GameObjType.pc:
                    result = new Actor(ActorType.pc);   // ActorType player character
                    break;

                // Reserved
                case GameObjType.npc:
                    result = new Actor(ActorType.npc);  // ActorType bot character
                    break;

                case GameObjType.bullet:
                    result = new Bullet(
                        (Vector2)args[0],       // Vector2 source position
                        (float)args[1]          // float rotation
                    );
                    Shoot = result as Bullet;   // One bullet exists at a time
                    break;

                case GameObjType.celestialObj:
                    result = new CelestialObject(
                        (CelesObjType)args[0],  // CelesObjectType type of star
                        (float)args[1],         // float mass    
                        (float)args[2]          // float size
                    );
                    break;

                // Params: 
                case GameObjType.orbital:
                    result = new Orbital(
                        (Vector2)args[0],       // Vector2 position
                        (float)args[1],         // float rotation
                        (float)args[2],         // float angular velocity
                        (ParticleBase)args[3],  // ParticleBase base for type of orbital 
                        (int)args[4]            // int Orbital rotation rate
                    );
                    Orbs.Add(result as Orbital);
                    break;

                case GameObjType.particle:
                    result = new Particle(
                        (Vector2)args[0],       // Vector2 position
                        (Vector2)args[1],       // Vector2 velocity
                        (float)args[2],         // float rotation
                        (float)args[3],         // float angular velocity
                        (int)args[4],           // int time to live
                        (ParticleBase)args[5]   // ParticleBase base for type of particle
                    );
                    break;

                case GameObjType.galaxy:        // Params: nil
                    result = new Galaxy();
                    break;
            }

            // Add to object registry
            CreationQueue.Add(result);

            return result;
        }
    }
}
