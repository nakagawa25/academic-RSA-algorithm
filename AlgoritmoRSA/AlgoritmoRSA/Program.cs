using System;

namespace AlgoritmoRSA
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Message: ");
                var message = Console.ReadLine();

                //if (RSAEncoder.MathTools.PrimeNumbers.VerifyPrimeNumber(Convert.ToInt32(message)))
                //    Console.WriteLine("é primo");
                //else
                //    Console.WriteLine("não é primo");

                RSAEncoder.CryptographyTools.Encoder encoder = new RSAEncoder.CryptographyTools.Encoder(3, 11);
                var test = encoder.Encrypt(message);

                foreach (var item in test)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("decript:");
                var a = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(encoder.Decrypt(a));

                Console.ReadLine();
            }
        }
    }
}
