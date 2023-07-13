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
        
        // private char callPutFlag; // Determine if it is a call or put order.
        private enum OptionContractType
        {
            Call = 1,
            Put = 2
        }

        // Default constructor
        public BlackScholesModel()
        {
        }

        // Custom constructor initializing all member variables (Is this necessary??)
        public BlackScholesModel(double underlyingPrice, double strikePrice, double timeToExpiration,
            double riskFreeRate, double volatility, OptionContractType contractType)
        {
            this.UnderlyingPrice = underlyingPrice;
            this.StrikePrice = strikePrice;
            this.TimeToExpiration = timeToExpiration;
            this.Volatility = volatility;
            this.ContractType = contractType;
        }
        
        // Calculates theoretical option price.
        public double CalculateOptionPrice()
        {
            // Calculate the intermediate variables.
            double d1 = (Math.Log(underlyingPrice / strikePrice) +
                         (riskFreeRate + 0.5 * Math.Pow(volatility, 2)) * timeToExpiration) /
                        (volatility * Math.Sqrt(timeToExpiration));
            double d2 = d1 - volatility * Math.Sqrt(timeToExpiration);

            // double optionPrice = 0.0;

            // Calculate the option price using the Black-Scholes formula.
            switch (OptionContractType)
            {
                case OptionContractType.Call:
                    return underlyingPrice * NormalCDF(d1) -
                           strikePrice * Math.Exp(-riskFreeRate * timeToExpiration) * NormalCDF(d2);
                case OptionContractType.Put:
                    return strikePrice * Math.Exp(-riskFreeRate * timeToExpiration) * NormalCDF(-d2) -
                           underlyingPrice * NormalCDF(-d1);
                default:
                    Console.WriteLine("Error: Option type does not exist!");
                    return -1;
                    //throw new NotSupportedException("Error: Order type does not exist!");
            }
        
            // if (flag == "c") // If it is a call option. 
            // {
            //     optionPrice = underlyingPrice * NormalCDF(d1) -
            //                   strikePrice * Math.Exp(-riskFreeRate * timeToExpiration) * NormalCDF(d2);
            // }
            // else if (flag == "p") // Else, if it is a put option.
            // {
            // optionPrice = strikePrice * Math.Exp(-riskFreeRate * timeToExpiration) * NormalCDF(-d2) -
            //               underlyingPrice * NormalCDF(-d1);
            // }
            //
            // return optionPrice;
            
            
        } // CalculateOptionPrice()

        // Approximate the CDF of a normal distribution. 
        public double NormalCDF(double d)
        {
            // Abramowitz & Stegun's (1964) approximation. 
            
            /* Refer to https://www.ijser.org/researchpaper/Approximations-to-Standard-Normal-Distribution-Function.pdf
               for potentially more efficient approximations wrt M.A.E. and corresponding z-score */
            
            double result = 0.0;

            const double a[] =
            {
                0.2316419, 0.31938153, -0.356563782, 1.781477937, -1.821255978, 1.330274429
            };

            double L, K = 0.0;
            
            L = Math.Abs(d);
            K = 1.0 / (1.0 + a[0] * L);

            result = 1.0 - 1.0 / Math.Sqrt(2 * Convert.ToDouble(Math.PI.ToString())) * Math.Exp(-L * L / 2.0) *
                (a[1] * K + a[2] * a[3] * Math.Pow(K, 3.0) + a[4] * Math.Pow(K, 4.0) + a[5] * Math.Pow(K, 5.0));

            return d < 0 ? 1.0 - result : result; // Should ternary operator be used here? Or if-else statement (below)?
            
            /* if (d < 0) 
            {
            return 1.0 - result;
            }
            else 
            { 
                return result;
            } */
            
        } // NormalCDF()

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
        
    } // BlackScholesModel 
} 
