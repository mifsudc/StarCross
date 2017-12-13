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
    /// Game-state for viewing galaxy map
    /// </summary>
    class GalaxyState : GameState
    {
        private MouseNotifier _mouseObs;

        public GalaxyState() : base()
        {
            _mouseObs = new MouseNotifier();

            // Create star-system markers
            for (int i = 0; i < 13; i++)
            {
                CreationQueue.Add( CreateMarker() );
            }
            // Create galaxy
            CreateGameObject(GameObjType.galaxy);
        }

        /// <summary>
        /// Update all game objects
        /// </summary>
        public override void Update()
        {
            // Update GameObjects in world
            foreach (GameObject obj in Objs)
            {
                obj.Update();
            }

            // Add queued objects to world
            for (int i = CreationQueue.Count - 1; i > -1; i--)
            {
                Objs.Add(CreationQueue[i]);
                CreationQueue.RemoveAt(i);
            }

            _mouseObs.Update();
        }

        /// <summary>
        /// Draw background, galaxy and markers 
        /// </summary>
        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resources.background, new Vector2(), Color.White);

            foreach (GameObject obj in Objs)
            {
                obj.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Creates and returns a star-system marker
        /// </summary>
        private Marker CreateMarker()
        {
            // New resultant marker somewhere on screen
            Marker result = new Marker(new Vector2(
                GM.instance.rnd.Next(Constant.screenWidth - 400) + 200,
                GM.instance.rnd.Next(Constant.screenHeight - 200) + 100)
            );

            // Subscribe to mouse observer
            _mouseObs.AddSubscriber(result);

            return result;
        }
    }
}
