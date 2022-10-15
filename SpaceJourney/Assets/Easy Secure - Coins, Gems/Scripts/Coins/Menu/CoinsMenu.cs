#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MyApp.CoinsManager.Coins
{
    public class CoinsMenu : MainMenu
    {
        #region Asset Manager
        [MenuItem(MyGlobals.RootName+"/"+ Globals.PROJECT_NAME + "/Asset Manager/" + MainMenuItem.Add)]
        public static void AddAssetManagerManager()
        {
            List<AssetManager> nodes;
            if (Selection.objects == null || Selection.objects.Length < 1)
            {
                //nodes = new List<AssetManager>() { MainMenu.AddComponentToObject<AssetManager>("_AssetManager") };
            }
            else
            {
               // nodes = MainMenu.AttachComponentToSelection<AssetManager>();
            }
            nodes = new List<AssetManager>() { AddComponentToObject<AssetManager>("_AssetManager") };
            if (nodes != null)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (!nodes[i].getNewAssetCore().hasDataInStore())
                        nodes[i].Key += Random.Range(0, int.MaxValue);
                }
            }
        }
        [MenuItem(MyGlobals.RootName + "/" + Globals.PROJECT_NAME + "/Asset Manager/" + MainMenuItem.SelectAll)]
        public static void SelectAllCoinManager()
        {
            SelectAllObjectsByComponent<AssetManager>();
        }

        [MenuItem(MyGlobals.RootName + "/" + Globals.PROJECT_NAME + "/Asset Manager/" + MainMenuItem.RemoveAll)]
        public static void RemoveAllCoinManager()
        {
            RemoveComponentFromSelection<AssetManager>();
        }
        [MenuItem(MyGlobals.RootName + "/" + Globals.PROJECT_NAME + "/Asset Manager/" + MainMenuItem.SelectAndRemoveAll)]
        public static void SelectAndRemoveAllCoinManager()
        {
            SelectAllCoinManager();
            RemoveAllCoinManager();
        }
        #endregion
        #region debug
        [MenuItem(MyGlobals.RootName + "/" + Globals.PROJECT_NAME + "/Help/" + MainMenuItem.Debug)]
        public static void Debug_001()
        {
            var nodes = FindObjectsOfType<BasicManager>();
            if (nodes == null || nodes.Length < 1)
            {
                Debug.LogWarning("Not valuable manager founded.");
            }
            else
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    for (int j = 0; j < nodes.Length; j++)
                    {
                        if (i == j) continue;
                        if (nodes[i].Key == nodes[j].Key)
                        {
                            Debug.LogError("Same Key founded.");
                            return;
                        }
                    }
                }
                Debug.Log("Debug completed. Have a good time :)");
            }
        }

        [MenuItem(MyGlobals.RootName + "/" + Globals.PROJECT_NAME + "/Help/" + MainMenuItem.FixProblems)]
        public static void FixProblems()
        {
            var nodes = FindObjectsOfType<BasicManager>();
            if (nodes == null || nodes.Length < 1)
            {
                Debug.Log("Not valuable manager founded.");
            }
            else
            {
                int count = 0;
                for (int i = 0; i < nodes.Length; i++)
                {
                    for (int j = 0; j < nodes.Length; j++)
                    {
                        if (i == j) continue;
                        if (nodes[i].Key == nodes[j].Key)
                        {
                            count++;
                            nodes[j].Key += Random.Range(0, int.MaxValue);
                            return;
                        }
                    }
                }
                Debug.Log(count + " problem(s) fixed. Have a good time :)");
            }
        }
        #endregion
    }
}
#endif