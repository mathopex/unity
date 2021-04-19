using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{

    public float moveSpeed = 0.3f;
    public float rotationSpeed = 8f;

    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * moveSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * rotationSpeed);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -rotationSpeed);
        }
    }
}
