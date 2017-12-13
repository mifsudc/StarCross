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
    /// Fundamental game controller. Keeps track of all game objects
    /// and gamestates, and calls their update and draw functions.
    /// </summary>
    class GM
    {
        public static GM instance;
        
        public Random rnd;
        public GameState State;
        public SystemBuilder Builder;
        public GalaxyState Gal;

        public Actor User;

        public Camera Cam;
        public Dictionary<string, ParticleBase> ParticleBases;
        public Rectangle MapBounds;

        public GM()
        {
            if (instance != null)
            {
                throw new Exception("There can only be one GM");
            }
            else
            {
                instance = this;
            }

            Builder = new SystemBuilder();
            rnd = new Random((int)DateTime.Now.Ticks);
            ParticleBases = new Dictionary<string, ParticleBase>();
            ParticleBases.Add("exhaust", new ParticleBase(Resources.particle, Color.Red, 1.0f));
            ParticleBases.Add("marker", new ParticleBase(Resources.marker, Color.White, 1.0f));
            ParticleBases.Add("asteroid", new ParticleBase(Resources.particle, Color.Gray, 3.0f));
            ParticleBases.Add("planet", new ParticleBase(Resources.planet, Color.White, 0.7f));
            ParticleBases.Add("accretion", new ParticleBase(Resources.particle, Color.Purple, 1.0f));
            ParticleBases.Add("alien", new ParticleBase(Resources.npc, Color.White, 1.0f));

            User = new Actor(ActorType.pc);
            Cam = new Camera(User);
            State = Gal = new GalaxyState();
            MapBounds = new Rectangle(0, -500, 3000, 4000);
        }

        /// <summary>
        /// Updates gamestate and input
        /// </summary>
        public void Update()
        {
            State.Update();
            Input.Update();
        }

        /// <summary>
        /// Calls relevant state to draw objects to the screen
        /// </summary>
        public void Render(SpriteBatch spriteBatch)
        {
            State.Render(spriteBatch);
        }
    }
}
