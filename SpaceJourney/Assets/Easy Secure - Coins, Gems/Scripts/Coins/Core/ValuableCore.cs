namespace MyApp.CoinsManager.Coins
{
    using UnityEngine;
    [System.Serializable]
    public abstract class ValuableCore
    {
        #region variable
        #region abstract
        public abstract string ValueKeyCode { get; }
        #endregion
        public int Value { get; private set; }
        protected int DefaultValue = 0;
        #region private
        #region readonly
        private readonly string APP_ID;
        private readonly string Hash_Key;
        private readonly int Hash_Round;
        private readonly string Hash_Salt;
        #endregion
        private string value_KEY { get { return APP_ID + Hash_Key + ValueKeyCode; } }
        private string value_hash_KEY { get { return value_KEY + "_signature"; } }
        #endregion
        #endregion
        #region functions
        #region constructor
        public ValuableCore(string app_ID, string hash_Key, int hashRound, string hashSalt, int defaultValue = 0)
        {
            APP_ID = app_ID;
            Hash_Key = hash_Key;
            Hash_Round = hashRound;
            Hash_Salt = hashSalt;
            DefaultValue = defaultValue;
        }
        #endregion
        #region hash
        private string getHash(int val)
        {
            return SecurityClass.Sha256(val.ToString(), Hash_Salt, Hash_Round);
        }
        #endregion
        #region Logic
        public void AddValue(int value)
        {
            SaveValue(FetchValue() + Mathf.Abs(value));
        }
        public bool SubtractValue(int value)
        {
            var v = Mathf.Abs(value);
            int realValue = FetchValue();
            if (realValue < v) return false;
            SaveValue(realValue - v);
            return true;
        }
        public void ResetValue()
        {
            SaveValue(DefaultValue);
        }
        public void SaveValue(int value)
        {
            Value = value;
            PlayerPrefs.SetInt(value_KEY, Value);
            PlayerPrefs.SetString(value_hash_KEY, getHash(Value));
            PlayerPrefs.Save();
        }
        public int FetchValue()
        {
            Value = PlayerPrefs.GetInt(value_KEY);
            string hash = PlayerPrefs.GetString(value_hash_KEY);
            if (hash.Equals(getHash(Value)))
                return Value;
            return Value = DefaultValue;
        }
        public bool hasDataInStore()
        {
            return PlayerPrefs.HasKey(value_KEY);
        }
        #endregion
        #endregion
    }
}