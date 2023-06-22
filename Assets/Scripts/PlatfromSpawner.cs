using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform lastPlatform;
    Vector3 lasPos;
    Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        lasPos = lastPlatform.position;
        GenratePos();
    }//start

    // Update is called once per frame
    void Update()
    {
        
    }//update

    void GenratePos()
    {
        newPos = lasPos;
        newPos.z += 2f;
        Instantiate(platform, newPos, Quaternion.identity);
    }
}
