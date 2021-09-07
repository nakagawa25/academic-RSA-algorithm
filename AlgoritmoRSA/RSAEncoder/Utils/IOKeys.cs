using System;
using System.IO;

namespace RSAEncoder.Utils
{
    public static class IOKeys
    {
        public static void SaveKeys(string path, Models.RSAKeys keys)
        {
            string keysPath = Path.Combine(path, "Keys");
            Directory.CreateDirectory(keysPath);
            File.WriteAllText(Path.Combine(keysPath, "public_key.txt"), string.Concat(keys.Public.E, Environment.NewLine, keys.Public.N));
            File.WriteAllText(Path.Combine(keysPath, "private_key.txt"), string.Concat(keys.Private.D, Environment.NewLine, keys.Private.N));
        }

        public static Models.RSAKeys GetKeys(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                if (!File.Exists(Path.Combine(directoryPath, "private_key.txt")) || !File.Exists(Path.Combine(directoryPath, "private_key.txt")))
                    throw new IOException("O(s) arquvio(s) de chave do RSA não foram encontrados. ");

                var keys = new Models.RSAKeys();

                var privateKey = File.ReadAllLines(Path.Combine(directoryPath, "private_key.txt"));
                keys.Private.D = Convert.ToInt64(privateKey[0]);
                keys.Private.N = Convert.ToInt64(privateKey[1]);

                var publicKey = File.ReadAllLines(Path.Combine(directoryPath, "public_key.txt"));
                keys.Public.E = Convert.ToInt64(publicKey[0]);
                keys.Public.N = Convert.ToInt64(publicKey[1]);

                return keys;
            }
            else
                throw new IOException("O caminho " + directoryPath + " não existe.");
        }
    }
}
