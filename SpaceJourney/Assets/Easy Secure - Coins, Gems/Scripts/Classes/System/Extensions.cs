namespace MyApp.CoinsManager
{
    using UnityEngine;

    public static class Extensions
    {
        public static void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }
        public static Vector2 toXY(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }
    }
}