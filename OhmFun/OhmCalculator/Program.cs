using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace OhmCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            IServiceProvider provider;
            try
            {
                provider = Bootstrapper.GetServiceProvider(services);
            }
            catch (Exception ex)
            {
                WriteError($"Error getting service provider: {ex.Message}");
                Console.WriteLine("Press any key to end.");
                Console.ReadKey();
                return;
            }
            
            var calculator = provider.GetRequiredService<ICalculateOhmValues>();


            // Enumerate through the bands to display a pseudo menu
            // Since the requirements say to implement the ICalculateOhmValues, I left it explicitly the way it was in the requirements. I would have 
            // Either added the additional Bands read-only property to it or had it inherit from IColorBandCollection. To keep true to the requirements
            // I did it this way

            var bandCollection = calculator as IColorBandCollection;
            Console.WriteLine("Enter four valid resistor colors seperated by spaces representing Band1 Band2 Multiplier and Tolorance:");
            if (bandCollection != null)
            {
                Console.WriteLine("=================================================");
                Console.WriteLine("Availabile Colors");
                Console.WriteLine("=================================================");
                var colors = bandCollection.Bands.OrderByDescending(x => x.SignificantFigure).ThenBy(x => x.Color).Select(x => x.Color);
                foreach(var color in colors)
                {
                    // Could map somewhat to console color
                    
                    Console.WriteLine(color);
                }
                Console.WriteLine("=================================================");
            }

            Console.WriteLine("Enter four band colors here seperated by spaces: ");
            var line = Console.ReadLine();

            string[] input = line.Split(' ');
            if (input.Length != 4)
            {
                WriteError("Invalid input. You must enter 4 valid colors seperated by spaces");
                Console.WriteLine("Press any key to end.");
                Console.ReadKey();
                return;
            }

            try
            {
                int result;
                result = calculator.CalculateOhmValue(input[0], input[1], input[2], input[3]);
                Console.WriteLine($"The resistor value is {result} Ohms");
            }
            catch (Exception ex)
            {
                // Would log error to logger
                WriteError(ex.Message);
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }

        private static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR - {message}");
            Console.ResetColor();
        }
    }
}
