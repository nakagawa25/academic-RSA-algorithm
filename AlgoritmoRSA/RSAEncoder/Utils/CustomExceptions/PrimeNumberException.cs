using System;

namespace RSAEncoder.Utils.CustomExceptions
{
    public class PrimeNumberException: Exception
    {
        public PrimeNumberException(string message) : base(message) { }
    }
}
