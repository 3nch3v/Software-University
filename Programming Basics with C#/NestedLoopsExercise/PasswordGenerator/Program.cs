using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= n; firstDigit++)
            {
                for (int secondDigit = 1; secondDigit <= n; secondDigit++)
                {
                    for (int thirdDigit = 'a'; thirdDigit < 'a' + L; thirdDigit++)
                    {
                        for (int fourthDigit = 'a'; fourthDigit < 'a' + L; fourthDigit++)
                        {
                            int max = Math.Max(firstDigit, secondDigit);

                            for (int fifthDigit = max + 1; fifthDigit <= n; fifthDigit++)
                            {
                                Console.Write($"{firstDigit}{secondDigit}{(char)thirdDigit}{(char)fourthDigit}{fifthDigit} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
