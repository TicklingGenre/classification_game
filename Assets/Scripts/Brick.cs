using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    //private SpriteRenderer _sprite;
    private TextMesh _label;

    public Material material;
    //public Color brickColor;
    public string brickName;
    public bool isPicked = false;
    public bool isDropped = false;
    public bool caught = false;

    
    public void Init()
    {
        //_sprite = GetComponent<SpriteRenderer>();
        _label = GetComponentInChildren<TextMesh>();
        //_sprite.color = brickColor;
        _label.text = brickName;
        //material.color = brickColor;
        GetComponent<MeshRenderer>().material = material;
    }

    private void Update()
    {
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
