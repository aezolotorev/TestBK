using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    Vector3 startDistance, moveVec;
    void Start()
    {
        startDistance = transform.position - Target.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {           
        moveVec = Target.position + startDistance;
        moveVec.y = startDistance.y;        
        transform.position = moveVec;
    }
}
