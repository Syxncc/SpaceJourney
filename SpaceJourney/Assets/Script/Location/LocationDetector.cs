using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationDetector : MonoBehaviour
{
    public Location location;
    public bool isEvaluteTimer = false;
    public bool isQuestTimerObjective = false;

    void OnTriggerEnter(Collider other)
    {
        if (isEvaluteTimer)
        {
            GameManager.instance.ChangeMessagePopupPanel(true, null, false);
        }
        if (other.tag == "Player")
        {
            if (GameManager.instance.onDestinationCallback != null)
            {
                GameManager.instance.PopUpNotification("You found \"" + location.name + "\"!");
                GameManager.instance.onDestinationCallback.Invoke(location);
            }

            if (isQuestTimerObjective && GameManager.instance.countdownTimer.timerIsRunning)
            {
                GameManager.instance.IncreaseCount();
            }
            if (location.hideOnComplete)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
