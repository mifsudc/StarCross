using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    /// <summary>
    /// Star system build controller
    /// </summary>
    class SystemBuilder
    {
        private int _sysNum;        // Number of systems created by this builder

        public SystemBuilder()
        {
            _sysNum = 0;
        }

        /// <summary>
        /// Builds a randomly generated starsystem
        /// </summary>
        /// <returns>The resultant system</returns>
        public SystemState BuildSystem()
        {
            CelesObjType type;
            // Create one of each type for first 10 systems
            if (_sysNum < 10)
            {
                type = (CelesObjType)_sysNum;
            }
            // Otherwise randomly generate type
            else
            {
                type = (CelesObjType)GM.instance.rnd.Next(10); // Create random star type
            }
            ProtoSystem build = new ProtoSystem();
            if (type == CelesObjType.BlackHole || type == CelesObjType.WhiteDwarf)
            {
                build.AddStar(type).AddAliens().AddDisc();
            }
            else if (type == CelesObjType.Alien)
            {
                // Lotsa aliens brah
                build.AddStar(type).AddAliens().AddAliens().AddAliens().AddAliens()
                    .AddAliens().AddAliens().AddAliens().AddAliens();
            }
            else
            {
                build.AddStar(type).AddAsteroids().AddAliens().AddPlanets();
            }

            _sysNum++;
            return build.Build();
        }
    }
}
