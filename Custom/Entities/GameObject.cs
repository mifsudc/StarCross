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
    /// Base class for all drawable game objects
    /// </summary>
    public abstract class GameObject
    {
        protected Vector2 _pos;
        protected Vector2 _vel;
        protected Texture2D _tex;
        protected float _rotation;
        protected float _aMomentum;
        protected Vector2 _centrePt;

        public GameObject(Vector2 pos, Vector2 vel, float rotation, float aMomentum)
        {
            _pos = pos;
            _vel = vel;
            _rotation = rotation;
            _aMomentum = aMomentum;
        }

        public GameObject(Vector2 pos) : this(pos, new Vector2(0, 0), (float)Math.PI / 2, 0)
        {
            
        }

        /// <summary>
        /// Accelerate in a direction
        /// </summary>
        /// <param name="force">The force vector to apply to the object's velocity</param>
        public void Accelerate(Vector2 force)
        {
            _vel += force;
        }

        /// <summary>
        /// Rotate clockwise
        /// </summary>
        /// <param name="rotation">The amount to rotate the object</param>
        public void Rotate(float rotation)
        {
            _rotation += rotation;
        }

        public GameObject() : this(new Vector2(100, 100))
        {

        }
        
        /// <summary>
        /// Update game object once per frame
        /// </summary>
        public abstract void Update();
        /// <summary>
        /// Draw object on screen relative to another object
        /// </summary>
        /// <param name="locality">Relative focus object</param>
        public abstract void Draw(SpriteBatch spritebatch, Vector2 locality);
        /// <summary>
        /// Draw object on screen
        /// </summary>
        public abstract void Draw(SpriteBatch spritebatch);

        public float Rotation { get => _rotation; }
        public Vector2 Pos { get => _pos; set => _pos = value; }
        public Vector2 CentrePoint { get => _centrePt; }
    }

    /// <summary>
    /// Different types of game objects
    /// </summary>
    public enum GameObjType
    {
        pc,
        npc,
        orbital,
        particle,
        celestialObj,
        bullet,
        galaxy
    }
}
