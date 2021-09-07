namespace RSAEncoder.CryptographyTools
{
    public class KeyGenerator
    {
        private Models.RSAKeys Keys { get; set; }

        public KeyGenerator()
        {
            Keys = new Models.RSAKeys();
        }

        public Models.RSAKeys CreateKeys(int? p = null, int? q = null)
        {
            RSAAlgorithm rsaCreator = new RSAAlgorithm();
            Models.RSANumbers rsaNumbers = rsaCreator.GetRSANumbers(p, q);
            Keys.Public.E = rsaNumbers.E;
            Keys.Public.N = rsaNumbers.N;
            Keys.Private.D = rsaNumbers.D;
            Keys.Private.N = rsaNumbers.N;

            return Keys;
        }

        public Models.RSAKeys CreateKeys(string pathToSaveKeys, int? p = null, int? q = null)
        {
            CreateKeys(p, q);
            SaveKeys(pathToSaveKeys);

            return Keys;
        }

        public Models.RSAKeys GetKeysFromFile(string path)
        {
            return Utils.IOKeys.GetKeys(path);
        }

        private void SaveKeys(string path)
        {
            Utils.IOKeys.SaveKeys(path, Keys);
        }
    }
}
