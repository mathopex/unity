using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class Noise 
{
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {

        // creation procedurale de la noiseMap(brui/neig) sur la hauteur(weight) et la largeur (width)
        float[,] noiseMap = new float[mapWidth, mapHeight];

        // prng = pseudo random number generator
        System.Random prng = new System.Random(seed);

        Vector2[] octaveOffsets = new Vector2[octaves];

        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-10000, 10000) + offset.x;
            float offsetY = prng.Next(-10000, 10000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        //empêche la division par 0 on clamp a 0.0001F
        if ( scale  <= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        //divise hauteur et largeur par 2
        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        //recupère et stock toutes les coordonné dans le tableau noiseMap a 2 dimension (x/y)
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {

                float amplitude = 1;
                float frequency = 1;
                float noisheight = 0;

                //genere autant de noisemap qu'il y a d'octave 
                for (int i = 0; i < octaves; i++)
                {
                    // generation a partire du millieu de l'ecran et plus du bord haut droit (x/y - halfWidht/height)
                    float sampleX = (x - halfWidth) / scale * frequency + octaveOffsets[i].x;
                    float sampleY = (y - halfHeight) / scale * frequency + octaveOffsets[i].y; 

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noisheight += perlinValue * amplitude;
                    amplitude *=  persistance;
                    frequency *= lacunarity;
                }

                // condition de normalisation des valeur de la noiseMap(0,1)
                 if( noisheight > maxNoiseHeight)
                {
                    maxNoiseHeight = noisheight;
                }
                 else if(noisheight < minNoiseHeight)
                {
                    minNoiseHeight = noisheight;
                }


                noiseMap[x, y] = noisheight;
                
            }
        }

        //on applique la normalisation a tout les pixels
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }

                return noiseMap;
    }
}
