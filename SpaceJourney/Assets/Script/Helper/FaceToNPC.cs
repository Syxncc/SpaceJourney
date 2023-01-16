using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FaceToNPC : MonoBehaviour
{
    public Profile npcProfile;
    private TMP_Text npcDisplayName;
    private Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        npcDisplayName = GetComponent<TMP_Text>();
        npcDisplayName.text = npcProfile.name;
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if (cameraTransform != null)
        // {
        // transform.LookAt(Camera.main.transform);
        // transform.localEulerAngles = new Vector3(0, 180, 0);
        transform.LookAt(transform.position + cameraTransform.rotation * Vector3.forward,
cameraTransform.rotation * Vector3.up);
        // }
    }
}
