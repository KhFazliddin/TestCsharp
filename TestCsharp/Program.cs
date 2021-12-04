using System;


namespace TestCsharp
{
    class Program
    {

        private static bool isPrime(int num)
        {
            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        // Generate all prime numbers less than n.
        static void SieveOfEratosthenes(int n,
                                    bool[] prime)
        {

            // Initialize all entries of
            // boolean array as true. A
            // value in prime[i] will finally
            // be false if i is Not a prime,
            // else true bool prime[n+1];
            for (int i = 0; i <= n; i++)
                prime[i] = true;

            for (int p = 2; p * p <= n; p++)
            {

                // If prime[p] is not changed,
                // then it is a prime
                if (prime[p] == true)
                {

                    // Update all multiples of p
                    for (int i = p * 2; i <= n; i += p)
                        prime[i] = false;
                }
            }
        }







        // Function to generate mersenne
        // primes lessthan or equal to n
        static void mersennePrimes(int n)
        {

            // Create a boolean array
            // "prime[0..n]"
            bool[] prime = new bool[n + 1];

            // Generating primes
            // using Sieve
            SieveOfEratosthenes(n, prime);

            // Generate all numbers of
            // the form 2^k - 1 and
            // smaller than or equal to n.
            for (int k = 2; ((1 << k) - 1) <= n; k++)
            {
                long num = (1 << k) - 1;

                // Checking whether number is
                // prime and is one less then
                // the power of 2
                if (prime[(int)(num)])
                    Console.Write(num + " ");
            }
        }






        static void RollDice(int numTries)
        {
            Random random = new Random();

            //Console.Write("Please enter the number of dice you want to roll: ");
            //int numTries = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            int dieRoll;

            for (int i = 1; i <= numTries; i++)
            {
                dieRoll = random.Next(6) + 1;
                Console.WriteLine(dieRoll);
                sum += dieRoll;
            }
            Console.WriteLine("The sum of your rolls equals: " + sum);
        }








        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("Enter the number to check : ");
            num = int.Parse(Console.ReadLine());

            if (isPrime(num))
            {
                Console.WriteLine("{0} is a prime number", num);
            }
            else
            {
                Console.WriteLine("{0} is not a prime number", num);
            }


            int n = 31;

            Console.WriteLine("Mersenne prime numbers"
                   + " smaller than or equal to " + n);

            mersennePrimes(n);




           


            while (true)
            {
                Console.Write("Please enter the number of dices you want to roll: ");
                string input = Console.ReadLine();
                if (input == "quit" || input == "exit") //check it immediately here 
                    break;

                int numTries = 0;
                if (!int.TryParse(input, out numTries)) //handle not valid number
                {
                    Console.WriteLine("Not a valid number");
                    continue;
                }


                RollDice(numTries);
                Console.ReadKey();

            }

        }
    }
}
