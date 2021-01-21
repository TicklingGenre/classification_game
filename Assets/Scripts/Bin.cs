using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public char binColorTag;

    private GameObject _caughtBrick;
    public void CheckBrick(string brickName)
    {
        if(brickName[0] == binColorTag)
        {
            Debug.Log("Correct Brick");
            GameManager.AddPoints(true);
            GameManager.correctBricks.Add(brickName);
        }
        else
        {
            Debug.Log("Incorrect Brick");
            GameManager.AddPoints(false);
            GameManager.incorrectBricks.Add(brickName);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Brick")
        {
            if (other.gameObject.GetComponent<Brick>().caught)
            {
                _caughtBrick = other.gameObject;
                DumpBrick(_caughtBrick);
            }
        }
    }

    void DumpBrick(GameObject brick)
    {
        string brickName = brick.GetComponent<Brick>().brickName;
        CheckBrick(brickName);
    }
}
