using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class DB_manager : MonoBehaviour
{
    public static DB_manager instance;
    public string host, database, username, password;
    MySqlConnection con;


    private void Awake()
    {
        if( instance != null)
        {
            Debug.Log("il y a plus d'une instance de DB_Manager dans la scene");
        }

        instance = this;
    }


    void Start()
    {
        connect_BDD();
    }

    private void connect_BDD()
    {
       
    }
  
}
