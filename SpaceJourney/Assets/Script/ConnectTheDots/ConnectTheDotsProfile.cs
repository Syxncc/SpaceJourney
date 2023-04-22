using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectTheDotsProfile : MonoBehaviour
{

    public Collectible constellation;
    public GameObject constellationContent;

    public ConstellationDotProfile[] GetAllConstellationDot()
    {
        return constellation.constellationDotProfiles;
    }

    public void SetContentActive(bool active)
    {
        constellationContent.SetActive(active);
        gameObject.SetActive(false);
    }
}
