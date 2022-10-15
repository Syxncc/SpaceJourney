namespace MyApp.CoinsManager
{
    using MyApp.CoinsManager.Coins;
    public class AssetManager : BasicManager
    {
        #region variable
        private AssetCore assetCore;
        protected override ValuableCore valueCore { get { return assetCore; } set { assetCore = (AssetCore)value; } }
        #endregion
        #region Functions
        private void Awake()
        {
            assetCore = new AssetCore(App_ID, Key, Round, Salt, defaultValue);
            if (!assetCore.hasDataInStore())
            {
                assetCore.SaveValue(defaultValue);
            }
        }
        void Start()
        {
            UpdateText();
        }
        #endregion

        #region functions
        public AssetCore getNewAssetCore()
        {
            return new AssetCore(App_ID, Key, Round, Salt);
        }
        #region value
        #region Subtract
        public void SubtractValues(int price)
        {
            base.SubtractValue(price);
        }
        public bool SubtractValues_(int price)
        {
            return base.SubtractValue_(price);
        }
        #endregion
        public void AddValues(int val)
        {
            base.AddValue(val);
        }
        public void ResetValues()
        {
            base.ResetValue();
        }
        #region save
        public void SaveValues()
        {
            base.SaveValue();
        }
        public void SaveValues(int val)
        {
            base.SaveValue(val);
        }
        #endregion
        #endregion
        #endregion
    }
}