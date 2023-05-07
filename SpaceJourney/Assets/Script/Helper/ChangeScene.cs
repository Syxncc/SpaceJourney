using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public int scene = -1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && scene != -1)
        {
            GameManager.instance.ChangeScene(scene);
        }
    }
}
