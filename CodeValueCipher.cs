using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cryptor
{
    public class CodeValueCipher : ICodeValueCipher
    {
        public string Encrypt(string message, string key)
        {
            string encrypt = CryptIt(message, key, false);
            return encrypt;
        }
        public string Decrypt(string message, string key)
        {
            string decrypt = CryptIt(message, key, true);
            return decrypt;
        }

        private string CryptIt(string message, string key, bool action)
        {
            string userErrorNotification = "Input have to be only letters or spaces, please correct your input and try again";
            Regex rx = new Regex(("^[a-zA-Z ]*$"));
            if (!rx.IsMatch(message)) return userErrorNotification;

            string orderedKey = String.Concat(key.OrderBy(k => k));
            string unOrderedKey = key;
            key = action ? orderedKey : unOrderedKey;

            var sb = new StringBuilder("", 26);

            for (int i = 0; i < message.Length; i++)
            {
                if (key.IndexOf(message[i]) >= 0)
                {
                    int idx = key.IndexOf(message[i]);
                    Char lookFor = key[idx];

                    int dx = action ? 
                        unOrderedKey.IndexOf(lookFor) : 
                        orderedKey.IndexOf(lookFor);

                    var correspond = key[dx];

                    var tmp = (Char.IsLetter(lookFor) && Char.IsUpper(lookFor)) ?
                        Char.ToUpper(correspond) :
                            Char.IsLetter(lookFor) ? Char.ToLower(correspond) : lookFor;
                    sb.Append(tmp);
                }
            }
            return sb.ToString();
        }

    }
}
