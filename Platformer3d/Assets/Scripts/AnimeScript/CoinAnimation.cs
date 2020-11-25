using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    public Vector3 dir;
    
    // Update is called once per frame
    void Update()
    {
        dir.z = 150f;
        transform.Rotate(dir * Time.deltaTime);
    }
}
