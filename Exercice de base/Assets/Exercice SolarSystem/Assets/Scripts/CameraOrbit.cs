using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour {

    public Transform target;
    private float velocityX;
    private float velocityY;
    private float rotationXAxis;
    private float rotationYAxis;
    public float smoothness = 10;
    public float distance = 10;
    private float distanceLerp;
    public float scrollFactor = 10;
    public float scrollSmoothness = 10;
    public float distanceMin = 1;
    public float distanceMax = 25;

    void Start () {
        distanceLerp = distance;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            velocityX += Input.GetAxis("Mouse X");
            velocityY += Input.GetAxis("Mouse Y");
        }
        //print("velocityX " + velocityX);
        //print("velocityY " + velocityY);
        rotationXAxis -= velocityY;
        rotationYAxis += velocityX;
        transform.rotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);

        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothness);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothness);
        
        if( Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            distanceLerp = distance - Input.GetAxis("Mouse ScrollWheel") * scrollFactor;
            distanceLerp = Mathf.Clamp(distanceLerp, distanceMin, distanceMax);
        }
        distance = Mathf.Lerp( distance, 
            distanceLerp, 
            Time.deltaTime * scrollSmoothness);
        transform.position = transform.rotation * new Vector3(0, 0, -distance);
        transform.position += target.position;
    }
}
