using UnityEngine;

public class CameraController : MonoBehaviour
{
    public  float speed = 0.1f;
    public Transform target;

    private float velocityX;
    private float velocityY;
    private float rotationXAxis;
    private float rotationYAxis;
    public float smoothness = 10;
    public float distance = 3;
    private float distanceLerp = 3;
    public float scrollFactor = 10;
    public float scrollSmoothness = 10;
    public float distanceMin = 3;
    public float distanceMax = 25;

    void Start()
    {
    }
    void Update()
    {

        if (Input.GetMouseButton(0))
            {
                velocityX += Input.GetAxis("Mouse X");
                velocityY += Input.GetAxis("Mouse Y");
            }

        rotationXAxis -= velocityY;
        rotationYAxis += velocityX;
        transform.rotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);

        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothness);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothness);

       
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            distanceLerp = distance - Input.GetAxis("Mouse ScrollWheel") * scrollFactor;
            distanceLerp = Mathf.Clamp(distanceLerp, distanceMin, distanceMax);
        }
        distance = Mathf.Lerp(distance, distanceLerp, Time.deltaTime * scrollSmoothness);


        transform.position = transform.rotation * new Vector3(0, 0 ,-distance);

        transform.position += target.position;
    }

}
