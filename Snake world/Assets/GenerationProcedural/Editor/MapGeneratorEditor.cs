using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator MapGen = (MapGenerator)target;

        // si on change une valeur dans l'inspector
        if (DrawDefaultInspector())
        {
            //si mapGen et modifier auto Update de la map
            if (MapGen.autoUpdate)
            {
                MapGen.GenerateMap();
            }
                    
        }

        //creation d'un bouton generate dans l'inspector
        if (GUILayout.Button("Generate"))
        {
            MapGen.GenerateMap();
        }
    }
}
