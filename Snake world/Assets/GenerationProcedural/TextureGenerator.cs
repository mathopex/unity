using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator
{
    // genère la texture en couleur
    public static Texture2D TextureFromColourMap( Color[] colourMap, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        //evite le flou entre deux couleur
        texture.filterMode = FilterMode.Point;
        // evite le decoupage de la carte au niveau des bord
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colourMap);
        texture.Apply();
        return texture;
    }

    //genère le textute en noir et blanc(Noise)
    public static Texture2D TextureFromHeightMap(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);//longueur de la map
        int height = heightMap.GetLength(1); // hauteur de la map

   

        //creation de l'array 1 dimention pour le stock des couleurs 
        Color[] colourMap = new Color[width * height];

        //on stock toute les nuances de gris/blanc/noir et on les stock dans l'array colorMap
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // recupère la nuance pour chaque pixel entre le noir et le blanc grace au Lerp 
                colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }
        return TextureFromColourMap(colourMap, width, height);
    }
}
