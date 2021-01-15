using UnityEngine;

public class CreateGrid : MonoBehaviour
{

    public GameObject cellPrefab;
    public int grideSize = 0;

    void Start()
    {
        //double boucle pour les lignes (i) et les colones(j)
        for( int i = 0; i  < grideSize; i++)
        {
            for (int j = 0; j < grideSize; j++)
            {
                //construction de la grille
                GameObject go = Instantiate(cellPrefab, new Vector3(i, 0, j), Quaternion.Euler(90, 0, 0));
                go.transform.parent = transform;
                go.name = i + "-" + j;
            }
        }
        
    }
}
