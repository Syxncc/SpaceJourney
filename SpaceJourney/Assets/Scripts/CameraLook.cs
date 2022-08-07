//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[RequireComponent(typeof(CinemachineFreeLook))]

public class CameraLook : MonoBehaviour
{

    private CinemachineFreeLook cinemachine;

    private Player playerInput;

    [SerializeField]
    private float lookSpeed = 1;

    private void Awake(){
        playerInput = new Player();
        cinemachine = GetComponent<CinemachineFreeLook>();
    }

    private void OnEnable(){
        playerInput.Enable();
    }

    private void OnDisable(){
        playerInput.Disable();
    }

    void Update()
    {
        Vector2 delta = playerInput.PlayerMain.Look.ReadValue<Vector2>();
        cinemachine.m_XAxis.Value += delta.x * 200 * lookSpeed * Time.deltaTime;
        cinemachine.m_YAxis.Value += delta.y * lookSpeed * Time.deltaTime;
    }
}
