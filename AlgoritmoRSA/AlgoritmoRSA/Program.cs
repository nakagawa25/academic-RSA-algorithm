using System;
using System.IO;

namespace AlgoritmoRSA
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var option = ChoiceOption();
                var encoder = SetEncoder(option);

                string continuation = string.Empty;
                do
                {
                    var cryptoOption = ShowCryptoMenu();

                    switch (cryptoOption)
                    {
                        case 1:
                            Console.WriteLine("Digite uma mensagem a ser criptografada: ");
                            var message = Console.ReadLine();
                            var encryptedMessage = encoder.Encrypt(message);
                            Console.WriteLine("Mensagem criptografada: " + encryptedMessage);
                            break;
                        case 2:
                            Console.WriteLine("Digite uma mensagem a ser decriptografada: ");
                            var messageToDecrypt = Console.ReadLine();
                            var decryptedMessage = encoder.Decrypt(messageToDecrypt);
                            Console.WriteLine(Environment.NewLine + "Mensagem decriptografada: " + decryptedMessage);
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            break;
                    }

                    Console.WriteLine(Environment.NewLine + "Digite (S) e pressione Enter para realizar uma nova operação. " + Environment.NewLine +
                                      "Digite qualquer outra tecla para fechar a aplicação.");

                    continuation = Console.ReadLine();

                    Console.Clear();
                } while (continuation == "s" || continuation == "S");
            }
            catch (RSAEncoder.Utils.CustomExceptions.PrimeNumberException error)
            {
                Console.WriteLine(" ========================================================================= ");
                Console.WriteLine("Erro no cálculo do RSA. " + error.Message);
                Console.WriteLine(" ========================================================================= ");
            }
            catch (IOException error)
            {
                Console.WriteLine(" ========================================================================= ");
                Console.WriteLine("Erro com os arquivos das chaves. " + error.Message);
                Console.WriteLine(" ========================================================================= ");
            }
            catch (Exception error)
            {
                Console.WriteLine(" ========================================================================= ");
                Console.WriteLine("Erro na aplicação. " + error.Message);
                Console.WriteLine(" ========================================================================= ");
            }
        }

        private static int ChoiceOption()
        {
            int optionNumber = 0;
            while (optionNumber <= 0 || optionNumber >= 4)
            {
                Console.Write("Escolha um opção: " + Environment.NewLine +
                                  "1 - Utilizar as chaves salvas anteriormente" + Environment.NewLine +
                                  "2 - Criar novas chaves e salvar (sobrescrevendo as anteriores)" + Environment.NewLine +
                                  "3 - Criar novas chaves sem salvá-las" + Environment.NewLine + Environment.NewLine +
                                  "Opção: ");
                var option = Console.ReadLine();

                if (!int.TryParse(option, out optionNumber))
                {
                    Console.WriteLine("Digite uma opção válida!" + Environment.NewLine + "Pressione Enter para continuar...");
                    Console.Clear();
                }
                else
                    break;
            }
            Console.Clear();
            return optionNumber;
        }

        private static RSAEncoder.CryptographyTools.Encoder SetEncoder(int option)
        {
            RSAEncoder.CryptographyTools.Encoder encoder;
            switch (option)
            {
                case 1:
                    encoder = new RSAEncoder.CryptographyTools.Encoder(Directory.GetCurrentDirectory(), false);
                    break;
                case 2:
                    encoder = new RSAEncoder.CryptographyTools.Encoder(Directory.GetCurrentDirectory(), true);
                    break;
                case 3:
                    encoder = new RSAEncoder.CryptographyTools.Encoder();
                    break;
                default:
                    throw new Exception("Opção Inválida.");
            }
            return encoder;
        }

        private static int ShowCryptoMenu()
        {
            int optionNumber = 0;
            while (optionNumber <= 0 || optionNumber >= 2)
            {
                Console.Write("Escolha um opção: " + Environment.NewLine +
                                  "1 - Criptografar" + Environment.NewLine +
                                  "2 - Decriptografar" + Environment.NewLine + Environment.NewLine +
                                  "Opção: ");
                var option = Console.ReadLine();

                if (!int.TryParse(option, out optionNumber))
                {
                    Console.WriteLine("Digite uma opção válida!"+ Environment.NewLine + "Pressione Enter para continuar...");
                    Console.Clear();
                }
                else
                    break;
            }
            Console.Clear();
            return optionNumber;
        }
    }
}
