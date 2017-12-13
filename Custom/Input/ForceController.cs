using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{   
    /// <summary>
    /// Provides a game actor with a set of force imperatives as a Force struct
    /// </summary>
    public abstract class ForceController
    {
        public abstract Force Update();
    }

    /// <summary>
    /// An array of booleans pertaining to force imperatives in each direction
    /// </summary>
    public struct Force
    {
        public bool Up, Down, Left, Right;

        public Force(bool def)
        {
            Up = Down = Left = Right = def;
        }
    }
}
