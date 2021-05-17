using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
    public static MeshData GenerateTerrainMesh(float[,] heightmap, float heightMultiplier, AnimationCurve _heightCurve, int levelOfdetail)
    {
        AnimationCurve heightCurve = new AnimationCurve(_heightCurve.keys);
        // on recupère la largeur et la longueur de la map
        int width = heightmap.GetLength(0);
        int height = heightmap.GetLength(1);
        // calcule du point le plus a gauche
        float topLeftX = (width - 1) / -2f;
        float topleftZ = (width - 1) / 2f;

        int meshSimplificationIncrement = levelOfdetail * 2;


        //on verifi si levelOfdetail est egale a 0 
        //methode terniOperator meshSimplificationIncrement = (levelOfDetail == 0)?1:levelOfDetail *2
        if (levelOfdetail == 0)
        {
            meshSimplificationIncrement = 1;
        }
        else
        {
            meshSimplificationIncrement = levelOfdetail * 2;
        }


        int verticesPerLine = (width - 1) / meshSimplificationIncrement + 1;


        MeshData meshData = new MeshData(verticesPerLine, verticesPerLine);

        int vertexIndex = 0;

        


        for (int y = 0; y < height; y += meshSimplificationIncrement)
        {
            for (int x = 0; x < width; x += meshSimplificationIncrement)
            {
                 
                    //on stock les information des vertices
                    meshData.vertices[vertexIndex] = new Vector3(topLeftX + x, heightCurve.Evaluate(heightmap[x, y]) * heightMultiplier, topleftZ - y);
                
       
                //on localise le vertex et on lui envois un pourcentage entre 0 et 1
                meshData.uvs[vertexIndex] = new Vector2(x / (float)width, y / (float)height);


                // grace a cette condition on ignor tout les vertex qui tout a droite de la carte et tout en bas (bord de carte droite et bas)
                if (x < width - 1 && y < height - 1)
                {
                    /*ajoute les triangle par 2 dans le tableau:
                     vertexIndex = i
                     1er triangle : i (1er sommet) ,  i + width +1 (2eme sommet) , i + width (3eme sommet)
                     2em triangle : i + width + 1 (1er sommet), i (2eme sommet), i + 1 (3eme sommet)*/
                    meshData.AddTriangle(vertexIndex, vertexIndex + verticesPerLine + 1, vertexIndex + verticesPerLine);// 1er triagnle
                    meshData.AddTriangle(vertexIndex + verticesPerLine + +1, vertexIndex, vertexIndex + 1); // 2eme triangle
                }
                vertexIndex++;
            }
        }

        return meshData;

    }
}

public class MeshData
{
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uvs;

    public int triangleIndex;

    //constructeur
    public MeshData(int meshWidth, int meshHeight)
    {
        //calcule du nombre de vertices(sommet) pour une map de 3*3 = 9 vertices
        vertices = new Vector3[meshWidth * meshHeight];

        uvs = new Vector2[meshWidth * meshHeight];

        //calcule le nombre de tiangle pour une map de 3*3 ça fait 4 carrée qui sont constitué de 2 triangles donc 8 au total
        triangles = new int[(meshWidth - 1) * (meshHeight - 1) * 6];

    }

    //inserré un triangle dans le tableau
    public void AddTriangle(int a, int b, int c)
    {
        triangles[triangleIndex] = a;
        triangles[triangleIndex + 1] = b;
        triangles[triangleIndex + 2] = c;

        //decalé les index de 3 pour les triangle (3 sommets)
        triangleIndex += 3;

    }

    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        return mesh;
    }
}
