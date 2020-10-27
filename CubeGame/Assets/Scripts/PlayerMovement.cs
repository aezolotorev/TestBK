using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _charController;
    public PlayerProperties playerProp;
    Vector3 moveVec;
    [SerializeField]
    float startspeed;
    [SerializeField]
    float plusspeed;
    [SerializeField]
    float speed;
    [SerializeField]
    float sensivity;
    [SerializeField]
    float jumpSpeed;
    Vector3 gravity;
    [SerializeField]
    GameManager GM;  
   
  
    void Start()
    {
        speed =  playerProp.startspeed;
        jumpSpeed = playerProp.jumpspeed;
        sensivity = playerProp.turnspeed;
        _charController = GetComponent<CharacterController>();
        gravity = Vector3.zero;
        playerProp.isMoving = true;
        playerProp.isFlying = false;
        playerProp.isAlive = true;
        playerProp.inJumpPlatform = false;
      
    }

    
    void Update()
    {
        StartCoroutine(UpSpeed());
        if (playerProp.isAlive)
        {
            Move();
        }
        
    }


   
    private void Move()
    {
        if (_charController.isGrounded)
        {
            gravity = Vector3.zero;
            playerProp.isFlying = false;
            if (Input.GetAxisRaw("Vertical") > 0 || playerProp.inJumpPlatform)
            {
                gravity.y = jumpSpeed;
                playerProp.isJump = true;
                playerProp.isMoving = false;
            }            
        }

        else
        {
            gravity += Physics.gravity * Time.deltaTime * 2;
            playerProp.isJump = false;
            playerProp.isFlying = false;
            if (_charController.velocity.y < 0)
            {
                playerProp.isFlying = true;
            }
        }




        float inputZ = Input.GetAxisRaw("Horizontal")*sensivity;
        
        moveVec = new Vector3(inputZ, 0, speed);
        moveVec += gravity;
        moveVec *= Time.deltaTime;
        moveVec = transform.TransformDirection(moveVec);
        _charController.Move(moveVec);
    }

    void Speed(float number)
    {
        speed += number;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)

    {
           
        if (hit.gameObject.CompareTag("JumpPlatform"))
        {
            playerProp.inJumpPlatform = true;
            StartCoroutine(JumpPlatform());
        }
    
        if (hit.gameObject.CompareTag("DeathPlane"))
        {
            playerProp.isAlive = false;
            GM.GameOver();
        }
        
        if (!hit.gameObject.CompareTag("Saw"))
            return;
     
        StartCoroutine(Death());
    }

    IEnumerator JumpPlatform()
    {
        yield return new WaitForSeconds(0.1f);
        playerProp.inJumpPlatform = false;
    }

    IEnumerator Death()
    {
        playerProp.isAlive = false;
        yield return new WaitForSeconds(2);
        GM.GameOver();
    }

    void SpeedUp()
    {
          speed += 0.001f*Time.deltaTime;
    }

    IEnumerator UpSpeed()
    {

        yield return new WaitForFixedUpdate();
        SpeedUp();
    }
}
