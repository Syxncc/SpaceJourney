#if UNITY_EDITOR
namespace MyApp
{
    using UnityEditor;
    using UnityEngine;

    public static class EditorTools
    {
        public static void Line()
        {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        }
        #region Box
        public static void Box_Open(string name = null)
        {
            GUILayout.BeginVertical("box");
            if (!string.IsNullOrEmpty(name))
            {
                GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(name, EditorStyles.boldLabel);
                GUILayout.EndHorizontal();
            }
        }
        public static void Box_Close()
        {
            GUILayout.EndVertical();
        }
        #endregion
        #region info
        public static void Info(string caption, string value)
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(caption + ": " + value);
            GUILayout.EndHorizontal();
        }
        #endregion
        public static bool Foldout(ref bool foldout, string title = null)
        {
            return foldout = EditorGUILayout.Foldout(foldout, title);
        }
        public static SerializedProperty PropertyField(SerializedObject input, string name, string caption = null, string hint = null)
        {
            if (string.IsNullOrEmpty(name)) return null;

            var result = input.FindProperty(name);

            if (string.IsNullOrEmpty(caption))
            {
                EditorGUILayout.PropertyField(result, true);
            }
            else
            {
                if (string.IsNullOrEmpty(hint))
                    EditorGUILayout.PropertyField(result, new GUIContent(caption), true);
                else EditorGUILayout.PropertyField(result, new GUIContent(caption, hint), true);
            }
            return result;
        }
        public static bool Popup(ref int index, string[] options, string title = null)
        {
            string t = string.IsNullOrEmpty(title) ? "" : title;

            EditorGUI.BeginChangeCheck();
            GUILayout.BeginHorizontal();
            GUILayout.Label(t);
            index = EditorGUILayout.Popup(index, options);
            GUILayout.EndHorizontal();

            return EditorGUI.EndChangeCheck();
        }
    }
}
#endif