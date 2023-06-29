using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caranimation : MonoBehaviour
{
    [SerializeField] Vector3 finalPosition;
    Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition, 0.2f);
        transform.Rotate(new Vector3(0f, 10f, 0) * Time.deltaTime);
    }

    private void OnDisable( )
    {
        transform.position = initialPosition;
        transform.rotation = Quaternion.Euler(0f,90f,0f);
    }
}
