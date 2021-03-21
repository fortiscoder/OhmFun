using System;

namespace SubItemFun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an item number to search for:");
            string itemNumber = Console.ReadLine();

            var helper = new ItemHelper();
            try
            {
                var summary = helper.GetSubItemSummary(itemNumber);
                if (summary.Length == 0)
                {
                    Console.WriteLine("Item not found.");
                }
                else
                {
                    foreach (var item in summary)
                    {
                        Console.WriteLine($"{item.Name}: {item.Count}");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
            
            Console.WriteLine("Press any key to end");
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
