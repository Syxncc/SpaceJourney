using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public Profile profile;
    private float currentHP;
    public string colliderTag = "";
    private bool isDestroyed = false;
    public GameObject explosionFX;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = profile.currentMaxHP;
    }

    public float GetCurrentHPPercent()
    {
        return currentHP / profile.currentMaxHP;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(colliderTag))
        {
            DamgeTaken(1);
        }
    }

    void DamgeTaken(int damageTaken)
    {
        if (currentHP > 0)
        {
            currentHP -= damageTaken;
        }
        else
        {

            if (explosionFX != null)
            {
                GameObject newExplosion = Instantiate(explosionFX, transform.position, Quaternion.identity);

                Destroy(newExplosion, 3);
            }
            if (!isDestroyed)
            {
                isDestroyed = true;
                if (GameManager.instance.onItemDestroyCallback != null)
                {
                    GameManager.instance.onItemDestroyCallback.Invoke(profile);
                }

                if (GameManager.instance.countdownTimer != null)
                {
                    if (GameManager.instance.countdownTimer.isUsingLimitCount)
                    {
                        GameManager.instance.IncreaseCount();
                    }
                    else
                    {
                        GameManager.instance.ChangeMessagePopupPanel(true, null, true);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
