using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustPosition : MonoBehaviour
{
    public AdjustTransformPosition[] adjustPositions;

    [System.Serializable]
    public class AdjustTransformPosition
    {
        public float adjustNum = 0;
        public int isCount = 0;

    }

    // void Start()
    // {
    //     transform.position = new Vector3((transform.position.x * adjustPositions[0].isCount) + adjustPositions[0].adjustNum, (transform.position.y * adjustPositions[1].isCount) + adjustPositions[1].adjustNum, (transform.position.z * adjustPositions[2].isCount) + adjustPositions[2].adjustNum);
    // }

    void Update()
    {

        transform.position = new Vector3((transform.position.x * adjustPositions[0].isCount) + adjustPositions[0].adjustNum, (transform.position.y * adjustPositions[1].isCount) + adjustPositions[1].adjustNum, (transform.position.z * adjustPositions[2].isCount) + adjustPositions[2].adjustNum);
    }
}
