using RSAEncoder.Utils.CustomExceptions;
using System;

namespace RSAEncoder.MathTools
{
    public static class PrimeNumbers
    {
        const long maxPrimeLength = 100000000;

        public static bool VerifyPrimeNumber(long number)
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

        public static long CreateRandomPrimeNumber(long minGeneratorLength = 0, long maxGeneratorLength = maxPrimeLength)
        {
            if (maxGeneratorLength <= minGeneratorLength)
                throw new PrimeNumberException("O valor de geração máximo deve ser maior que o valor de geração mínimo. ");
            Random randomGenerator = new Random();

            long randNumber;
            while (true)
            {
                randNumber = CalculationTools.LongRandom(minGeneratorLength, maxGeneratorLength, randomGenerator);
                if (VerifyPrimeNumber(randNumber))
                    return randNumber;
            }
        } 
    }
}
