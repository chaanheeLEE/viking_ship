using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
private float speed;
public float walkSpeed = 0.02f;
public float runSpeed = 0.06f;
public float rotationSpeed = 2.5f;
public LayerMask groundLayers;
public float jumpForce = 8f;
public CapsuleCollider col;
public bool isGrounded=true;
Rigidbody rigidBody;
Animator animator;
CapsuleCollider capsuleCollider;

public Transform cameraTransform;

private float yaw = 0;
private float pitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
       float moveVertical = Input.GetAxis("Vertical") * speed;
       float moveHorizontal = Input.GetAxis("Horizontal") * rotationSpeed;
       
       Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

       isGrounded = true;
       yaw += rotationSpeed * Input.GetAxis("Mouse X");
       pitch -= rotationSpeed * Input.GetAxis("Mouse Y");
       transform.eulerAngles = new Vector3(0, yaw, 0);
       cameraTransform.eulerAngles= new Vector3(pitch, yaw, 0);
      

       if(Input.GetButton("Fire1"))
       {
         if(Input.GetButton("Vertical"))
         {
           animator.SetBool("IsWalking",false);
           animator.SetBool("IsRunning",true);
           animator.SetBool("IsIdle",false);
         }
         else
         {
           animator.SetBool("IsWalking",false);
           animator.SetBool("IsRunning",false);
           animator.SetBool("IsIdle",true);
           animator.SetBool("IsJumping",false);
         }
         speed = runSpeed;    

       }
       else if (isGrounded && Input.GetButton("Jump"))
       {
            rigidBody.AddForce(Vector3.up * jumpForce);
            isGrounded=false;
            animator.SetBool("IsWalking",false);
            animator.SetBool("IsRunning",false);
            animator.SetBool("IsIdle",false);
            animator.SetBool("IsJumping",true);
         }
         
         else{
         if(Input.GetButton("Vertical")){
           animator.SetBool("IsWalking",true);
           animator.SetBool("IsRunning",false);
           animator.SetBool("IsIdle",false);
         }
         else
         {
           animator.SetBool("IsWalking",false);
           animator.SetBool("IsRunning",false);
           animator.SetBool("IsIdle",true);
           animator.SetBool("IsJumping",false);
         }
           speed = walkSpeed;
       }
 
    }
  
    void OnCollisionEnter(Collision other)
 {
     if (other.gameObject.tag == "Grounded")
     {
         isGrounded = true;
     }
 }
 
 void OnCollisionExit(Collision other)
 {
     if (other.gameObject.tag == "Grounded")
     {
         isGrounded = false;
     }
 }
}
