using System;

namespace BlackScholes
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Instantiate and use the BlackScholes Model
            BlackScholesModel model = new BlackScholesModel();
            
            
            // Call the option pricing function
            double optionPrice = model.CalculateOptionPrice();

            // Output the result
            Console.WriteLine("Option Price: " + optionPrice);
        }
    }
}
