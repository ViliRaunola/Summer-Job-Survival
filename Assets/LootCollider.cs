using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

            if (player != null)
            {
                if(gameObject.name == "EnergyDrink")
                {
                    playerMovement.GiveSpeedBoost(15f, 5f);
                    Destroy(gameObject);
                } else if(gameObject.name == "Coffee")
                {
                    player.AddHp(30f);
                    Destroy(gameObject);
                }else if (gameObject.name == "Coin")
                {
                    player.AddCoin();
                    Destroy(gameObject);
                }
            }
        }
    }
}
