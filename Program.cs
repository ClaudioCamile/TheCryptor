using System;

namespace cryptor
{
    class Program
    {
        static void Main(string[] args)
        {
                                    
            string encryptionkey = "JIECHSDUGFRVAWNQTYBZOLKMPX";
            string messageToEncript = "ABC";

            CodeValueCipher cvc = new CodeValueCipher();

            // expect JIE
            string encryptedResult = cvc.Encrypt(messageToEncript, encryptionkey);
            Console.WriteLine("The message " + messageToEncript  + " Encrypted to: " + encryptedResult);

            // expect ABC
            messageToEncript = encryptedResult;
            encryptedResult = cvc.Decrypt(messageToEncript, encryptionkey);
            Console.WriteLine("The message " + messageToEncript + " Decrypted to: " + encryptedResult);

        }
    }
}