

using System.Security.Cryptography;

namespace CommonLayer.InfoSecure
{
    public class InfoSecure
    {

        // generate data key :
         public static string GenerateKey()
        {
            string base64key = string.Empty;
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.GenerateKey();
                base64key = Convert.ToBase64String(aes.Key);
            }
            return base64key;
        }
        public static string Encrypt(string key, string plaintext, out string IVkey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Padding = PaddingMode.Zeros;
                aes.Key = Convert.FromBase64String(key);
                aes.GenerateIV();
               IVkey = Convert.ToBase64String(aes.IV);  
                ICryptoTransform cryptoTransform = aes.CreateEncryptor();
                byte[] encryptedData;
                using(MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
                    {
                        using(StreamWriter  sw = new StreamWriter(cs)) { 
                        
                            sw.Write(plaintext);
                        }
                        encryptedData = ms.ToArray();
                         
                    };
                }
                return Convert.ToBase64String(encryptedData);
            }
        }

        // decrypter:

        public static string Decrypt(string CipherText, string key,  string IVkey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Padding = PaddingMode.Zeros;
                aes.Key = Convert.FromBase64String(key);
                 aes.IV = Convert.FromBase64String(IVkey);
                IVkey = Convert.ToBase64String(aes.IV);

                ICryptoTransform cryptoTransform = aes.CreateDecryptor();
                string PlainText = "";
                byte[] chiper = Convert.FromBase64String(CipherText);
                using (MemoryStream ms = new MemoryStream(chiper))
                {
                    using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
                    {
                        using (StreamReader dr = new StreamReader(cs))
                        {

                          PlainText = dr.ReadToEnd();
                        }
                        
                    };
                }
                return PlainText;
            }
        }

    }
}
