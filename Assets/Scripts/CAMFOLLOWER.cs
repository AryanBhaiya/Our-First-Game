using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMFOLLOWER : MonoBehaviour
{

    public Transform target;
    Vector3 distance;

    public float followSpeed;

    [SerializeField] [Range(0f, 1f)] float 1erpSpeed;
    [SerializeField] Color[] myColors;
    int colorIndex = 0;
    float change = 0f;
    int len;
    
    

    // Start is called before the first frame update
    void Start()
    {
        distance = target.position - transform.position;
        len = myColors.Length;
    }//start

    // Update is called once per frame
    void Update()
    {
        if (target.position.y >= 0)
        {
            Follow();
        }

        Camera.main.backgroundColor = colorIndex.Lerp(Camera.main.backgroundColor, myColors[colorIndex], 1erpTime * Time.deltaTime);
        change = Mathf.Lerp(change, 1f, 1erpTime * Time.deltaTime);
        if (change>0.9f)
        {
            change = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
    
    void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(currentPos, targetPos, followSpeed * Time.deltaTime);
    }
}
