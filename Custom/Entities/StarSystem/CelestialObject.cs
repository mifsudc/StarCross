using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Custom
{
    /// <summary>
    /// Base class for solarsystem central objects
    /// </summary>
    class CelestialObject : GameObject
    {
        private float _mass;
        private float _size;
        private float _gravConst;
        private CelesObjType _type;

        public CelestialObject(CelesObjType type, float mass, float size) : base( new Vector2(1500, 1500) )
        {
            _mass = mass;
            _gravConst = _mass / 40;
            _size = size;
            SwitchType(type);
            _aMomentum = 0.01f;
            _centrePt = new Vector2(_tex.Width / 2, _tex.Height / 2);
        }

        public override void Draw(SpriteBatch spritebatch, Vector2 locality)
        {
            spritebatch.Draw(_tex, _pos + locality, _rotation, _centrePt, null, _size);
        }

        public override void Update()
        {
            Rotate(_aMomentum);
            if (Input.KeyPressed(Keys.C))
            {
                ChangeType();
            }
        }

        /// <summary>
        /// Changes the type of star randomly
        /// </summary>
        public void ChangeType()
        {
            CelesObjType newType = (CelesObjType)GM.instance.rnd.Next(0, 10);
            _type = newType;

            SwitchType(newType);
        }

        /// <summary>
        /// Changes type of star
        /// </summary>
        /// <param name="type">Type to change to</param>
        public void SwitchType(CelesObjType type)
        {
            switch (type)
            {
                case CelesObjType.OStar:
                    _tex = Resources.OStar;
                    break;
                case CelesObjType.BStar:
                    _tex = Resources.BStar;
                    break;
                case CelesObjType.AStar:
                    _tex = Resources.AStar;
                    break;
                case CelesObjType.FStar:
                    _tex = Resources.FStar;
                    break;
                case CelesObjType.GStar:
                    _tex = Resources.GStar;
                    break;
                case CelesObjType.KStar:
                    _tex = Resources.KStar;
                    break;
                case CelesObjType.MStar:
                    _tex = Resources.MStar;
                    break;
                case CelesObjType.BlackHole:
                    _tex = Resources.BlackHole;
                    break;
                case CelesObjType.WhiteDwarf:
                    _tex = Resources.WhiteDwarf;
                    break;
                case CelesObjType.Alien:
                    _tex = Resources.Alien;
                    break;
            }
        }

        /// <summary>
        /// Accelerates an another object towards this object
        /// </summary>
        /// <param name="obj">Object to be attracted</param>
        public void Attract(IGravitable obj)
        {
            Vector2 force = _gravConst * Vector2.Normalize((Pos - obj.Pos));
            obj.BeAttracted(force);
        }

        // Unused overload
        public override void Draw(SpriteBatch spritebatch) { }
    }

    /// <summary>
    /// The different types of celestial objects
    /// </summary>
    enum CelesObjType
    {
        OStar,
        BStar,
        AStar,
        FStar,
        GStar,
        KStar,
        MStar,
        BlackHole,
        WhiteDwarf,
        Alien
    }
}
