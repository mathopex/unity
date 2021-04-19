
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{

    // variable de deplacement
    public float speed = 6.0f;
    public float rotateSpeed = 90.0f;
    public float gravity = 20.0f;
    public float walkSpeed = 1f;
    public float rotation = 1f;

    private Vector3 moveDirection = Vector3.zero; // dir du mouvement
    public bool isGrounded = false; // le personnage est-il au sol ?

    //Les Composants
    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        //on recupère le caharctèreController du personnage 
        controller = GetComponent<CharacterController>();
        // on recupère l'animator du personnage
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        DeplacementHero();
        BaseMouvement();

    }

    public void BaseMouvement()
    {
        if (isGrounded)// si on est au sol
        {
            animator.SetFloat("walkSpeed", controller.velocity.magnitude);
            //calcule du vecteur direction du mouvement
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            
        }

        // on applique la gravité
        moveDirection.y -= gravity * Time.deltaTime;

        Physics.SyncTransforms();
        //on applique le mouvement
        var flags = controller.Move(moveDirection * Time.deltaTime);
        //Gestion de la rotation
       
        //Gestion collision avec le sol
        isGrounded = CollisionFlags.CollidedBelow != 0;



    }

    public void DeplacementHero()
    {

         if (Input.GetKey(KeyCode.D))
         {

            transform.rotation *= Quaternion.Euler(0, rotation, 0);
         }

         else if (Input.GetKey(KeyCode.Q))
         {
            transform.rotation *= Quaternion.Euler(0,-rotation , 0);    
         }
        
   
    }   
}

