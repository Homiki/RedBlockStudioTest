using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    CapsuleCollider2D saveCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DataPersistenceManager.instance.SaveGame();
            Debug.Log("Game Saved");

        }
    }

}
