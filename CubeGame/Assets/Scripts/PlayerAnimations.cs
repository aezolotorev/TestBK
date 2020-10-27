using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    PlayerProperties playerProp;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (playerProp.isMoving)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Fly", false);
        }
        if (playerProp.isJump)
        {
            anim.SetTrigger("Jump");
            
        }
        if (playerProp.isFlying)
        {
            anim.SetBool("Fly", true);

        }
        if(!playerProp.isFlying)
            anim.SetBool("Fly", false);
        if (!playerProp.isAlive)
        {
            anim.SetTrigger("Death");
        }
    }
}
