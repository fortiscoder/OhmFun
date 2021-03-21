using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OhmCalculator;

using Xunit;

namespace OhmCalculatorTests
{
    
    public class CalculateOhmValueTest
    {
        [Fact]
        public void ResitorValueTest()
        {
            // Arrange
            // This is where I would mock any dependencies like ILogger<>, HttpClient, or any others...
            var calculator = new CalculateOhmValuesImpl();


            // Act
            int result = calculator.CalculateOhmValue("blue", "gray", "red", "gold");


            // Assert
            Assert.Equal(6800, result);
        }

        [Fact]
        public void ResitorValue10kTest()
        {
            // Arrange
            // This is where I would mock any dependencies like ILogger<>, HttpClient, or any others...
            var calculator = new CalculateOhmValuesImpl();


            // Act
            int result = calculator.CalculateOhmValue("brown", "black", "orange", "gold");


            // Assert
            Assert.Equal(10000, result);
        }
        [Fact]
        public void BandTest()
        {
            // Arrange
            // This is where I would mock any dependencies like ILogger<> or any others...
            var calculator = new CalculateOhmValuesImpl();


            // Act
            int result = calculator.CalculateOhmValue("blue", "gray", "red", "gold");

            Assert.NotNull(calculator.Bands);
            Assert.True(calculator.Bands.Count() > 0);
        }
        [Fact]
        public void InvalidBandAColorTest()
        {
            // Arrange
            // This is where I would mock any dependencies like ILogger<> or any others...
            var calculator = new CalculateOhmValuesImpl();


            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateOhmValue("purple", "orange", "red", "brown"));
            

        }
        [Fact]
        public void InvalidBandBColorTest()
        {
            // Arrange
            // This is where I would mock any dependencies like ILogger<> or any others...
            var calculator = new CalculateOhmValuesImpl();


            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateOhmValue("orange", "purple", "red", "brown"));
        }
        [Fact]
        public void InvalidBandCColorTest()
        {
            // Arrange
            // This is where I would mock any dependencies like ILogger<> or any others...
            var calculator = new CalculateOhmValuesImpl();


            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateOhmValue("red", "orange", "purple", "brown"));


        }
        [Fact]
        public void InvalidBandDColorTest()
        {
            // Arrange
            // This is where I would mock any dependencies like ILogger<> or any others...
            var calculator = new CalculateOhmValuesImpl();


            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateOhmValue("brown", "orange", "red", "purple"));


        }
        [Fact]
        public void NullBandATest()
        {
            // Arrange
            // This is where I would mock any dependencies like ILogger<> or any others...
            var calculator = new CalculateOhmValuesImpl();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => calculator.CalculateOhmValue(null, "orange", "red", "brown"));
        }
        [Fact]
        public void NullBandBTest()
        {
            // Arrange
            // This is where I would mock any dependencies like ILogger<> or any others...
            var calculator = new CalculateOhmValuesImpl();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => calculator.CalculateOhmValue("orange", null, "red", "brown"));
        }
        [Fact]
        public void NullBandCTest()
        {
            // Arrange
            // This is where I would mock any dependencies like ILogger<> or any others...
            var calculator = new CalculateOhmValuesImpl();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => calculator.CalculateOhmValue("red", "orange",null, "brown"));
        }
        [Fact]
        public void NullBandDTest()
        {
            // Arrange
            // This is where I would mock any dependencies like ILogger<> or any others...
            var calculator = new CalculateOhmValuesImpl();


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => calculator.CalculateOhmValue("blue", "orange", "red", null));
        }
    }
}
