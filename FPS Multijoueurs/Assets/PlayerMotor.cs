using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private PlayerMotor motor;
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        
    }
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward *zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed; 
    }
}
