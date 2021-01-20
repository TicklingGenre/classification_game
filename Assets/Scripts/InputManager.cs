using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    private GameObject _pickedBrick;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.tag == "Brick")
                {
                    _pickedBrick = hit.collider.gameObject;
                    _pickedBrick.GetComponent<Brick>().isPicked = true;
                    MoveBrick(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    //StartCoroutine("MoveBrick", Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if(_pickedBrick != null)
            {
                _pickedBrick.GetComponent<Brick>().isPicked = false;
                _pickedBrick = null;
            }
        }
        
    }

    void MoveBrick(Vector3 mousePos)
    {

        Vector3 objPos = new Vector3(mousePos.x, mousePos.y, _pickedBrick.transform.position.z);
        _pickedBrick.transform.position = objPos;
        //yield return new WaitForSeconds(0.1f);
    }
}
