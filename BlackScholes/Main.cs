using System;

namespace BlackScholes
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Instantiate and use the BlackScholes Model
            BlackScholesModel model = new BlackScholesModel();
            
            // Set the necessary member variables using setting methods
            /* e.g.
                model.SetUnderlyingPrice(10.0);
                model.SetStrikeprice(9.0);
                model.SetTimeToExpiration(1.5);
                model.SetRiskFreeRate(0.7);
                model.SetVolatility(0.9); 
             */

            // Call the option pricing function
            double optionPrice = model.CalculateOptionPrice();

            // Output the result
            Console.WriteLine("Option Price: " + optionPrice);
        }
    }
}