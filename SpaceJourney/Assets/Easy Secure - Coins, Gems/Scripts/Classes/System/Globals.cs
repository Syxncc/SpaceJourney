namespace MyApp.CoinsManager
{
    public static class Globals
    {
        public const string PROJECT_NAME = "Easy Secure - Coins, Gems";
        private static System.Random rand = new System.Random();
        public const string APP_ID = "App_ID";
        #region SHA security
        public const int SHA_ROUND = 2;
        public const string SHA_SALT = "SomeSalt";
        #endregion
        public static string APP_ID_<T>() where T : class
        {
            return APP_ID + "_" + typeof(T);
        }
        public static string Hash_Key<T>() where T : class
        {
            return APP_ID + "_" + typeof(T) + "_s";
        }
        public static string AttachRandom(string input)
        {
            return input + rand.Next(0, int.MaxValue);
        }
    }
}