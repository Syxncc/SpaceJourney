using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDistance : MonoBehaviour
{
    public TMP_Text newText;
    public Transform player;
    public float refreshRate = 1f;
    private float distance = 0;
    public Transform[] planets;

    private Transform nearestPlanet;

    void Start()
    {
        nearestPlanet = planets[0];
        InvokeRepeating("CheckDistance", 1, refreshRate);
    }

    void CheckDistance()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            distance = (nearestPlanet.position - player.position).magnitude;
            if (distance > (planets[i].position - player.position).magnitude)
            {
                nearestPlanet = planets[i];
            }
        }
        distance = (nearestPlanet.position - player.position).magnitude;
        newText.text = nearestPlanet.GetComponent<PlanetStats>().planetProfile.name + " " + (distance.ToString("F1") + "m");
    }
}
