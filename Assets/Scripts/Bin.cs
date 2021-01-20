using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public char binColorTag;

    private GameObject _catchObject;
    private bool dumpable = false;
    private bool caught = false;

    private void OnTriggerEnter(Collider other)
    {
        _catchObject = other.gameObject;
        if(_catchObject.tag == "Brick" && _catchObject.GetComponent<Brick>().isPicked)
        {
            dumpable = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (dumpable)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Dump();
            }
        }
    }

    void Dump()
    {
        caught = true;
    }

    IEnumerator Catch()
    {
        Vector3 newPos = new Vector3(transform.position.x, _catchObject.transform.position.y, _catchObject.transform.position.z - 1f);
        _catchObject.transform.Translate(newPos);
        yield return new WaitForSeconds(0.1f);
    }

    private void Update()
    {
        if (caught)
        {
            StartCoroutine("Catch");
            Destroy(_catchObject);
        }
            
    }
}
