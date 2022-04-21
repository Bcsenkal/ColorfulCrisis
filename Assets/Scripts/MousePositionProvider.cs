using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionProvider : MonoBehaviour
{
    private Camera cam;
    public Vector3 mousePos;
    public Vector3 pointToLook;
    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        UpdateMousePosition();
    }
    void UpdateMousePosition()
    {
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
        float rayLength;
        if(groundPlane.Raycast(cameraRay,out rayLength))
        {
            pointToLook = cameraRay.GetPoint(rayLength);
        }
    }
    
        
}
