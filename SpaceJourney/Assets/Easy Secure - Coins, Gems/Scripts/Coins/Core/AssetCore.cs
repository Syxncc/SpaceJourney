namespace MyApp.CoinsManager.Coins
{
    [System.Serializable]
    public class AssetCore : ValuableCore
    {
        #region variable
        public int Coins { get { return Value; } }
        public override string ValueKeyCode { get { return "_asset"; } }
        #endregion
        #region constructor
        public AssetCore() : this(Globals.APP_ID_<AssetCore>(), Globals.Hash_Key<AssetCore>(), Globals.SHA_ROUND, Globals.SHA_SALT,0)
        {
        }
        public AssetCore(string app_ID, string hash_Key, int hashRound, string hashSalt,int defaultValue=0)
            : base(app_ID, hash_Key, hashRound, hashSalt,defaultValue)
        {

        }
        #endregion
    }
}