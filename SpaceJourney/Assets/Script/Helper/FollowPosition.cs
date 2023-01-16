using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public Transform target;
    public float adjustYPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, adjustYPosition, target.position.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, target.eulerAngles.y, target.eulerAngles.z);
    }
}
