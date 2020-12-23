
using UnityEngine;


public class KnightScript : MonoBehaviour
{
    //vbariable bool
    public bool isJumping;
    private bool isGrounded;
    private bool inJump;
   public    bool onAttack;

    // a supprimé des le jeu terminé
    public bool isTeleportation = false;


    //variable float
    public float jumpForce;
    public float moveSpeed;
    private float horizontalMovement;
    public float groundCheckRadius;


    //variable de classe
    public Transform groundCheck;
    public LayerMask collisionLayer;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;

    private Vector3 velocity = Vector3.zero;

    [SerializeField] AudioClip sndAttack, sndJump, sndHurt, sndDead, sndWin, sndGobelin;
   private  AudioSource audioS;


    public static KnightScript instance;
    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
        playerCollider = GetComponent <BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de KnightScript dans cette scene");
            return;
        }

        instance = this;
    }

    void Update()

    {
        //deplacement joueur avec les touches sur l'axe horizontal (fleche direction et/ou Q et D)
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;


        // on verifie si le joueur presse la bar espace pour le saut et que isGrounded touche bien le sol (pour eviter le double saut)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            audioS.PlayOneShot(sndJump);
        }

        animator.SetBool("IsGrounded", isGrounded);

        //mouvement gauche/droite
        Flip(rb.velocity.x);

        // calcule de la vitesse de deplacement du joeur
        float characterVelocity = Mathf.Abs(rb.velocity.x);

        //animation de course
        animator.SetFloat("Speed", characterVelocity);

        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded && !onAttack)
        {
                onAttack = true;
                animator.SetTrigger("Attack");
                audioS.PlayOneShot(sndAttack);
        }

    }
    private void FixedUpdate()
    {
        //IsGrouded permet de verifier si le joueur touche bien le sol ou non 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);

        PlayerMove(horizontalMovement);
    }

    void PlayerMove(float _horizontalMovement)
    {

        // on verifie sur le joueur est en train de grimper ou non pour activer/desactiver le deplacement horizontal du joueur

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
    void Flip(float _velocity)
    {
        // si la velocité et supperrieure a 0.1 on desactive le demi-tour  gauche sur l'axe y (positive)
        if (_velocity > 0.1f)
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Gobelin"))
        {
            if (onAttack)
            {
                Rigidbody2D rbGobelin = collision.gameObject.GetComponent<Rigidbody2D>();
                rbGobelin.bodyType = RigidbodyType2D.Dynamic;
                rbGobelin.AddForce(Vector2.up * 6000); 
                audioS.PlayOneShot(sndGobelin);
                Destroy(collision.gameObject.transform.parent.gameObject, 0.7f);
            }
            else
            {
                Vector2 move = collision.transform.position - transform.position;
                rb.AddForce(move * -300);
                Hurt();
            }
        }
    }

    public void Hurt()
    {
        animator.SetTrigger("Hurt");
        audioS.PlayOneShot(sndHurt);
    }

    public void Win()
    {
        animator.SetTrigger("Win");
        audioS.PlayOneShot(sndWin);
    }

    public void Dead()
    {
        animator.SetTrigger("Dead");
        audioS.PlayOneShot(sndDead);
    }
    public void AttackBool()
    {
        onAttack = false;
    }
}
