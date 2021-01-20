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
}
