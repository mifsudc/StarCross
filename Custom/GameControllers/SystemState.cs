using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace Custom
{
    /// <summary>
    /// Game-state for traversing a star system
    /// </summary>
    class SystemState : GameState
    {
        private List<IDecay> Decayables;
        public CelestialObject Star;
        public Actor User;

        public SystemState() : base()
        {
            User = GM.instance.User;
            Decayables = new List<IDecay>();
        }

        public override void Update()
        {
            // Change particle colours
            Color newColour;
            // Exhaust/explosion colour
            switch (GM.instance.rnd.Next(3))
            {
                case 1:
                    newColour = Color.Orange;
                    break;
                case 2:
                    newColour = Color.OrangeRed;
                    break;
                default:
                    newColour = Color.Red;
                    break;
            }
            GM.instance.ParticleBases["exhaust"].Colour = newColour;
            // Accretion disk colour
            switch (GM.instance.rnd.Next(6))
            {
                case 1:
                    newColour = Color.BlueViolet;
                    break;
                case 2:
                    newColour = Color.Red;
                    break;
                case 3:
                    newColour = Color.Purple;
                    break;
                case 4:
                    newColour = Color.PaleVioletRed;
                    break;
                case 5:
                    newColour = Color.Blue;
                    break;
                default:
                    newColour = Color.Purple;
                    break;
            }
            GM.instance.ParticleBases["accretion"].Colour = newColour;

            // Update system objects
            foreach (GameObject obj in Objs)
            {
                obj.Update();
            }

            // Add queued objects to world
            UnqueueObjects();

            // Decay everything
            for (int i = Decayables.Count - 1; i > -1; i--)
            {
                if (Decayables[i].TTL < 0)
                {
                    var remove = Decayables[i];
                    if (remove.Equals(Shoot))
                    {
                        Shoot = null;
                    }
                    Decayables.RemoveAt(i);
                    Objs.Remove(remove as GameObject);
                }
                else
                {
                    break;
                }
            }

            // Attract to star
            Star.Attract(User as IGravitable);

            // Check collisions
            if (Shoot != null)
            {
                for (int i = Orbs.Count - 1; i > -1; i--)
                {
                    if ((Shoot.Pos - Orbs[i].Pos).Length() < 50)
                    {
                        Orbs[i].Explode();
                        Objs.Remove(Orbs[i] as GameObject);
                        Orbs.RemoveAt(i);
                        Objs.Remove(Shoot);
                        Shoot = null;
                        break;
                    }
                }
            }
        }

        public override void Render(SpriteBatch spritebatch)
        {
            GM.instance.Cam.Render(Objs, spritebatch);
        }

        /// <summary>
        /// Remove objects from creation queue and
        /// add to object registry
        /// </summary>
        public void UnqueueObjects()
        {
            for (int i = CreationQueue.Count - 1; i > -1; i--)
            {
                Objs.Add(CreationQueue[i]);

                // Add to decayable registry and sort registry by time to live
                IDecay decay = CreationQueue[i] as IDecay;
                if (decay != null)
                {
                    Decayables.Add(decay);
                    Decayables = Decayables.OrderByDescending(d => d.TTL).ToList();
                }

                CreationQueue.RemoveAt(i);
            }
        }
    }
}
