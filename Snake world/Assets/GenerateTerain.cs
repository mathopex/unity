using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerain : MonoBehaviour
{
    public Terrain terrain;
    public int height = 25; // hauteur maximal des montage du terrain
    public int size = 256; // taille du terrain en x et y
    
    void Start()
    {
        terrain.terrainData = GenTdata(terrain.terrainData);
    }


    public TerrainData GenTdata(TerrainData tData)
    {

        tData.heightmapResolution = size; // defini la resolution du terrain
        tData.size = new Vector3(size, height, size);

        float[,] h = new float[size, size]; // tableau pour la hauteur des montagnes

        // boucle de generation sur l'ensemble du terrain en x et y
        for (int i = 0;  i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                // gener une valeur de hauteur pour charque lieu du terrain
                h[i, j] = Mathf.PerlinNoise((float)i / size * 10, (float)j / size * 10);
            }
        }

        tData.SetHeights(0, 0, h);
        return tData;
    }

}
