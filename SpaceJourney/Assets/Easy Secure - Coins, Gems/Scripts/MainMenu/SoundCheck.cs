using UnityEngine;
using UnityEngine.UI;

public class SoundCheck : MonoBehaviour
{
    public Text soundText;
    bool isSound;
    private void Start()
    {
        if(PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            AudioListener.volume = 1;
            isSound = true;
            soundText.text = "SOUND: ON";
        }
        else
        {
            AudioListener.volume = 0;
            isSound = false;
            soundText.text = "SOUND: OFF";
        }
    }

    public void VolumeChange()
    {
        if (isSound)
        {
            AudioListener.volume = 0;
            soundText.text = "SOUND: OFF";
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            AudioListener.volume = 1;
            soundText.text = "SOUND: ON";
            PlayerPrefs.SetInt("Sound", 1);
        }
        isSound = !isSound;
    }
}
