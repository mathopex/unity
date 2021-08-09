﻿
using UnityEngine;


public class PlayerMouvement : MonoBehaviour
{
    public float moveSpeed = 1000f;
    public bool isJumping;
    public int jumpForce = 330;
    public bool isGrounded;
    public float groundCheckRadius = 0.2f;
    private float horizontalMouvement;

    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private SpriteRenderer spriteRenderer;
    public Transform groundCheck;
    public LayerMask collisionLayer;
    private Animator animator;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
       
    }

    private void Update()
    {
        //deplacement joueur avec les touches sur l'axe horizontal (fleche direction et/ou Q et D)
        horizontalMouvement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        // on verifie si le joueur presse la bar espace pour le saut et que isGrounded touche bien le sol (pour eviter le double saut)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            

        }

        float characterVelocity = Mathf.Abs(rb.velocity.x);

        Flip(rb.velocity.x);

        animator.SetFloat("Velocity", characterVelocity);
        animator.SetBool("Jumping", isGrounded);





    }

    private void FixedUpdate()
    {

        //IsGrouded permet de verifier si le joueur touche bien le sol ou non 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);

        PlayerMove(horizontalMouvement);
    }

    void PlayerMove(float _horizontalMouvement)
    {
        //deplacement horizontal
        Vector3 targetVelocity = new Vector2(_horizontalMouvement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        if (isJumping)
        {
            // saut du joueur
            rb.AddForce(new Vector2(0f, jumpForce));
            
            isJumping = false;
           
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void Flip(float _velocity)
    {
        if( _velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if ( _velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

   
}