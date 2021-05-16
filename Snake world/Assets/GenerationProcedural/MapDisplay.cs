using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRenderer;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    // on applique le perlinNoise sur le plane 
    public void DrawTexture( Texture2D texture)
    {
        // on applique la texture directement dans la scene et non au runTime
        textureRenderer.sharedMaterial.mainTexture = texture;

        //redimention du scale du plane  height(y) = z en 3D
        textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

    public void DrawMesh ( MeshData meshData, Texture2D texture)
    {
        meshFilter.sharedMesh = meshData.CreateMesh();
        meshRenderer.sharedMaterial.mainTexture = texture;
    }

}
