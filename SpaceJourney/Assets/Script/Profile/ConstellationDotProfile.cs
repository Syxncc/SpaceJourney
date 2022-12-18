using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Constellation Dot Profile", menuName = "ScriptableObject/Profile/Constellation")]
public class ConstellationDotProfile : Profile
{
    [System.Serializable]
    public class ConnectedDots{
        public ConstellationDotProfile constellationDot;
        public bool isConnected;
    }

    public ConnectedDots[] connectedDots;
    
}
