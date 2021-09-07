using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAEncoder.CryptographyTools
{
    public class KeyGenerator
    {
        private Models.RSAKeys Keys { get; set; }

        public Models.RSAKeys CreateKeys(int? p = null, int? q = null)
        {
            RSAAlgorithm rsaCreator = new RSAAlgorithm();
            Models.RSANumbers rsaNumbers = rsaCreator.GetRSANumbers(p, q);
            var keys = new Models.RSAKeys();
            keys.Public.E = rsaNumbers.E;
            keys.Public.N = rsaNumbers.N;
            keys.Private.D = rsaNumbers.D;
            keys.Private.N = rsaNumbers.N;

            return keys;
        }

        public Models.RSAKeys GetKeysFromFile()
        {
            // TODO: Retornar dos Arquivos

            return null;
        }
    }
}
