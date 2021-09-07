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
        public long D { get; set; }
        public long N { get; set; }
    }
    public class PublicKey
    {
        public long E { get; set; }
        public long N { get; set; }
    }
}