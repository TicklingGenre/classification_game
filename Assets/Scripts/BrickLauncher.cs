using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLauncher : MonoSingleton<BrickLauncher>
{
    public GameObject brick;
    public float spawnTimeInSecs = 1f;
    public float brickForce = 5f;
    public Color brickRed;
    public Color brickGreen;
    public Color brickBlue;
    public Transform launchPosition;
    public Material[] materials;

    private float _timeStep;
    private int _red;
    private int _blue;
    private int _green;


    // Start is called before the first frame update
    void Start()
    {
        _timeStep = spawnTimeInSecs;
        _red = 0;
        _green = 0;
        _blue = 0;
        brickRed = (brickRed == null) ? Color.red : brickRed;
        brickBlue = (brickBlue == null) ? Color.blue : brickBlue;
        brickGreen = (brickGreen == null) ? Color.green : brickGreen;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time - _timeStep >= spawnTimeInSecs)
        {
            LaunchBrick();
            _timeStep = Time.time;
        }
    }

    void LaunchBrick()
    {
        int ranadomColor = Random.Range(0, 3);
        string n = "";
        Material material = materials[0];
        Color c = Color.white;
        switch (ranadomColor)
        {
            //RED CASE
            case 0:
                n = "R" + (++_red).ToString();
                c = brickRed;
                material = materials[0];
                break;
            //GREEN CASE
            case 1:
                n = "G" + (++_green).ToString();
                c = brickGreen;
                material = materials[1];
                break;
            //BLUE CASE
            case 2:
                n = "B" + (++_blue).ToString();
                c = brickBlue;
                material = materials[2];
                break;
        }
        InstantiateBrick(n, c, material);
    }

    void InstantiateBrick(string name, Color color, Material material)
    {
        GameObject b = GameObject.Instantiate(brick);   //, launchPosition);
        b.transform.position = launchPosition.transform.position;
        Brick br = b.GetComponent<Brick>();
        br.brickName = name;
        //br.brickColor = color;
        br.material = material;
        br.Init();

        Transform t = b.GetComponent<Transform>();
        //t.eulerAngles = new Vector3(t.eulerAngles.x, t.eulerAngles.y, Random.Range(0, 180));
        Vector3 force = new Vector3(Random.Range(-1f, 1f), 1f, 0f);
        b.GetComponent<Rigidbody>().AddForce(force * brickForce);
    }
}
