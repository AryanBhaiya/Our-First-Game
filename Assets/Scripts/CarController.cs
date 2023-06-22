using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed;
    bool faceLeft, firstTab;


 // Update is called once per frame

    void Update()
    {
        Move();
        CheckInput();
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    
    void CheckInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeDir()


    void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDir();

        }
    }

    void ChangeDir()
    {

            if(faceLeft)
            {
                faceleft = false;
                transform.rotation = Quaternion.Evler(0, 90, 0);
            }
            else
            {
                faceLeft = true;
                transform.rotation = Quaternion.Evler(0, 0, 0);
            }
    }

        if (faceLeft)
        {
            faceLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            faceLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

}