using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemscripts : MonoBehaviour
{
    public GameObject starblast;

    public GameObject diamondblast;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 100f)*Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "star")
            {
                GameManager.instance.GetStar();
                Instantiate(starblast, transform.position, Quaternion.identity);
            }
            if (gameObject.tag == "diamond")
            {
                GameManager.instance.GetDiamond();
                Instantiate(diamondblast, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
