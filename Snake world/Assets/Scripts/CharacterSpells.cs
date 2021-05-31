using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpells : MonoBehaviour
{
    public GameObject spel1;

    public void SpellCast()
    {
        GameObject go = Instantiate(spel1, transform.position, Quaternion.identity);
        Destroy(go, 3);
    }
}
