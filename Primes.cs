using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsStand
{
    /// <summary>
    /// Provides methods to generate primes
    /// </summary>
    class Primes
    {
        /// <summary>
        /// Generate prime numbers up to the specified limit using trial division
        /// </summary>
        /// <param name="limit"> Limit to which primes will be generated</param>
        /// <returns>A List of primes</returns>
        public List<int> TrialDivision(int limit)
        {
            List<int> primes = new List<int>();
            bool isPrime;

            primes.Add(2);
            primes.Add(3);

            if (limit == 2 || limit == 3)
                return primes;

            for (int possiblePrime = 5; possiblePrime < limit; possiblePrime += 2)
            {
                isPrime = true;

                for (int divisor = 3; divisor <= Math.Sqrt(possiblePrime) && isPrime; divisor += 2)
                {
                    if (possiblePrime % divisor == 0)
                        isPrime = false;
                }

                if (isPrime)
                {
                    primes.Add(possiblePrime);
                }
            }

            return primes;
        }

        /// <summary>
        /// Generate prime numbers up to the specified limit using the Sieve of Eratosthenes
        /// </summary>
        /// <param name="limit"> Limit to which primes will be generated</param>
        /// <returns>A List of primes</returns>
        public List<int> SieveOfEratosthenes(int limit)
        {
            bool[] numbers = new bool[limit + 1];
            List<int> primes = new List<int>();

            for (int i = 2; i <= limit; i++)
                numbers[i] = true;

            for (int i = 2; i <= Math.Sqrt(limit); i++)
            {
                //Check if i is a prime
                if (numbers[i])
                {
                    //Remove multiples of i
                    for(int j = (i * i); j <= limit; j+= i)
                        numbers[j] = false;
                }
            }

            for (int i = 2; i <= limit; i++)
            {
                if(numbers[i])
                    primes.Add(i);
            }

            return primes;
        }

        /// <summary>
        /// Generate prime numbers up to the specified limit using the Sieve of Atkins
        /// </summary>
        /// <param name="limit"> Limit to which primes will be generated</param>
        /// <returns>A List of primes</returns>
        public List<int> SieveOfAtkin(int limit)
        {
            bool[] isPrime = new bool[limit + 1];
            List<int> primes = new List<int>();

            isPrime[2] = true;
            isPrime[3] = true;

            for (int i = 5; i <= limit; i++)
                isPrime[i] = false;

            double lim = Math.Ceiling(Math.Sqrt(limit));
            for (int x = 1; x <= lim; x++)
            {
                for (int y = 1; y <= lim; y++)
                {
                    int num = (4 * x * x + y * y);

                    if (num < limit && (num % 12 == 1 || num % 12 == 5))
                        isPrime[num] = true;

                    num = (3 * x * x + y * y);

                    if (num < limit && (num % 12 == 7))
                        isPrime[num] = true;

                    if (x > y)
                    {
                        num = (3 * x * x - y * y);
                        if (num < limit && (num % 12 == 11))
                            isPrime[num] = true;
                    }
                }
            }

            for(int i = 5; i <= lim; i++)
            {
                if(isPrime[i])
                {
                    for(int j = (i * i); j <= limit; j+= i)
                        isPrime[j] = false;
                }
            }

            for (int i = 2; i < limit; i++)
            {
                if(isPrime[i])
                    primes.Add(i);
            }

            return primes;
        }

        /// <summary>
        /// Generate mersene prime numbers up to the specified limit
        /// Mersene primes are in the form 2^n - 1
        /// </summary>
        /// <param name="limit"> Limit to which mersene primes will be generated</param>
        /// <returns>A List of primes</returns>
        public List<int> MersennePrimes(int limit)
        {
            List<int> primes = TrialDivision(limit);
            List<int> mersenePrimes = new List<int>();

            //Two is not a mersene prime, so I am going to ignore it (maybe its better that way for the power of two checker)
            for (int i = 1; i < primes.Count; i++ )                 
            {
                //If prime is in the form 2^n - 1, adding one will give you 2^n, to be checked if it is a power of 2
                if (IsPowerOfTwo(primes[i] + 1))                    
                {
                    mersenePrimes.Add(primes[i]);
                }
            }

            return mersenePrimes;
        }

        /// <summary>
        /// Checks if a number is a power of 2
        /// <param name="myInt">number to be checked</param>
        /// <returns>REturns true if parameter is a power of 2, otherwise, false</returns>
        private bool IsPowerOfTwo(int myInt)
        {
            //If the parameter is a power of 2 and you divide by 2 repeatedly and you'll eventually get to 1
            //Otherwise you end up with an odd number greater than 1
            while (true)
            {
                myInt /= 2;

                if (myInt % 2 != 0  && myInt != 1)               
                    return false; 
                                 
                else if(myInt == 1)
                    return true;

            }
        }


    }


}