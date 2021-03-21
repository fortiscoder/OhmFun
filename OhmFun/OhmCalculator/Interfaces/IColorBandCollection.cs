using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OhmCalculator.Models;
namespace OhmCalculator
{
    public interface IColorBandCollection
    {
        /// <summary>
        /// Returns available band options
        /// </summary>
        public IEnumerable<ColorBand> Bands {get;}
    }
}
