using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{
    public float speed = 5f;

    public int health;
    public int coins;

    public Text healthText;
    public Text coinText;

    public void LoadData(GameData data)
    {
        this.health = data.health;
        this.transform.position = data.playerPosition;

        foreach(KeyValuePair<string, bool> pair in data.coinsCollected)
        {
            if (pair.Value)
            {
                coins++;
                
            }
        }
    }

    public void SaveData(GameData data)
    {
        data.health = this.health;
        data.playerPosition = this.transform.position;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical); 

        transform.position += (Vector3)movement * speed * Time.deltaTime;

        healthText.text = "HP: " + health;
        coinText.text = "Coins: " + coins;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
        }
    }


}
