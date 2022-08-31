using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteract : MonoBehaviour
{
    [SerializeField]
    private Transform interactablePoint;
    
    [SerializeField]
    private float interactablePointRadius = 0.5f;

    [SerializeField]
    private LayerMask interactableMask;

    [SerializeField]
    private int objectToInteract;

    [SerializeField]
    private GameObject interactbtn;

    private readonly Collider[] interactCollider = new Collider[1];

    // Update is called once per frame
    void Update()
    {
        objectToInteract = Physics.OverlapSphereNonAlloc(interactablePoint.position, 
            interactablePointRadius, interactCollider, interactableMask);

        if (objectToInteract > 0){
            interactbtn.SetActive(true);
        }
        else{
            interactbtn.SetActive(false);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interactablePoint.position, interactablePointRadius);
    }
}
