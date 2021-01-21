using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private TextMesh _label;

    public Material material;
    public string brickName;
    public bool isPicked = false;
    public bool isDropped = false;
    public bool caught = false;

    
    public void Init()
    {
        _label = GetComponentInChildren<TextMesh>();
        _label.text = brickName;
        GetComponent<MeshRenderer>().material = material;
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Bin" && isDropped)
        {
            caught = true;
            DestroyBrick();
            other.gameObject.GetComponent<Bin>().CheckBrick(brickName);
        }
    }

    void DestroyBrick()
    {
        InputManager.pickedBrick = null;
        Destroy(this.gameObject);
    }
}
