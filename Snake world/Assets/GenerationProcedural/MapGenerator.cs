using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode { noiseMap, ColourMap , Mesh}
    public DrawMode drawMode;

    public const int mapChunkSize = 241; // taille max de la map
    [Range(0,6)]
    public int levelOfdetail;
    public float noiseScale;

    public bool autoUpdate;

    public int octaves;
    [Range(0,1)]
    public float persistence;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public float meshHeightMultiplier;
    public AnimationCurve meshHeightCurve;

    public TerrainType[] region;

    Queue<MapThreadInfo<MapData>> mapDataThreadInfoQueue = new Queue<MapThreadInfo<MapData>>();
    Queue<MapThreadInfo<MeshData>> meshDataThreadInfoQueue = new Queue<MapThreadInfo<MeshData>>();


    public void DrawMapInEditor()
    {
        MapData mapData = GenerateMapData();

        MapDisplay display = FindObjectOfType<MapDisplay>();

        if (drawMode == DrawMode.noiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(mapData.heightMap));
        }
        else if (drawMode == DrawMode.ColourMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(mapData.colourMap, mapChunkSize, mapChunkSize));
        }
        else if (drawMode == DrawMode.Mesh)
        {
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(mapData.heightMap, meshHeightMultiplier, meshHeightCurve, levelOfdetail), TextureGenerator.TextureFromColourMap(mapData.colourMap, mapChunkSize, mapChunkSize));
        }
    }

    public void RequestMapData(Action<MapData> callBack)
    {
        ThreadStart threadStart = delegate
        {
            MapDataThread(callBack);
        };

        new Thread(threadStart).Start();
    }

     void MapDataThread(Action<MapData> callBack)
    {
        MapData mapData = GenerateMapData();
        lock (mapDataThreadInfoQueue)
        {
            mapDataThreadInfoQueue.Enqueue(new MapThreadInfo<MapData>(callBack, mapData));
            
        }

    }

    public void ResquestMeshData (MapData mapData, Action<MeshData> callBack)
    {

        ThreadStart threadStart = delegate
        {
            MeshDataThread(mapData, callBack);
        };

        new Thread(threadStart).Start();
    }

    public void MeshDataThread(MapData mapData, Action<MeshData> callBack)
    {
        MeshData meshData = MeshGenerator.GenerateTerrainMesh(mapData.heightMap, meshHeightMultiplier, meshHeightCurve, levelOfdetail);
        lock (meshDataThreadInfoQueue)
        {
            meshDataThreadInfoQueue.Enqueue(new MapThreadInfo<MeshData>(callBack, meshData));

        }
    }

    private void Update()
    {
        if(mapDataThreadInfoQueue.Count > 0)
        {
            for (int i = 0; i < mapDataThreadInfoQueue.Count; i++)
            {
                MapThreadInfo<MapData> threadInfo = mapDataThreadInfoQueue.Dequeue();
                threadInfo.callback(threadInfo.parameter);
            }
        }

        if (meshDataThreadInfoQueue.Count > 0)
        {
            for (int i = 0; i < meshDataThreadInfoQueue.Count; i++)
            {
                MapThreadInfo<MeshData> threadInfo = meshDataThreadInfoQueue.Dequeue();
                threadInfo.callback(threadInfo.parameter);
            }
        }
    }


    //genere les donné de la map
    MapData GenerateMapData()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapChunkSize, mapChunkSize, seed, noiseScale, octaves, persistence, lacunarity, offset);

        //array color pour stocker les differentes couleur de la map
        Color[] colourMap = new Color[mapChunkSize * mapChunkSize];

        //boucle qui parcour tous les pixels de la noisMap
        for (int y = 0; y < mapChunkSize; y++)
        {
            for (int x = 0; x < mapChunkSize; x++)
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
                        colourMap[y * mapChunkSize + x] = region[i].colour;
                        break;
                    }
                            
                }
            }
        }

        return new MapData(noiseMap, colourMap);
    }

    // fonction appeler quand le scrip est modifier
    private void OnValidate()
    {

        //empeche les valeur d'aller en dessous de 1
        if(lacunarity < 1)
        {
            lacunarity = 1;
        }

        if ( octaves < 0)
        {
            octaves = 0;
        }
    }

    struct MapThreadInfo<T>
    {
        public readonly Action<T> callback;
        public readonly T parameter;

        public MapThreadInfo( Action<T> callback, T parameter)
        {
            this.callback = callback;
            this.parameter = parameter;
        }
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

public struct MapData
{
    public readonly float[,] heightMap;
    public readonly Color[] colourMap;

    public MapData(float[,] heightMap, Color[] colourMap)
    {
        this.heightMap = heightMap;
        this.colourMap = colourMap;
    }

}
