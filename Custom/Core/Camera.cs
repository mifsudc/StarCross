using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{  
    /// <summary>
    /// Viewport of the user. Draws all game objects relative to an object
    /// </summary>
    public class Camera
    {
        private Rectangle _bounds;
        private Vector2 _offset;
        private Vector2 _range;
        private GameObject _focus;

        public Camera(GameObject focus)
        {
            // bounds
            _offset = new Vector2(Constant.screenWidth / 2, Constant.screenHeight / 2);
            _range = new Vector2(800, 400);
            _focus = focus;

            Vector2 pos = _focus.Pos + _focus.CentrePoint;
            _bounds = new Rectangle( (pos - _range).ToPoint(), (pos + _range).ToPoint() );
        }

        /// <summary>
        /// Draws all game objects within the camera's bounds
        /// </summary>
        public void Render(List<GameObject> objs, SpriteBatch spritebatch)
        {
            spritebatch.Draw(Resources.background, new Vector2(
                (-1f / 15) * _focus.Pos.X,
                (-1f / 15) * _focus.Pos.Y - (100f / 3)
                ), Color.White
            );

            foreach (GameObject obj in objs)
            {
                //if (_bounds.Contains(obj.Pos + obj.CentrePoint))
                //{
                    obj.Draw(spritebatch, _offset - _focus.Pos);
                //}
            }
        }

        /// <summary>
        /// Sets camera position on focus
        /// </summary>
        public void SetToPlace()
        {
            _bounds.Location = (_focus.Pos + _focus.CentrePoint - _range).ToPoint();
            _bounds.Size = (_focus.Pos + _focus.CentrePoint + _range).ToPoint();
        }
    }
}
