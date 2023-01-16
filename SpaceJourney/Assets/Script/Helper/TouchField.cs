using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class TouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public Vector2 TouchDist;
    [HideInInspector]
    protected Vector2 PointerOld;
    [HideInInspector]
    protected int PointerId;
    [HideInInspector]
    public bool Pressed;
    public bool UseFixedUpdate;
    public CinemachineFreeLook cinemachineFreeLook;
    public float ySpeed = .05f;
    // Update is called once per frame
    void Update()
    {
        if (!UseFixedUpdate)
            DoUpdate();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (UseFixedUpdate)
            DoUpdate();
    }

    private void DoUpdate()
    {
        if (Pressed)
        {
            if (PointerId >= 0 && PointerId < Input.touches.Length)
            {
                TouchDist = Input.touches[PointerId].position - PointerOld;
                PointerOld = Input.touches[PointerId].position;
            }
            else
            {
                TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
                PointerOld = Input.mousePosition;
            }
            float xAxis = PointerOld.x - TouchDist.x;
            cinemachineFreeLook.m_XAxis.Value = xAxis;
            if (cinemachineFreeLook.m_YAxis.Value >= 0 && cinemachineFreeLook.m_YAxis.Value <= 1)
            {
                if (TouchDist.y < 0)
                {
                    cinemachineFreeLook.m_YAxis.Value += ySpeed;
                }
                else if (TouchDist.y > 0)
                {
                    cinemachineFreeLook.m_YAxis.Value -= ySpeed;
                }
            }
        }
        else
        {
            TouchDist = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;
    }



    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

}
