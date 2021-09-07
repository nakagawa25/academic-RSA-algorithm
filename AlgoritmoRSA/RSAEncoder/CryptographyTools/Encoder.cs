using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSAEncoder.CryptographyTools
{
    public class Encoder
    {
        private Models.RSAKeys keys;
        public Encoder(int? p = null, int? q = null)
        {
            // Todo: Adicionar função de poder enviar a chave pelo ctor
            KeyGenerator keyGenerator = new KeyGenerator();
            keys = keyGenerator.CreateKeys(p, q);
        }

        public List<int> Encrypt(string message)
        {
            var encryptedMessage = new List<int>();
            foreach (var character in message)
            {
                var messageAscii = (int)character;
                encryptedMessage.Add((int)BigInteger.ModPow(messageAscii, keys.Public.E, keys.Public.N));
            }
                

            return encryptedMessage;
        }

        //test
        public char Decrypt(int x)
        {
            var a = BigInteger.ModPow(x, keys.Private.D, keys.Private.N);
            return (char)a;
        }

    }
}
