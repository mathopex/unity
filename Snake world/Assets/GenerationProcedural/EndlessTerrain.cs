using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTerrain : MonoBehaviour
{
    public const float maxViewDst = 300;
    public Transform viewer;
    static MapGenerator mapGenerator;
    public Material mapMaterial;

    Dictionary<Vector2, TerrainChunk> terrainChunkDictionnary = new Dictionary<Vector2, TerrainChunk>();
    //liste des terrainChunk creer a la derniere frame
    List<TerrainChunk> terrainChunkVisibleLastUpdate = new List<TerrainChunk>();

    public static Vector2 viewerposition;
    int chunkSize;
    int chunkVisibleInViewDst;



    private void Start()
    {

        mapGenerator = FindObjectOfType<MapGenerator>();
        // chunkSize = 240 /240
        chunkSize = MapGenerator.mapChunkSize - 1;
        // on calcule la visibilé du joueur 
        chunkVisibleInViewDst = Mathf.RoundToInt(maxViewDst / chunkSize);

        int lenght = 1;
        for (int i = 0; i < lenght; i++)
        {
           
        }

     }

    private void Update()
    {
        viewerposition = new Vector2(viewer.position.x, viewer.position.z);
        UpdateVisibleChunks(); 
     
    }

    void UpdateVisibleChunks()
    {
        //grace a la boucle on desactive tout les chunk de la liste
        for (int i = 0; i < terrainChunkVisibleLastUpdate.Count; i++)
        {
            terrainChunkVisibleLastUpdate[i].SetVisible(false);
        }
        terrainChunkVisibleLastUpdate.Clear();

        // on recupère les chunks(plane) a coté du joueur au coordonné x/y le joueur et considéré au coordonné 0;0 on arrondi a l'in sup
        int currentChunkCoordX = Mathf.RoundToInt(viewerposition.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(viewerposition.y / chunkSize);

        //on boucle sur les chunk a proximité du joueur
        for ( int yOffset  = - chunkVisibleInViewDst; yOffset <= chunkVisibleInViewDst; yOffset++)      
        {
            for (int xOffset = -chunkVisibleInViewDst; xOffset <= chunkVisibleInViewDst; xOffset++)
            {
                // on recupère les coordonné des chunks
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);

                //verification des chunk déja generé pour evité d'en genré a nouveau
                if (terrainChunkDictionnary.ContainsKey(viewedChunkCoord))
                {
                    //on recupère le chunk sur lequel on travaille et on verifie si on doit l'affiché ou non avec la methode UpdateTerrainChunk()
                    terrainChunkDictionnary[viewedChunkCoord].UpdateTerrainChunk();

                    //si le chunk est visible on l'ajoute a la list
                    if (terrainChunkDictionnary[viewedChunkCoord].IsVisible())
                    {
                        // ajoute a la liste
                        terrainChunkVisibleLastUpdate.Add(terrainChunkDictionnary[viewedChunkCoord]);
                    }
                }
                else //si il existe pas dans le dico
                {
                    terrainChunkDictionnary.Add(viewedChunkCoord, new TerrainChunk(viewedChunkCoord,chunkSize, transform, mapMaterial));
     
                }

            }
        }
    }

    public class TerrainChunk
    {
        GameObject meshObject;
        Bounds bounds;
        Vector2 position;

        MapData mapData;
        MeshRenderer meshRenderer;
        MeshFilter meshFilter;


        // constructeur
        public TerrainChunk(Vector2 coord, int size, Transform parent, Material material)
        {
            int lenght = 0;
            while (lenght <= 1)
            {
                position = coord * size;
                bounds = new Bounds(position, Vector2.one * size);
                Vector3 positionV3 = new Vector3(position.x, 0, position.y);

            
                // creation du plane (objet de base de unity
                meshObject = new GameObject("TerrainChunk");
                lenght++;


                meshRenderer = meshObject.AddComponent<MeshRenderer>();
                meshFilter = meshObject.AddComponent<MeshFilter>();
                meshRenderer.material = material;
                // assigne la position a l'objet creer
                meshObject.transform.position = positionV3;


                meshObject.transform.parent = parent;
                lenght++;
            }
                SetVisible(false);

            mapGenerator.RequestMapData(OnMapDataReceived);

            
        }


        void OnMapDataReceived(MapData mapData)
        {
            mapGenerator.ResquestMeshData(mapData, OnMeshDataReceived);
        }

        void OnMeshDataReceived(MeshData meshData)
        {
            meshFilter.mesh = meshData.CreateMesh();
        }

        //permet de mettre a joueur le chunk
        public void UpdateTerrainChunk()
        {
            // permet de recupéré la distance en squareroot entre le bord le plus proche et le joueur
            float vieswerDstFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(viewerposition));
            bool visible = vieswerDstFromNearestEdge <= maxViewDst;
            SetVisible(visible);
        }

        public void SetVisible (bool visible)
        {
            //active/deactive le mesh en focntion de la distance
            meshObject.SetActive(visible);
        }

        public bool IsVisible()
        {
            // retourne true si actif et false si inactif
            return meshObject.activeSelf;
        }

    }
}
