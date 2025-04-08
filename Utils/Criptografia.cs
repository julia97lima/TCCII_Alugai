using System.Text;
using System.Security.Cryptography;

namespace Alugai.Utils
{
    public static class Criptografia
    {
        public static string Encriptar(string value)
        {
            UnicodeEncoding _enconde = new UnicodeEncoding();
            byte[] _hashBytes, _messageBytes = _enconde.GetBytes(value);

            SHA512Managed _sha = new SHA512Managed();

            var _stringHash = string.Empty;

            _hashBytes = _sha.ComputeHash(_messageBytes);

            foreach (byte b in _hashBytes)
                _stringHash += string.Format("{0:x2}", b);

            return _stringHash;
        }
    }
}
