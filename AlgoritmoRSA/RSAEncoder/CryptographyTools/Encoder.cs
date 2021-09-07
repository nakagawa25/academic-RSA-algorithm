using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace RSAEncoder.CryptographyTools
{
    public class Encoder
    {
        private Models.RSAKeys keys;
        public Encoder(int? p = null, int? q = null)
        {
            KeyGenerator keyGenerator = new KeyGenerator();
            keys = keyGenerator.CreateKeys(p, q);
        }

        public Encoder(string pathToSaveKeys, bool createNewKeys, int? p = null, int? q = null)
        {
            KeyGenerator keyGenerator = new KeyGenerator();
            keys = createNewKeys ? keyGenerator.CreateKeys(pathToSaveKeys, p, q) : keyGenerator.GetKeysFromFile(Path.Combine(pathToSaveKeys, "Keys"));
        }

        public string Encrypt(string message)
        {
            var encryptedMessage = new List<long>();
            foreach (var character in message)
                encryptedMessage.Add((long)BigInteger.ModPow((int)character, keys.Public.E, keys.Public.N));

            return System.Convert.ToBase64String(Utils.Tools.GetByteArray(encryptedMessage)); ;
        }

        public string Decrypt(string message)
        {
            List<long> cryptoCharacter = Utils.Tools.GetLongListFromByteArray(System.Convert.FromBase64String(message));
            string plainText = string.Empty;
            foreach (var characterEncrypted in cryptoCharacter)
                plainText += (char)BigInteger.ModPow(characterEncrypted, keys.Private.D, keys.Private.N);

            return plainText;
        }
    }
}
