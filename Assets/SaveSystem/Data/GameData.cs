using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int health;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> coinsCollected;

    public GameData()
    {
        this.health = 10;
        playerPosition = Vector3.zero;
        coinsCollected = new SerializableDictionary<string, bool>();
    }


}
