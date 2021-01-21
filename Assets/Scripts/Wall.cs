using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool leftWall = false;


    private void Start()
    {
        Vector3 wallPos;
        if (leftWall)
        {
            float leftCameraPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x;
            wallPos = new Vector3(leftCameraPoint - (transform.localScale.x / 2 + 0.1f), transform.position.y, transform.position.z);
        }
        else
        {
            float rightCameraPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, Camera.main.nearClipPlane)).x;
            wallPos = new Vector3(rightCameraPoint + (transform.localScale.x / 2 + 0.1f), transform.position.y, transform.position.z);
        }
        transform.position = wallPos;
    }
}
