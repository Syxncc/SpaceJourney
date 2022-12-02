using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float life = 3f;
    private float value;

    void Awake() {
        Destroy(gameObject, life);
    }
    
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Asteroid"){
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
            if(Random.value > 0.9) //%50 percent chance
            {
                LootBlue();
            }
 
            if(Random.value > 0.8) //%80 percent chance (1 - 0.2 is 0.8)
            { 
                LootGreen();
            }
 
            if(Random.value > 0.7) //%30 percent chance (1 - 0.7 is 0.3)
            { 
                LootRed();
            }

            if(Random.value > 0.6) //%30 percent chance (1 - 0.7 is 0.3)
            { 
                Debug.LogError("BetterLuckNextTime");
            }
        }
        // else {
        //     Destroy(gameObject);
        // }
        
        
    }

    public void LootBlue(){
        PlayerManager.playerbluegem++;
    }
    public void LootRed(){
        PlayerManager.playerredgem++;
    }
    public void LootGreen(){
        PlayerManager.playergreengem++;
    }
}
