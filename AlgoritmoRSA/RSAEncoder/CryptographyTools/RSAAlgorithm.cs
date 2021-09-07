namespace RSAEncoder.CryptographyTools
{
    public class RSAAlgorithm
    {
        private static Models.RSANumbers rsaNumbers;
        public RSAAlgorithm()
        {
            rsaNumbers = new Models.RSANumbers();
        }

        public Models.RSANumbers GetRSANumbers(int? p = null, int? q = null)
        {
            CalculateRSANumbers(p, q);
            return rsaNumbers;
        }

        private void CalculateRSANumbers(int? p = null, int? q = null)
        {
            InstancePQNumbers(p, q);
            rsaNumbers.N = rsaNumbers.P * rsaNumbers.Q;
            rsaNumbers.M = (rsaNumbers.P - 1) * (rsaNumbers.Q - 1);
            rsaNumbers.E = MathTools.PrimeNumbers.CreateRandomPrimeNumber(2, rsaNumbers.M);
            rsaNumbers.D = GetDNumber();
            //rsaNumbers.D = (int)System.Numerics.BigInteger.ModPow(rsaNumbers.E, rsaNumbers.M -2, rsaNumbers.M); //GetDNumber(); //// a_inverse = BigInteger.ModPow(a, n - 2, n)
        }

        private void InstancePQNumbers(int? p = null, int? q = null)
        {

            rsaNumbers.P = (p == null) ? MathTools.PrimeNumbers.CreateRandomPrimeNumber() : (int)p;
            if (q == null)
            {
                int aux;
                do
                {
                    aux = MathTools.PrimeNumbers.CreateRandomPrimeNumber();
                } while (aux == rsaNumbers.P);
                rsaNumbers.Q = aux;
            }
            else
                rsaNumbers.Q = (int)q;
        }

        private int GetDNumber()
        {
            var i = 1;
            while (true)
            {
                if ((rsaNumbers.E * i) % rsaNumbers.M == 1)
                    return i;
                i++;
            }
        }
    }
}
