using System;

namespace RSAEncoder.CryptographyTools
{
    public class RSAAlgorithm
    {
        private static Models.RSANumbers rsaNumbers;
        public RSAAlgorithm()
        {
            rsaNumbers = new Models.RSANumbers();
        }

        public Models.RSANumbers GetRSANumbers(long? p = null, long? q = null)
        {
            CalculateRSANumbers(p, q);
            return rsaNumbers;
        }

        private void CalculateRSANumbers(long? p = null, long? q = null)
        {
            InstancePQNumbers(p, q);
            rsaNumbers.N = rsaNumbers.P * rsaNumbers.Q;
            rsaNumbers.M = (rsaNumbers.P - 1) * (rsaNumbers.Q - 1);
            rsaNumbers.E = GetEulerNumber();
            rsaNumbers.D = GetDNumber();
        }

        private void InstancePQNumbers(long? p = null, long? q = null)
        {

            rsaNumbers.P = (p == null) ? MathTools.PrimeNumbers.CreateRandomPrimeNumber() : (long)p;
            if (q == null)
            {
                long aux;
                do
                {
                    aux = MathTools.PrimeNumbers.CreateRandomPrimeNumber();
                } while (aux == rsaNumbers.P);
                rsaNumbers.Q = aux;
            }
            else
                rsaNumbers.Q = (long)q;
        }

        private long GetEulerNumber()
        {
            Random generator = new Random();
            long eAux;
            do
            {
                eAux = MathTools.CalculationTools.LongRandom(2, rsaNumbers.M, generator);
            } while (MathTools.CalculationTools.GetGreatestCommonDivider(eAux, rsaNumbers.M) != 1);

            return eAux;
        }

        private long GetDNumber()
        {
            return MathTools.CalculationTools.ModInverse(rsaNumbers.E, rsaNumbers.M);

            #region Old_Method
            //var i = 1;
            //while (true)
            //{
            //    if ((rsaNumbers.E * i) % rsaNumbers.M == 1)
            //        return i;
            //    i++;
            //}
            #endregion
        }
    }
}
