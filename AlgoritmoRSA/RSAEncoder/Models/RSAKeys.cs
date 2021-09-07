namespace RSAEncoder.Models
{
    public class RSAKeys
    {
        public RSAKeys()
        {
            Private = new PrivateKey();
            Public = new PublicKey();
        }

        public PrivateKey Private { get; set; }
        public PublicKey Public { get; set; }
    }

    public class PrivateKey
    {
        public int D { get; set; }
        public int N { get; set; }
    }
    public class PublicKey
    {
        public int E { get; set; }
        public int N { get; set; }
    }
}