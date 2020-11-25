using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovePlayer : MonoBehaviour
{
    //vbariable bool
    private  bool isJumping;
    private bool isGrounded;
    [HideInInspector]
    public bool isClimbing;

    // a supprimé des le jeu terminé
    public bool isTeleportation = false;


    //variable float
    [HideInInspector]
    public float jumpForce = 330;
    [HideInInspector]
    public float moveSpeed = 150;
    [HideInInspector]
    private float climbSpeed = 125;
    private float horizontalMovement;
    private float verticalMovement; 
    private float groundCheckRadius = 0.2f;


    //variable de classe
    public Transform groundCheck;
    public LayerMask collisionLayer;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public CapsuleCollider2D playerCollider;
    public AudioClip jumpSound;

    private Vector3 velocity = Vector3.zero;


    public static MovePlayer instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de MovePplayer dans cette scene");
            return;
        }

        instance = this;
    }

    void Update()

    { 
        
        //deplacement joueur avec les touches sur l'axe horizontal (fleche direction et/ou Q et D)
         horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        //deplacement joueur avec touches sur l'axe vertical (fleche direction et/ou Z et S)
         verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;

        // on verifie si le joueur presse la bar espace pour le saut et que isGrounded touche bien le sol (pour eviter le double saut)
        if (Input.GetButtonDown("Jump") && isGrounded && !isClimbing)
        {
            AudioManager.instance.PlayClipAt(jumpSound, transform.position);
            isJumping = true;
        }
        
            //mouvement gauche/droite
            Flip(rb.velocity.x);

        // calcule de ma vitesse de deplacement du joeur
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        //animation de course
        animator.SetFloat("Speed",characterVelocity);
        // animation de grimper
        animator.SetBool("isClimbing", isClimbing);

        // a supprimé le jeu sortie
        if (Input.GetKeyDown(KeyCode.T) && isTeleportation)
        {
            Teleport();
        }

    }
    private void FixedUpdate()
    {
       
        
            //IsGrouded permet de verifier si le joueur touche bien le sol ou non 
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);
       

        PlayerMove(horizontalMovement , verticalMovement);
    }

 

    void PlayerMove(float _horizontalMovement, float _verticalMovement)
    {

        // on verifie sur le joueur est en train de grimper ou non pour activer/desactiver le deplacement horizontal du joueur
        if (!isClimbing)
        {
            //deplacement horizontal
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

            //verifi si le joueur et entrain de sauté ou non
            if (isJumping)
            {
                // saut du joueur
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        //active/desactive le deplacement vertical
        else
        {
            //deplacement vertical
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        }

       
    }

    void Flip(float _velocity)
    {
        // si la velocité et supperrieure a 0.1 on desactive le demi-tour  gauche sur l'axe y (positive)
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;

        } 
        // si le velocité et inferieur a -0.1 on active le demi-tour gauche sur l'axe y(negative)
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    // a supprimé des le jeu terminé
    public void Teleport()
    {

        transform.position = GameObject.FindGameObjectWithTag("Teleportation").transform.position;
    }
}
 