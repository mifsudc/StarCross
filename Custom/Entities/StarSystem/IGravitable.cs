using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    /// <summary>
    /// Interface for game objects that can be attracted by gravity
    /// </summary>
    public interface IGravitable
    {
        void BeAttracted(Vector2 force);
        Vector2 Pos { get; }
    }
}
