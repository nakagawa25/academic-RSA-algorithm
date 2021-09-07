using System;

namespace RSAEncoder.MathTools
{
    public static class CalculationTools
    {
        public static long GetGreatestCommonDivider(long number_1, long number_2)
        {
            long remainder;
            do
            {
                remainder = number_1 % number_2;
                number_1 = number_2;
                number_2 = remainder;
            } while (remainder != 0);

            return number_1;
        }

        public static long ModInverse(long a, long n)
        {
            long i = n, v = 0, d = 1;
            while (a > 0)
            {
                long t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;

            return v;
        }

        public static long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }
    }
}
