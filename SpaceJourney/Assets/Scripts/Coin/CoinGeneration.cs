using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{

    public Transform Coin;
    public int coinCount = 15;

    // Start is called before the first frame update
    void Start()
    {
        for (int loop = 0; loop < coinCount; loop++){
            Vector3 coinSpawn = new Vector3(Random.Range(40, 180), Random.Range(-10, 0), Random.Range(0, 0));
            Instantiate(Coin, coinSpawn, Quaternion.identity);

            //Transform temp = Instantiate(Coin, Random.Range(0.5f, 5), Random.Range(0.5f, 5), Random.Range(0.5f, 5));
            //temp.localScale = temp.localScale * Random.Range(0.5f, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
