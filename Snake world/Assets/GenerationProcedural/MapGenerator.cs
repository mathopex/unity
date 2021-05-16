using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode { noiseMap, ColourMap , Mesh}
    public DrawMode drawMode;
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public bool autoUpdate;

    public int octaves;
    [Range(0,1)]
    public float persistence;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public float meshHeightMultiplier;

    public TerrainType[] region;

    //genere la map procedural
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistence, lacunarity, offset);

        //array color pour stocker les differentes couleur de la map
        Color[] colourMap = new Color[mapWidth * mapHeight];

        //boucle qui parcour tous les pixels de la noisMap
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                // on recupère la hauteur de chaque pixel dans currentHeight
                float currentHeight = noiseMap[x, y];

                //boucle de comparaison de hauteur
                for (int i = 0; i < region.Length; i++)
                {
                    // si currentheight et plus petit ou egale a region.height on applique la couleur definir dans l'inpector
                    if( currentHeight <= region[i].height)
                    {
                        //assigne la bonne couleur
                        colourMap[y * mapWidth + x] = region[i].colour;
                        break;
                    }
                            
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();

        if(drawMode == DrawMode.noiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap)); 
        }
        else if (drawMode == DrawMode.ColourMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
        }
        else if ( drawMode == DrawMode.Mesh)
        {
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier), TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
        }
        
    }

    // fonction appeler quand le scrip est modifier
    private void OnValidate()
    {

        //empeche les valeur d'aller en dessous de 1
        if(mapWidth < 10)
        {
            mapWidth = 10;
        }

        if (mapHeight < 10)
        {
            mapHeight = 10;
        }

        if(lacunarity < 1)
        {
            lacunarity = 1;
        }

        if ( octaves < 0)
        {
            octaves = 0;
        }
    }

    [System.Serializable]
    //fonction pour les type de terrain, non, couleur , hauteur(ou on les retrouve) etc ...
    public struct TerrainType
    {
        public string name;
        public float height;
        public Color colour;
    }


}
