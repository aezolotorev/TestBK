using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAroundLocal(new Vector3(0, 1, 0), speed);
    }
}
