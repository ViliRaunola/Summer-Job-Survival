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
                StateNameController.playerScore = 0;
                StateNameController.selectedWeapon = -1;
                StateNameController.bulletDamage = 0;
                StateNameController.fireRate = 0;
                StateNameController.damage = 0;
                StateNameController.coins = 0;
                SceneManager.LoadScene(scene);
            }else
            {
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
}
