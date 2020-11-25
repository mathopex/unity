using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController characterController;
    public float moveSpeed;
    public float jumpForce;
    private float gravity = 9.81f;
    private Vector3 v3;
    public Animator anim;
    private bool IsWalking = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        
        v3 = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, v3.y, Input.GetAxis("Vertical") * moveSpeed);

        if(v3.x != 0 || v3.z != 0)
        {
            IsWalking = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(v3.x, 0, v3.z)), 0.15f);
        }
        else
        {
            IsWalking = false;
        }
        characterController.Move(v3 * Time.deltaTime);

        v3.y -= gravity * Time.deltaTime;

        if (characterController.isGrounded && v3.y < 0.0f)
        {
            v3.y = -9.81f;
        }

        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            v3.y = jumpForce;
        }

        anim.SetBool("IsWalking", IsWalking);
    }
}
