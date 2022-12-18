using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public List<Vector3> points = new List<Vector3>();
    public Transform lastPoint;

    public int lineWidth;
    void Awake(){
        lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
    }

    public void MakeLine(Vector3 startPoint,Vector3 finalPoint){
        // if(lastPoint == null){
        //     lastPoint = finalPoint;
        // }else{
            points.Add(startPoint);
            points.Add(finalPoint);
            lineRenderer.enabled = true;
            SetupLine();
        // }
    }

    void SetupLine(){
        int pointLength = points.Count;
        lineRenderer.positionCount = pointLength;
        for (int i = 0; i < pointLength; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(points[i].x, points[i].y, 0));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
