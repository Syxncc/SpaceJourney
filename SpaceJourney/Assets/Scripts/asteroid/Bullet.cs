using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public float life = 3f;
    private float value;
    private Profile playerProfile;
    public GameObject meteorExplosion;
    private GameObject textShow;
    public GameObject textGem;


    void Awake()
    {
        Destroy(gameObject, life);
    }

    void Start()
    {
        textShow = GameManager.instance.textShow;
        playerProfile = GameManager.instance.playerManager.playerProfile;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<TakeDamage>() == null)
            {

                GameObject newExplosion = Instantiate(meteorExplosion, transform.position, Quaternion.identity);

                // newExplosion.transform.SetParent(gameObject.transform);
                Destroy(gameObject);
                Destroy(newExplosion, 3);
                Destroy(collision.gameObject);
                Debug.Log(textShow.transform.childCount + " s");
                if (textShow.transform.childCount < 3)
                {

                    GameObject newGemText = Instantiate(textGem, textShow.transform.position, Quaternion.identity);

                    newGemText.transform.SetParent(textShow.transform);
                    float value = Random.value;
                    Debug.Log(value);

                    if (value > 0.9) //%50 percent chance
                    {
                        Debug.Log("Got Blue");
                        newGemText.GetComponent<TMP_Text>().text = "<color=#0000FF>+1 blue gem</color>";
                    }
                    else if (value > 0.8) //%80 percent chance (1 - 0.2 is 0.8)
                    {
                        Debug.Log("Got green");
                        newGemText.GetComponent<TMP_Text>().text = "<color=#00FF00>+1 green gem</color>";
                    }
                    else if (value > 0.7) //%30 percent chance (1 - 0.7 is 0.3)
                    {
                        Debug.Log("GOT RED");
                        newGemText.GetComponent<TMP_Text>().text = "<color=#FF0000>+1 red gem</color>";
                    }
                    else if (value > 0.6) //%30 percent chance (1 - 0.7 is 0.3)
                    {
                        //newGemText.GetComponent<TMP_Text>().text = "<color=#FFFFFF>0 gem</color>";
                        Debug.Log("BetterLuckNextTime");
                    }
                    Destroy(newGemText, 2);
                }
            }

        }
        // else {
        //     Destroy(gameObject);
        // }


    }

    public int LootBlue()
    {
        return playerProfile.playerbluegem++;
    }
    public int LootRed()
    {
        return playerProfile.playerredgem++;
    }
    public int LootGreen()
    {
        return playerProfile.playergreengem++;
    }
}
