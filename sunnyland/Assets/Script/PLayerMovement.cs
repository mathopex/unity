using UnityEngine;


public class PLayerMovement : MonoBehaviour
{

    //vbariable bool
  

    // a supprimé des le jeu terminé
    public bool isTeleportation = false;


    //variable float
    public float jumpForce;
    public float moveSpeed;
    private float horizontalMovement;
    public float groundCheckRadius = 0.2f;
    public bool isJumping;
    public bool isGrounded;


    //variable de classe
 
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;
    public LayerMask layerCollision;
    public Transform groundCheck;


    private Vector3 velocity = Vector3.zero;

        public static PLayerMovement instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de PlayerMovement dans cette scene");
            return;
        }
        instance = this;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //deplacement joueur avec les touches sur l'axe horizontal (fleche direction et/ou Q et D)
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed  * Time.fixedDeltaTime;
        // calcule de la vitesse de deplacement du joeur
        float characterVelocity = Mathf.Abs(rb.velocity.x);
   

        //animation de course
        animator.SetFloat("Run", characterVelocity);
        Flip(rb.velocity.x);

        //saut du joueur
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;

            //jump avec isgrounded

        }
        animator.SetBool("Ground", isGrounded);

        if (Input.GetKeyDown(KeyCode.S))
        {
          
            animator.SetBool("Input", true);
            moveSpeed = 0;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Input", false);
            moveSpeed = 350f;
        }
    }
    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, layerCollision);
        PlayerMove(horizontalMovement);

        
    }

    private void PlayerMove(float _horizontalMovement)
    {
        //deplacement horizontal
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        //on verrifie si le joueur saut
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void Flip( float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;

        }

        else if( _velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
