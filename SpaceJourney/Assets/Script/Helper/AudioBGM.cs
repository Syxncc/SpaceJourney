using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBGM : MonoBehaviour
{
    public string bgmName = "";
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMusic(bgmName);
    }
}
