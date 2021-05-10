using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class Noise 
{
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale)
    {

        // creation procedurale de la noiseMap(brui/neig) sur la hauteur(weight) et la largeur (width)
        float[,] noiseMap = new float[mapWidth, mapHeight];

        //empêche la division par 0 on clamp a 0.0001F
        if ( scale  <= 0)
        {
            scale = 0.0001f;
        }

        //recupère et stock toutes les coordonné dans le tableau noiseMap a 2 dimension (x/y)
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float sampleX = x / scale;
                float sampleY = y / scale;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                noiseMap[x, y] = perlinValue;
            }
        }

        return noiseMap;
    }
}
