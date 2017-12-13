using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    /// <summary>
    /// Interface for game objects that decay out of existence
    /// </summary>
    public interface IDecay
    {
        /// <summary>
        /// Remaining time to live
        /// </summary>
        int TTL { get; }
    }
}
