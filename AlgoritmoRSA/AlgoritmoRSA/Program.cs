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

                RSAEncoder.CryptographyTools.Encoder encoder = new RSAEncoder.CryptographyTools.Encoder();
                var test = encoder.Encrypt(message);

                Console.WriteLine("Quem entender é guei:");

                foreach (var item in test)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("decript:");

                foreach (var item in test)
                {
                    Console.Write(encoder.Decrypt(item));
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
