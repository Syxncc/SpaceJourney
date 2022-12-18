using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ConnectTheDots : MonoBehaviour
{
    // list to store the dots that have been connected
    List<GameObject> connectedDots = new List<GameObject>();
    public GameObject lineController;

    private GameObject goDotOne;
    private GameObject goDotTwo;

    private Vector3 mousePositionOne;
    private Vector3 mousePositionTwo;
    Vector3 mousePositionInput;
    public GameObject parent;
    public GameObject IsPointerOverUIElement(bool first)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        if (results.Count > 0)
        {
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.tag == "Dot")
                {
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 67));
                    for (int i = 0; i < Input.touchCount; ++i)
                    {
                        if (first)
                        {
                            if (Input.GetTouch(i).phase == TouchPhase.Began)
                            {
                                // Construct a ray from the current touch coordinates
                                mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, 67));
                            }

                        }
                        else
                        {
                            if (Input.GetTouch(i).phase == TouchPhase.Ended)
                            {
                               mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, 67));
                            }
                        }
                    }
                    Vector2 mousePos3D = new Vector2(mousePos.x, mousePos.y);
                    if (first)
                    {
                        mousePositionOne = mousePos3D;
                    }
                    else
                    {
                        mousePositionTwo = mousePos3D;
                    }
                    return result.gameObject;
                }
            }
        }
        return null;
    }

    bool CompareDots()
    {
        int dotOneIndex = -1;
        int dotTwoIndex = -1;
        ConstellationDotProfile dotOne = goDotOne.GetComponent<ConstellationDot>().constellationDot;
        ConstellationDotProfile dotTwo = goDotTwo.GetComponent<ConstellationDot>().constellationDot;
        for (int i = 0; i < dotOne.connectedDots.Length; i++)
        {
            if (dotOne.connectedDots[i].constellationDot.name.Equals(dotTwo.name))
            {
                for (int j = 0; j < dotTwo.connectedDots.Length; j++)
                {

                    if (dotTwo.connectedDots[j].constellationDot.name.Equals(dotOne.name))
                    {
                        GameObject newLine = Instantiate(lineController);
                        newLine.GetComponent<LineController>().MakeLine(mousePositionOne, mousePositionTwo);
                        newLine.transform.SetParent(parent.transform);
                        dotOne.connectedDots[i].isConnected = true;
                        dotTwo.connectedDots[j].isConnected = true;
                        dotOne = null;
                        dotTwo = null;
                        return true;
                    }
                }
            }
        }
        dotOne = null;
        dotTwo = null;
        return false;
    }
    void Update()
    {
        // check for mouse or touch input
        if (Input.GetMouseButtonDown(0))
        {
            goDotOne = IsPointerOverUIElement(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            goDotTwo = IsPointerOverUIElement(false);
            if (goDotOne != null && goDotTwo != null)
            {
                if (CompareDots())
                {
                    CTDManager.instance.Verify();
                    Debug.LogError("TRUE");
                }
            }
        }

        // method to check if the player has connected all of the dots in the correct order
        // bool CheckIfDotsAreConnected()
        // {
        // check if the number of connected dots matches the total number of dots
        // if (connectedDots.Count != totalNumberOfDots)
        // {
        //     return false;
        // }

        // // check if the dots are connected in the correct order to form the constellation
        // for (int i = 0; i < totalNumberOfDots; i++)
        // {
        //     if (connectedDots[i] != expectedDotOrder[i])
        //     {
        //         return false;
        //     }
        // }

        // // if all checks pass, return true
        // return true;
        // }

    }
    // method to reset the game
    void ResetGame()
    {
        // clear the list of connected dots
        connectedDots.Clear();
    }
}
