#if UNITY_EDITOR
namespace MyApp.CoinsManager.Coins.Editors
{
    using UnityEditor;

    [CustomEditor(typeof(AssetManager))]
    public class AssetmanagerEditor : Editor
    {

        #region variable
        private string assetName;
        protected AssetManager Target;
        #endregion
        private void OnEnable()
        {
            Target = (AssetManager)target;
        }
        #region Inspector
        public override void OnInspectorGUI()
        {
            assetName = string.IsNullOrEmpty(Target.assetName) ? "Asset" : Target.assetName;
            serializedObject.Update();
            Parameter();
            EditorTools.Line();
            Security();
            EditorTools.Line();
            Animation();
            serializedObject.ApplyModifiedProperties();
        }
        private void Parameter()
        {
            EditorTools.Box_Open("Parameter(s)");
            EditorTools.PropertyField(serializedObject, "assetName", "Asset name");
            EditorTools.PropertyField(serializedObject, "defaultValue", "Default Value(" + assetName + ")", "Default " + assetName + " count.");
            EditorTools.PropertyField(serializedObject, "valueText", assetName + " text", "Text UI.");
            EditorTools.Box_Close();
        }
        private void Security()
        {
            EditorTools.Box_Open("Security");
            EditorTools.PropertyField(serializedObject, "Salt", "* Encryption Key", "Encryption Key");
            //EditorTools.PropertyField(serializedObject, "App_ID", "App_ID", "Application ID.");
            EditorTools.PropertyField(serializedObject, "Key", "* Key index", "Load and Store index. This value must be unique.");
            EditorTools.PropertyField(serializedObject, "Round", "Turning round(s)", "Warning: Higher value make some lags.");
            EditorTools.Box_Close();
        }
        #region Animation
        private void Animation()
        {
            EditorTools.Box_Open("Animation");
            EditorTools.PropertyField(serializedObject, "animationEnable", "Enable");
            if (Target.animationEnable)
            {
                EditorTools.PropertyField(serializedObject, "canvas", "Canvas", "Current canvas.");
                EditorTools.Line();
                AnimationParameters();
                EditorTools.Line();
                AnimationAdd();
                EditorTools.Line();
                AnimationSubtract();
            }
            EditorTools.Box_Close();
        }
        private void AnimationParameters()
        {
            EditorTools.Box_Open("Parameter(s)");
            EditorTools.PropertyField(serializedObject, "sprite", assetName + " sprite");
            EditorTools.PropertyField(serializedObject, "generationCoefficient", "Generation coefficient");
            EditorTools.PropertyField(serializedObject, "rectTransformLocalScale", "Transform local scale", "The 'Vector3' to scale sprite in canvas.");
            EditorTools.Box_Close();
        }
        private void AnimationAdd()
        {
            EditorTools.Box_Open("Add " + assetName);
            EditorTools.PropertyField(serializedObject, "addAnimateLerp", "Animate lerp");
            EditorTools.PropertyField(serializedObject, "addSecondsLerp", "Seconds lerp");
            EditorTools.PropertyField(serializedObject, "addDeltaPosition", "Delta position", "Fixed start position. The 'Vector3' value to change start location from hited position.");
            EditorTools.PropertyField(serializedObject, "addMaxStartThreshold", "Randomized position", "Randomized start position. The 'Vector3' value to change start location from hited position.");
            EditorTools.PropertyField(serializedObject, "addSound", "Add sound. UnityEvent type, invoke when add some " + assetName + ".");
            EditorTools.Box_Close();
        }
        private void AnimationSubtract()
        {
            EditorTools.Box_Open("Subtract " + assetName);
            EditorTools.PropertyField(serializedObject, "subtractAnimateLerp", "Animate lerp");
            EditorTools.PropertyField(serializedObject, "subtractSecondsLerp", "Seconds lerp");
            EditorTools.PropertyField(serializedObject, "subtractSpeed", "Speed", assetName + "`s speed.");
            EditorTools.PropertyField(serializedObject, "directionVector", "Direction", assetName + " flow direction.");
            EditorTools.PropertyField(serializedObject, "subtractDeltaPosition", "Delta position", "Fixed start position. The 'Vector3' value to change start location from hited position.");
            EditorTools.PropertyField(serializedObject, "subtractMaxStartThreshold", "Randomized position", "Randomized start position. The 'Vector3' value to change start location from hited position.");
            EditorTools.PropertyField(serializedObject, "TimeToLife", "Time to life (TTL)");
            EditorTools.PropertyField(serializedObject, "notEnoughValueDialogue", "Not enough Dialogue. UnityEvent type, invoke when " + assetName + " are not enough.");
            EditorTools.PropertyField(serializedObject, "subtractSound", "Subtract sound. UnityEvent type, invoke when subtract some " + assetName + ".");
            EditorTools.Box_Close();
        }
        #endregion
        #endregion

    }
}
#endif