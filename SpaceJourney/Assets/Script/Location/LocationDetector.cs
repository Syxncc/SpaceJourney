using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationDetector : MonoBehaviour
{
    public Location location;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.LogError("I detected the pakyer");
            if (GameManager.instance.onDestinationCallback != null)
            {
                GameManager.instance.PopUpNotification("You found \"" + location.name + "\"!");
                GameManager.instance.onDestinationCallback.Invoke(location);
            }
        }
    }
}
