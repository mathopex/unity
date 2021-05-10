using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRenderer;

    // on applique le perlinNoise sur le plane 
    public void drawNoiseMaps( float[,] noiseMap)
    {
        int width = noiseMap.GetLength(0);//longueur de la map
        int height = noiseMap.GetLength(1); // hauteur de la map

        // creation de la nouvelle texture avec les valeur largeur et hauteur qu'on recupère du tableau noiseMap
        Texture2D texture = new Texture2D(width, height);

        //creation de l'array 1 dimention pour le stock des couleurs 
        Color[] colorMap = new Color[width * height];

        //on stock toute les nuances de gris/blanc/noir et on les stock dans l'array colorMap
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // recupère la nuance pour chaque pixel entre le noir et le blanc grace au Lerp 
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
            }
        }

        // on applique la couleur a tous les pixel en 1 seul foi 
        texture.SetPixels(colorMap);
        texture.Apply();

        // on applique la texture directement dans la scene et non au runTime
        textureRenderer.sharedMaterial.mainTexture = texture;

        //redimention du scale du plane  height(y) = z en 3D
        textureRenderer.transform.localScale = new Vector3(width, 1, height);

    }

}
