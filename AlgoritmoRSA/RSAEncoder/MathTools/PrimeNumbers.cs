using RSAEncoder.Utils.CustomExceptions;
using System;

namespace RSAEncoder.MathTools
{
    public static class PrimeNumbers
    {
        const int maxPrimeLength = 100000;
        public static bool VerifyPrimeNumber(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i <= number/2; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        public static int CreateRandomPrimeNumber(int minGeneratorLength = 0, int maxGeneratorLength = maxPrimeLength)
        {
            if (maxGeneratorLength <= minGeneratorLength)
                throw new PrimeNumberException("O valor de geração máximo deve ser maior que o valor de geração mínimo. ");
            Random randomGenerator = new Random();
            int randNumber;
            while (true)
            {
                randNumber = randomGenerator.Next(minGeneratorLength, maxGeneratorLength);
                if (VerifyPrimeNumber(randNumber))
                    return randNumber;
            }
        } 
    }
}
