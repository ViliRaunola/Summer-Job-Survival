using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void ToMainMenu()
    {
        StateNameController.playerScore = 0;
        StateNameController.selectedWeapon = -1;
        StateNameController.bulletDamage = 0;
        StateNameController.fireRate = 0;
        StateNameController.damage = 0;
        StateNameController.coins = 0;
        SceneManager.LoadScene("Menu");
    }
}
