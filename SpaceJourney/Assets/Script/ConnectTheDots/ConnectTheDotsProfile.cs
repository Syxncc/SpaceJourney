using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectTheDotsProfile : MonoBehaviour
{
    
    public Collectible constellation;

    public ConstellationDotProfile[] GetAllConstellationDot(){
        return constellation.constellationDotProfiles;
    }
}
