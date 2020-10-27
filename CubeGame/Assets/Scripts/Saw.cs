using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public Transform left;
    public Transform right;
    Vector3 move;
    void Start()
    {
        
    }

    
    void Update()
    {
        move = new Vector3(0, speed * Time.deltaTime, 0);
        transform.Translate(0, move.y, 0);
        if (transform.localPosition.z <= left.localPosition.z)
        {
            speed = -speed;
            
        }
        if (transform.localPosition.z >= right.localPosition.z)
        {
            speed = -speed;
           
        }
        transform.Rotate(new Vector3(0,1,0), 15f);

    }
}
