using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator
{
    /// <summary>
    /// Interface for calculating Ohm value of a resistor. Normally I would split this into
    /// its own Class Library
    /// </summary>
    public interface ICalculateOhmValues
    {
        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal muliplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }
}
