
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Vector3 respawn;

    public static Respawner instance;
    void Start()
    {

        if(instance != null)
        {
            Debug.LogWarning("il y a plsu d'une instance de Respawner dans le lvl");
            return;
        }

        instance = this;
        respawn = transform.position;
    }


}
