using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DataPersistenceManager.instance.LoadGame();
            Debug.Log("Game Loaded");

        }
    }
}
