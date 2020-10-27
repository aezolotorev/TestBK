using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    private float speed=4f;
    public Transform left;
    public Transform right;
    Vector3 move;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3( speed * Time.deltaTime, 0,0);
        transform.Translate(move.x, 0, 0);
        if (transform.localPosition.x <= left.localPosition.x)
        {
            speed = -speed;

        }
        if (transform.localPosition.x >= right.localPosition.x)
        {
            speed = -speed;

        }
    }
}
