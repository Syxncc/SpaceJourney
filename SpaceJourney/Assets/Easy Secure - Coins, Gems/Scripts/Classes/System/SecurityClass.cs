namespace MyApp.CoinsManager
{
    using System.Text;
    using System.Security.Cryptography;

    public static class SecurityClass
    {
        #region SHA 256
        public static string Sha256_saltAndRound(string input)
        {
            return Sha256(input, Globals.SHA_SALT, Globals.SHA_ROUND);
        }
        public static string Sha256(string input, string salt, int round)
        {
            int i = round > 0 ? round : 1;
            string result = input + salt;
            for (int j = 0; j < i; j++)
            {
                result = Sha256(result);
            }
            return result;
        }
        public static string Sha256(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        #endregion
    }
}