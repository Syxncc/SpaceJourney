#if UNITY_EDITOR
namespace MyApp.CoinsManager
{
    using UnityEditor;
    using UnityEngine;

    public class TextWindow : EditorWindow
    {
        public string Title = string.Empty;
        public string[] Descriptions;
        void OnGUI()
        {
            EditorTools.Box_Open();
            GUILayout.Label(Title, EditorStyles.boldLabel);
            if (Descriptions != null)
            {
                for (int i = 0; i < Descriptions.Length; i++)
                {
                    GUILayout.Label(string.IsNullOrEmpty(Descriptions[i]) ? string.Empty : Descriptions[i]);
                }
            }

            EditorTools.Box_Close();
            if (GUILayout.Button("Close"))
            {
                this.Close();
            }
        }
    }
}
#endif