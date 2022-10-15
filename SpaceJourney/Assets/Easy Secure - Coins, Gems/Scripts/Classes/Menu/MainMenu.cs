#if UNITY_EDITOR
namespace MyApp.CoinsManager
{
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    public class MainMenu : MonoBehaviour

    {
        #region PlayerPrefs
        [MenuItem(MyGlobals.RootName + "/" + Globals.PROJECT_NAME + "/PlayerPrefs/" + MainMenuItem.SaveAll)]
        private static void SavePlayerPrefs()
        {
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefs saved");
        }

        [MenuItem(MyGlobals.RootName + "/" + Globals.PROJECT_NAME + "/PlayerPrefs/" + MainMenuItem.DeleteAll)]
        private static void DeletePlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("All PlayerPrefs deleted");
        }
        #endregion

        #region About us
        [MenuItem(MyGlobals.RootName + "/Publisher Page")]
        public static void PublisherPage()
        {
            Application.OpenURL("https://assetstore.unity.com/publishers/48757");
        }
        #endregion
        #region Support
        [System.Obsolete]
        [MenuItem(MyGlobals.RootName + "/Support")]
        public static void Support()
        {
            TextWindow window = (TextWindow)EditorWindow.GetWindow(typeof(TextWindow));
            window.title = window.Title = "Support";
            window.Descriptions = new string[] { "If you need any further assistance, please contact us", "unrealisticarts@gmail.com" };
        }
        #endregion
        #region Component
        public static T AddComponentToObject<T>(string name) where T : Component
        {
            GameObject node = new GameObject(name);
            node.transform.SetPositionAndRotation(getPosition(), Quaternion.identity);
            var t = node.AddComponent<T>();
            Undo.RegisterCreatedObjectUndo(node, "Create object");
            Selection.objects = new Object[] { node };
            return t;
        }
        public static List<T> AttachComponentToSelection<T>() where T : Component
        {
            if (Selection.objects == null || Selection.objects.Length < 1) return null;
            List<T> list = new List<T>();
            for (int i = 0; i < Selection.objects.Length; i++)
            {
                var node = (GameObject)Selection.objects[i];
                if (node == null) continue;
                Undo.AddComponent<T>(node);
                var t = node.GetComponents<T>();
                if (t != null)
                {
                    foreach (var n in t)
                    {
                        list.Add(n);
                    }
                }
            }
            return list;
        }
        public static void RemoveComponentFromSelection<T>() where T : Component
        {
            if (Selection.objects == null) return;
            T function;
            for (int i = 0; i < Selection.objects.Length; i++)
            {
                var node = (GameObject)Selection.objects[i];
                if (node == null || (function = node.GetComponent<T>()) == null) continue;
                Undo.DestroyObjectImmediate(function);
            }
        }
        public static void SelectAllObjectsByComponent<T>() where T : Component
        {
            var nodes = FindObjectsOfType<T>();
            List<Object> result = new List<Object>();
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    if (node == null) continue;
                    result.Add(node.gameObject);
                }
            }

            Selection.objects = result.ToArray();
        }
        #endregion
        private static Vector2 getPosition()
        {
            return Vector2.zero;
        }
    }
}
#endif