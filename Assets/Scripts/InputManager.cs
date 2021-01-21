using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public static GameObject pickedBrick;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.tag == "Brick")
                {
                    pickedBrick = hit.collider.gameObject;
                }
            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            MoveBrick(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            DropBrick();
        }
        
    }

    void PickBrick()
    {
        if(pickedBrick != null)
        {
            pickedBrick.GetComponent<Brick>().isPicked = true;
            pickedBrick.GetComponent<Brick>().isDropped = false;
            pickedBrick.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    void DropBrick()
    {
        if (pickedBrick != null)
        {
            pickedBrick.GetComponent<Brick>().isPicked = false;
            pickedBrick.GetComponent<Brick>().isDropped = true;
            pickedBrick.GetComponent<Rigidbody>().isKinematic = false;
            pickedBrick = null;
        }
    }
    void MoveBrick(Vector3 mousePos)
    {
        if (pickedBrick != null)
        {
            Vector3 objPos = new Vector3(mousePos.x, mousePos.y, pickedBrick.transform.position.z);
            pickedBrick.transform.position = objPos;
        }
    }
}
