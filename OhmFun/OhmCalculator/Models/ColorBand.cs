using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator.Models
{
    public class ColorBand
    {
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public ColorBand()
        {

        }
        /// <summary>
        /// Initialize ColorBand class
        /// </summary>
        /// <param name="color">Color name of band</param>
        /// <param name="significantFigure">Color numeric value, doubles for multiplier</param>
        public ColorBand(string color, int? significantFigure, double multiplier)
        {
            Color = color;
            SignificantFigure = significantFigure;
            Multiplier = multiplier;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Color name of band
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Color numeric value
        /// </summary>
        public int? SignificantFigure { get; set; }
        /// <summary>
        /// Decimal multiplier if it is the 4th band
        /// </summary>
        public double Multiplier { get; set; }
        #endregion
    }
}
