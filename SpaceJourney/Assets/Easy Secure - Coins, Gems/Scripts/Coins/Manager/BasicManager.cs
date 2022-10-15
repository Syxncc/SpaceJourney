namespace MyApp.CoinsManager.Coins
{
    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    using UnityEngine.Events;
    using MyApp.CoinsManager.Coins.Movement;

    public abstract class BasicManager : MonoBehaviour
    {
        #region enum
        protected enum ManagerState { Null = -1, AddValue, SubtractValue }
        #endregion
        #region variable
        //[Header("Value")]
        [HideInInspector] public string assetName;
        [Min(0)] public int defaultValue = 0;

        public Text valueText;
        //[Header("Security")]
        public string App_ID = Globals.APP_ID;
        public string Key = Globals.Hash_Key<BasicManager>();
        [Min(1)] public int Round = Globals.SHA_ROUND;
        public string Salt = Globals.SHA_SALT;

        //[Header("Animation")]
        public bool animationEnable = false;
        [Range(0, 1)] public float generationCoefficient = .7f;
        public GameObject canvas;

        //[Header("Animation")]
        public Sprite sprite;
        public Vector3 rectTransformLocalScale = Vector3.one;
        //[Header("Animation Add")]
        [Min(1)] public int addAnimateLerp = 20;
        [Min(.001f)] public float addSecondsLerp = .03f;
        public Vector3 addMaxStartThreshold = new Vector3(.1f, 0, 0);
        public Vector3 addDeltaPosition = Vector3.zero;
        public UnityEvent addSound;
        //[Header("Animation Subtract")]
        [Min(1)] public int subtractAnimateLerp = 20;
        [Min(.001f)] public float subtractSecondsLerp = .03f;
        [Min(0)] public float subtractSpeed = 10f;
        public Vector3 directionVector = Vector3.up;
        public Vector3 subtractMaxStartThreshold = new Vector3(.1f, 0, 0);
        public Vector3 subtractDeltaPosition = Vector3.zero;
        public UnityEvent notEnoughValueDialogue;
        [Min(.00001f)] public float TimeToLife = 1f;
        public UnityEvent subtractSound;

        //[Header("Animation Text")]
        #region abstract
        protected abstract ValuableCore valueCore { get; set; }
        #endregion
        protected int Value
        {
            get { return valueCore.Value; }
        }
        #endregion
        #region functions
        #region value
        #region Subtract
        protected void SubtractValue(int price)
        {
            SubtractValue_(price);
        }
        protected bool SubtractValue_(int price)
        {
            if (valueCore.SubtractValue(price))
            {
                if (valueText != null) animateText_Run(valueCore.Value, -Mathf.Abs(price), ManagerState.SubtractValue);
                return true;
            }
            Debug.LogWarning(assetName + ": Not enough value...");
            if (notEnoughValueDialogue != null) notEnoughValueDialogue.Invoke();
            return false;
        }
        #endregion
        protected void AddValue(int val)
        {
            valueCore.AddValue(val);
            if (valueText != null) animateText_Run(valueCore.Value, val, ManagerState.AddValue);
        }
        protected void ResetValue()
        {
            valueCore.SaveValue(defaultValue);
        }
        #region save
        protected void SaveValue()
        {
            SaveValue(valueCore.Value);
        }
        protected void SaveValue(int val)
        {
            valueCore.SaveValue(val);
        }
        #endregion
        #endregion
        #region UI
        #region Value
        public void UpdateText()
        {
            valueCore.FetchValue();
            if (valueText == null) return;
            updateText(valueCore.Value);
        }
        private void updateText(int value)
        {
            valueText.text = value.ToString();
        }
        protected void animateText_Run(int totalValue, int deltaValue, ManagerState managerStatus = ManagerState.Null)
        {
            StartCoroutine(animateText(totalValue - deltaValue, deltaValue, managerStatus));
        }
        private void createMovement(Vector3 startPosition, int currentStep, int steps, float delaySecond, ManagerState coinManagerState)
        {
            if (sprite == null) return;
            switch (coinManagerState)
            {
                case ManagerState.AddValue:
                    createMovement_target(startPosition, currentStep, steps, delaySecond);
                    break;
                case ManagerState.SubtractValue:
                    createMovement_direction();
                    break;
            }
        }
        private void createMovement_target(Vector3 startPosition, int currentStep, int steps, float delaySecond)
        {
            var c = new GameObject();
            c.hideFlags = HideFlags.HideAndDontSave;
            Vector3 sPosition = new Vector3(Random.Range(0, addMaxStartThreshold.x)
                                , Random.Range(0, addMaxStartThreshold.y)
                                , Random.Range(0, addMaxStartThreshold.z))
                                + startPosition + addDeltaPosition;
            c.transform.position = sPosition;
            if (canvas != null)
            {
                c.transform.SetParent(canvas.transform);
            }

            c.AddComponent<Image>().sprite = sprite;

            var rt = c.GetComponent<RectTransform>();
            if (rt != null)
            {
                rt.localScale = rectTransformLocalScale;
            }
            var f = c.AddComponent<TargetMovement>();
            f.targerPosition = (valueText == null) ? transform.position : valueText.transform.position;
            f.onDestroyEvent = addSound;
            f.autoSpeedlculate(Mathf.Abs(steps - currentStep), delaySecond);
        }
        private void createMovement_direction()
        {
            var c = new GameObject();
            c.hideFlags = HideFlags.HideAndDontSave;
            Vector3 sPosition = new Vector3(Random.Range(0, subtractMaxStartThreshold.x)
                               , Random.Range(0, subtractMaxStartThreshold.y)
                               , Random.Range(0, subtractMaxStartThreshold.z))
                               + ((valueText == null) ? transform.position : valueText.transform.position)
                               + subtractDeltaPosition;
            c.transform.position = sPosition;
            if (canvas != null)
            {
                c.transform.SetParent(canvas.transform);
            }

            c.AddComponent<Image>().sprite = sprite;

            var rt = c.GetComponent<RectTransform>();
            if (rt != null)
            {
                rt.localScale = rectTransformLocalScale;
            }

            var f = c.AddComponent<DirectionMovement>();
            f.directionVector = directionVector;
            f.onDestroyEvent = subtractSound;
            f.speed = subtractSpeed;
            Object.Destroy(c, TimeToLife);
        }
        private IEnumerator animateText(int startCoins, int deltaCoins, ManagerState managerStatus)
        {
            int lerp = 20;
            float secondsLerp = .03f;
            if (managerStatus == ManagerState.AddValue)
            {
                lerp = addAnimateLerp;
                secondsLerp = addSecondsLerp;
            }
            else if (managerStatus == ManagerState.SubtractValue)
            {
                lerp = subtractAnimateLerp;
                secondsLerp = subtractSecondsLerp;
            }
            if (lerp < 1) lerp = 20;

            float delta = (float)deltaCoins / lerp;
            Vector2 startPosition = getStartPosition(managerStatus);
            int i = 0;
            while (i++ < lerp)
            {
                int injection = (int)(i * delta);
                if (animationEnable && managerStatus != ManagerState.Null && i < lerp * (generationCoefficient))
                    createMovement(startPosition, i, lerp, secondsLerp, managerStatus);
                updateText(startCoins + injection);
                yield return new WaitForSeconds(secondsLerp);
            }
        }
        #endregion
        #endregion
        #region mouse position
        private Vector2 getStartPosition(ManagerState state)
        {
            if (state != ManagerState.Null) return getMousePosition();
            return default;
        }
        private Vector2 getMousePosition()
        {
            //Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return (Input.mousePosition);
        }
        #endregion
        #endregion
    }
}