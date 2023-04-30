using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HealthSystem : MonoBehaviour
{
    public int healAmount = 20;
    public float healDuration = 2f;

    private bool canHeal = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canHeal)
        {
            PlayerMovement playerHealth = other.GetComponent<PlayerMovement>();
            if (playerHealth != null)
            {
                //playerHealth.Heal(healAmount);
                playerHealth.health += healAmount;
                canHeal = false;
                gameObject.SetActive(false);
                Invoke("Reactivate", healDuration);
            }
        }
    }

    private void Reactivate()
    {
        canHeal = true;
        gameObject.SetActive(true);
    }

}
