
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;
    void Start()
    {
        offSet = target.position - transform.position;

    }

    
    void Update()
    {
        transform.position = target.position - offSet;


    }
}
