using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public string scene;
    public PlayerStats playerStats;
    public Bullet bullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(scene == "Level1")
            {
                SceneManager.LoadScene(scene);
            }

            StateNameController.playerScore = playerStats.Score;
            StateNameController.selectedWeapon = playerStats.selectedWeapon;
            StateNameController.bulletDamage = bullet.bulletDamage;
            StateNameController.fireRate = playerStats.weaponFireRate;
            StateNameController.damage = playerStats.weaponDamage;
            StateNameController.coins = playerStats.coins;
            SceneManager.LoadScene(scene);
        }
    }
}
