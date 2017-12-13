using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    /// <summary>
    /// Provides force imperatives dependant upon player keyboard interactions
    /// </summary>
    public class PlayerController : ForceController
    {
        public override Force Update()
        {
            Force result = new Force(false);
            // Provide force imperative upon input
            if (Input.KeyDown(Keys.Up))
            {
                result.Up = true;
            }
            if (Input.KeyDown(Keys.Down))
            {
                result.Down = true;
            }
            if (Input.KeyDown(Keys.Left))
            {
                result.Left = true;
            }
            if (Input.KeyDown(Keys.Right))
            {
                result.Right = true;
            }
            return result;
        }
    }
}
