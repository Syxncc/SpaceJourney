using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public QuestBase quest;
    public float tempTimer = 0;
    public bool timerIsRunning = false;
    public int timeCountType = 0; //0 stopwatch, 1 timer, 2 means count

    [HideInInspector]
    public int tempCount = 0;
    public int limitCount = 6;
    public TMP_Text timeText;
    public TMP_Text timeTitle;
    public TMP_Text timeResult;
    public string message;
    public GameObject questObject;
    public GameObject startPanel;
    public TMP_Text startPanelButtonText;
    public GameObject userInterface;
    public bool isStart = false;
    public bool isUsingLimitCount = false;
    void Start()
    {
        ValidateCurrentHighScore(false);
        tempCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeCountType != 2)
            {
                if (timeCountType == 0)
                {
                    tempTimer += Time.deltaTime;
                }
                else
                {
                    if (tempTimer > 0)
                    {
                        tempTimer -= Time.deltaTime;
                    }
                    else
                    {
                        Debug.Log("Time has run out!");
                        ValidateCurrentHighScore(true);
                        tempTimer = 0;
                        isStart = true;
                        timerIsRunning = false;
                    }
                }
            }
            if (limitCount <= tempCount && isUsingLimitCount)
            {
                ValidateCurrentHighScore(true);
            }
            timeText.text = message + ": " + DisplayTime(tempTimer);
        }
    }

    public void StartTimer()
    {
        userInterface.SetActive(true);
        if (!isStart)
        {
            timerIsRunning = true;
            timeText.gameObject.SetActive(true);
            questObject?.SetActive(true);
            startPanel?.SetActive(false);
            tempCount = 0;
            if (timeCountType != 1)
            {
                tempTimer = 0;
                return;
            }
            tempTimer = quest.maxTime;
            Debug.Log(tempTimer);
        }
        else
        {
            GameManager.instance.ChangeScene(-1);
        }
    }

    string DisplayTime(float timeToDisplay)
    {
        string count = "";
        if (timeCountType == 2)
        {
            count = timeToDisplay.ToString();
        }
        else
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            count = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        return count;
    }

    public void ValidateCurrentHighScore(bool isLose)
    {
        string tempMessage = "";
        string tempTitle = "";
        userInterface.SetActive(false);
        if (timerIsRunning)
        {
            timerIsRunning = false;
            timeText.gameObject.SetActive(false);
            questObject?.SetActive(false);
            startPanel?.SetActive(true);
            if (isLose)
            {
                tempTitle = "Game Over!!!";
                startPanelButtonText.text = "TRY AGAIN";
            }
            else
            {
                startPanelButtonText.text = "START";
                if (quest.currentHighScore < tempTimer || (timeCountType == 1 && quest.currentHighScore > tempTimer))
                {
                    tempTitle = "You achieve new high score!!!";
                    quest.currentHighScore = Mathf.Round(tempTimer);
                }
            }
            timeTitle.text = tempTitle;
            // SetActiveObject(false);
        }
        if (timeCountType == 1)
        {
            tempMessage = "Time Limit: " + DisplayTime(quest.maxTime) + "\n";
            Debug.Log(tempMessage);
        }
        timeResult.text = tempMessage + "" + "Current High Score: " + DisplayTime(quest.currentHighScore) + "\nResult: " + DisplayTime(Mathf.Round(tempTimer));
    }

    public void SetActiveObject(bool isActive)
    {
        questObject?.SetActive(isActive);
        startPanel?.SetActive(!isActive);
        timeText.gameObject.SetActive(isActive);
        userInterface.SetActive(isActive);
    }

}
