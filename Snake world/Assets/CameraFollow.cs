using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetFollow;
    public float speed = .1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Quaternion rot = Quaternion.LookRotation(targetFollow.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, speed);
    } 

}
