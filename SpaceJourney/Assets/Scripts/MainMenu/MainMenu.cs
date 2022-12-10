using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public ProfileSlot[] slot;

    public TMP_Text playerName;

    public GameObject userInputUI;

    public GameObject loadingScene;
    public Slider bar;

    public void CheckSlot()
    {
        // if (){

        // }
    }


    public AsyncOperation operation;

    public void PlayGame(bool isNewGame)
    {
        if (playerName.text != "")
        {
            loadingScene.SetActive(true);
            operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            if (isNewGame)
            {
                GameManager.instance.RestartGame();
                GameManager.instance.playerQuest.isNewGame = true;
                GameManager.instance.player.name = playerName.text;
            }
            StartCoroutine(GetSceneLoadProgress());
        }
    }
    public IEnumerator GetSceneLoadProgress()
    {
        while (!operation.isDone)
        {
            float totalprogress = (operation.progress / .9f);
            bar.value = Mathf.Clamp01(totalprogress);

            yield return null;
        }
    }

    // public void PlayGame (int sceneIndex)
    // {

    //    StartCoroutine(GetSceneLoadProgress(sceneIndex));
    // }
    // public IEnumerator GetSceneLoadProgress(int sceneIndex)
    // {
    //       AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex+1);
    //       loadingScene.SetActive(true);

    //    while (!operation.isDone)
    //    {
    //          float progress = Mathf.Clamp01(operation.progress/ .9f);
    //          bar.value = progress;

    //          yield return null;
    //    }
    // }



    public void QuitGame()
    {
        Application.Quit();
    }

    public void activateProfile()
    {
        //slot.thisFull = true;
    }

    public void deactivateProfile()
    {
        // slot.thisFull = false;
    }



}
