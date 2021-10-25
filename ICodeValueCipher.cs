using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptor
{
    public interface ICodeValueCipher
    {
        string Decrypt(string message, string key);

        string Encrypt(string message, string key);
    }
}
