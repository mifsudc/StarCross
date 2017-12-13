using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Custom
{
    /// <summary>
    /// Contains all of the art and sound assets for the game
    /// </summary>
    static class Resources
    {
        // Small object sprites
        public static Texture2D actor;          // ref: Smileymensch - OpenGameArt
        public static Texture2D bullet;
        public static Texture2D particle;
        public static Texture2D background;     // ref: Peeter - PixelJoint
        public static Texture2D galaxy;
        public static Texture2D marker;
        public static Texture2D planet;         // ref: Earth - @pixel.emoji
        public static Texture2D npc;            // ref: tastyGraphGames - pic.codeus.net

        // Celestial object sprites
        public static Texture2D OStar;
        public static Texture2D BStar;
        public static Texture2D AStar;          // ref: InvaderXan - Deviantart
        public static Texture2D FStar;
        public static Texture2D GStar;
        public static Texture2D KStar;
        public static Texture2D MStar;
        public static Texture2D BlackHole;
        public static Texture2D WhiteDwarf;
        public static Texture2D Alien;          // ref: Starcraft 2 Protoss Mothership - Blizzard Entertainment

        // Other assets
        public static SpriteFont testFont;
        public static Song Music;               // ref: Round and round - Aidan Maizels: for this project
    }
}
