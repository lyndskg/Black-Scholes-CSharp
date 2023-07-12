using System;

namespace BlackScholes
{
    public class BlackScholesModel
    {
        // Member variables
        private double underlyingPrice;
        private double strikePrice;
        private double timeToExpiration;
        private double riskFreeRate;
        private double volatility;


        // Constructor
        public BlackScholesModel()
        {
            // Default constructor
            // Initialize member variables if needed
        }

        // Option pricing function
        public double CalculateOptionPrice()
        {
            // Calculate the intermediate variables.
            double d1 = (Math.Log(underlyingPrice / strikePrice) +
                         (riskFreeRate + 0.5 * Math.Pow(volatility, 2)) * timeToExpiration) /
                        (volatility * Math.Sqrt(timeToExpiration));
            double d2 = d1 - volatility * Math.Sqrt(timeToExpiration);

            // Calculate the option price using the Black-Scholes formula.
            double optionPrice = underlyingPrice * NormalCDF(d1) -
                                 strikePrice * Math.Exp(-riskFreeRate * timeToExpiration) * NormalCDF(d2);

            return optionPrice;
        }

        // Setter methods
        public void SetUnderlyingPrice(double price)
        {
            underlyingPrice = price; // Current stock price 
        }

        public void SetStrikePrice(double price)
        {
            strikePrice = price; // Strike price
        }

        public void SetTimeToExpiration(double time)
        {
            timeToExpiration = time; // Time until expiration
        }

        public void SetRiskFreeRate(double rate)
        {
            riskFreeRate = rate; // Risk-free interest rate
        }

        public void SetVolatility(double vol)
        {
            volatility = vol; // Volatility
        }
    }
} 