using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public float health = 100;
    public float score = 0;
    public Animator animator;
    public float weaponFireRate = 0.5f;
    public float weaponDamage = 2f;
    public int selectedWeapon = 1;
    public UiLogic uiLogic;

    public float Health
    {
        set
        {
            health = value;
            if (health == 0)
            {
                Defeated();
            }
        }

        get
        {
            return health;
        }
    }

    public float Score
    {
        set
        {
            score = value;
        }

        get
        {
            return score;
        }
    }

    public void GetHit()
    {
        animator.SetTrigger("isHit");
        uiLogic.SetHitPointsText();
    }

    public void Defeated()
    {
        animator.SetTrigger("isPlayerDeath");
    }

    public void HandleDefeatedCleanUp()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }

}
