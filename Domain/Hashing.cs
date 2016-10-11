using System;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public class Hashing
    {
        public void GenerateHash()
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[32];
            rng.GetBytes(buff);
            var salt = Convert.ToBase64String(buff);

            var sha = new SHA512Managed();

            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes("P@ssword5" + salt));

            var base64Hash = Convert.ToBase64String(hash);


            // Troy Hunt
            var builder = new StringBuilder();


            foreach (var t in hash)
            {
                builder.Append(t.ToString("x2"));
            }


            var stringHash = builder.ToString();
        }
    }
}
