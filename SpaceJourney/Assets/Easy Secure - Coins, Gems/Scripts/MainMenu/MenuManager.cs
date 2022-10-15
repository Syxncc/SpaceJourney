using UnityEngine;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Time.timeScale = 1;
    }

    public void WebPage(string url)
    {
        Application.OpenURL(url);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }
}
