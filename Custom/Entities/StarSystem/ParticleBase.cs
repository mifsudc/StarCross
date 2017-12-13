using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Custom
{
    /// <summary>
    /// Particle common base
    /// </summary>
    public class ParticleBase
    {
        public Color Colour;
        public float Size;
        public Texture2D Tex;
        public Vector2 CentrePt;

        public ParticleBase(Texture2D tex, Color color, float size)
        {
            Tex = tex;
            Colour = color;
            Size = size;
            CentrePt = new Vector2(tex.Width / 2, tex.Height / 2);
        }
    }
}
