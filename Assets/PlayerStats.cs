using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public float health = 100;
    public float score = 0;
    public float coins = 0;
    public Animator animator;
    public float weaponFireRate = 0.5f;
    public float weaponDamage = 2f;
    public int selectedWeapon = -1;
    public UiLogic uiLogic;
    public Weapons weapons;
    public Shooting shooting;
    [SerializeField] private AudioSource deathSound;

    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
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
            OnScoreChange();
        }

        get
        {
            return score;
        }
    }

    public void Start()
    {
        Score = StateNameController.playerScore;
        selectedWeapon = StateNameController.selectedWeapon;
        weaponDamage = StateNameController.damage;
        weaponFireRate = StateNameController.fireRate;
        coins = StateNameController.coins;
        uiLogic.SetCoins();
        weapons.UpdateSelectedWeapon();
        shooting.UpdateWeaponStats();
        
    }

    public void OnScoreChange()
    {
        uiLogic.SetScore();
    }

    public void AddCoin()
    {
        coins += 1;
        uiLogic.SetCoins();
    }

    public void AddHp(float amount)
    {
        health += amount;
        uiLogic.SetHitPointsText();
    }

    public void GetHit()
    {
        animator.SetTrigger("isHit");
        uiLogic.SetHitPointsText();
    }

    public void Defeated()
    {
        deathSound.Play();
        StateNameController.playerScore = 0;
        StateNameController.selectedWeapon = -1;
        StateNameController.bulletDamage = 0;
        StateNameController.fireRate = 0;
        StateNameController.damage = 0;
        StateNameController.coins = 0;
        animator.SetTrigger("isPlayerDeath");
    }

    public void HandleDefeatedCleanUp()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }

}
