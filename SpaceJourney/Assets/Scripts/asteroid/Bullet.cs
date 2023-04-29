using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;
    private float value;
    private Profile playerProfile;
    public GameObject meteorExplosion;


    void Awake()
    {
        Destroy(gameObject, life);
    }

    void Start()
    {
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


                if (Random.value > 0.9) //%50 percent chance
                {
                    LootBlue();
                }

                if (Random.value > 0.8) //%80 percent chance (1 - 0.2 is 0.8)
                {
                    LootGreen();
                }

                if (Random.value > 0.7) //%30 percent chance (1 - 0.7 is 0.3)
                {
                    LootRed();
                }

                if (Random.value > 0.6) //%30 percent chance (1 - 0.7 is 0.3)
                {
                    Debug.Log("BetterLuckNextTime");
                }
            }

        }
        // else {
        //     Destroy(gameObject);
        // }


    }

    public void LootBlue()
    {
        playerProfile.playerbluegem++;
    }
    public void LootRed()
    {
        playerProfile.playerredgem++;
    }
    public void LootGreen()
    {
        playerProfile.playergreengem++;
    }
}
