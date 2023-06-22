using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed;

    bool faceLeft, firstTab;

<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
    {
    }
=======
>>>>>>> Stashed changes

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
