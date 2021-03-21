using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OhmCalculator.Models;
namespace OhmCalculator
{
    /// <summary>
    /// Implementation for calculating a resistor's ohm value
    /// </summary>
    public class CalculateOhmValuesImpl : ICalculateOhmValues, IColorBandCollection
    {
        #region Instance variables
        /// <summary>
        /// For storing the band information. This could be an array since the number of elements is finite. Arguably better performance
        /// However my intention is to use Enmerable LINQ methods which probably offets performance gains
        /// </summary>
        private readonly IEnumerable<ColorBand> _bands;
        #endregion
        #region Constructors
        /// <summary>
        /// Create CalculateOhmValuesImpl. This is where I would add dependencies 
        /// such as ILogger for this class
        /// </summary>
        public CalculateOhmValuesImpl()
        {
            List<ColorBand> bands = new List<ColorBand>();
            bands.Add(new ColorBand("pink", null, .001));
            bands.Add(new ColorBand("silver", null, .01));
            bands.Add(new ColorBand("gold", null, .1));
            bands.Add(new ColorBand("black", 0, Math.Pow(10, 0)));
            bands.Add(new ColorBand("brown", 1, Math.Pow(10, 1)));
            bands.Add(new ColorBand("red", 2, Math.Pow(10, 2)));
            bands.Add(new ColorBand("orange", 3, Math.Pow(10, 3)));
            bands.Add(new ColorBand("yellow", 4, Math.Pow(10, 4)));
            bands.Add(new ColorBand("green", 5, Math.Pow(10, 5)));
            bands.Add(new ColorBand("blue", 6, Math.Pow(10, 6)));
            bands.Add(new ColorBand("violet", 7, Math.Pow(10, 7)));
            bands.Add(new ColorBand("gray", 8, Math.Pow(10, 8)));
            bands.Add(new ColorBand("white", 9, Math.Pow(10, 9)));
            _bands = bands;
        }
        #endregion
        #region ICalculateOhmValues methods
        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal muliplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <returns>Ohm value</returns>
        /// <exception cref="ArgumentNullException">Thrown if one of the values is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is missing or invalid for the digit</exception>
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            int result;

            // Validate input.
            try
            {
                ValidateOhmInput(bandAColor, bandBColor, bandCColor, bandDColor);
            }
            catch (Exception ex)
            {
                // I would log this to the injected logger. For simplicity I will log to the Diagnostic
                System.Diagnostics.Debug.WriteLine($"An exception {ex.GetType().Name} was thrown: {ex.Message}");

                throw; // bubble up the exception
            }
            


            // Now that the data is valid we can proceed with calculating the ohm value
            int digit1, digit2;
            double multiplier = _bands.Where(x => x.Color == bandCColor.ToLower()).FirstOrDefault().Multiplier;
            digit1 = _bands.Where(x => x.Color == bandAColor.ToLower()).FirstOrDefault().SignificantFigure.Value * 10;
            digit2 = _bands.Where(x => x.Color == bandBColor.ToLower()).FirstOrDefault().SignificantFigure.Value;

            result = (int)((digit1 + digit2) * multiplier);

            // Tolorance is irrelevent for this implementation

            return result;
        }
        #endregion
        #region Private methods
        /// <summary>
        /// Validates the input for CalculateOhmValue. Exception is thrown if the input is invalid
        /// /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal muliplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <exception cref="ArgumentNullException">Thrown if one of the values is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is missing or invalid for the digit</exception>
        private void ValidateOhmInput(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            // Validation. I could put this in its own method especially if it was expected to be used
            if (bandAColor == null)
            {
                throw new ArgumentNullException(nameof(bandAColor));
            }
            if (bandBColor == null)
            {
                throw new ArgumentNullException(nameof(bandBColor));
            }
            if (bandCColor == null)
            {
                throw new ArgumentNullException(nameof(bandCColor));
            }
            if (bandDColor == null)
            {
                throw new ArgumentNullException(nameof(bandDColor));
            }

            // Validate the colors exist

            if (!_bands.Any(x => x.Color == bandAColor.ToLower()))
            {
                throw new ArgumentOutOfRangeException(nameof(bandAColor), $"{ bandAColor} is not a valid color");
            }

            if (!_bands.Any(x => x.Color == bandBColor.ToLower()))
            {
                throw new ArgumentOutOfRangeException(nameof(bandBColor), $"{bandBColor} is not a valid color");
            }
            if (!_bands.Any(x => x.Color == bandCColor.ToLower()))
            {
                throw new ArgumentOutOfRangeException(nameof(bandCColor), $"{ bandCColor} is not a valid color");
            }
            if (!_bands.Any(x => x.Color == bandDColor.ToLower()))
            {
                throw new ArgumentOutOfRangeException(nameof(bandDColor), $"{ bandDColor} is not a valid color");
            }

            // Validate that the first digits are valid digits for calculating ohm value
            if (_bands.Where(x => x.Color == bandAColor.ToLower()).FirstOrDefault()?.SignificantFigure == null)
            {
                throw new ArgumentOutOfRangeException(nameof(bandAColor), $"{ bandAColor} is not valid for calcluating ohm value as it does not have a significant figure");
            }

            if (_bands.Where(x => x.Color == bandBColor.ToLower()).FirstOrDefault()?.SignificantFigure == null)
            {
                throw new ArgumentOutOfRangeException(nameof(bandBColor), $"{ bandBColor} is not valid for calcluating ohm value as it does not have a significant figure");
            }

        }
        #endregion
        #region Properties
        /// <summary>
        /// Available color bands
        /// </summary>
        public IEnumerable<ColorBand> Bands
        {
            get
            {
                return _bands;
            }
        }
        #endregion
    }
}
