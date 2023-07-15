using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop : MonoBehaviour
{

    public PlayerStats playerStats;
    public Weapons weapons;
    public Pistol pistol;
    public Sniper sniper;
    public Rifle rifle;
    public Bullet bullet;
    public Shooting shooting;
    public UiLogic uiLogic;
    public GameObject itemMenu;

    private float pistolPrice = 1;
    private float sniperPrice = 3;
    private float riflePrice = 6;

    public void Start()
    {
        itemMenu.SetActive(false);
    }

    public void BuyPistol()
    {
        if (playerStats.coins >= pistolPrice)
        {
            playerStats.coins -= pistolPrice;
            uiLogic.SetCoins();
            playerStats.selectedWeapon = pistol.weaponId;
            playerStats.weaponFireRate = pistol.fireRate;
            playerStats.weaponDamage = pistol.bulletForce;
            bullet.bulletDamage = pistol.bulletDamage;
            shooting.UpdateWeaponStats();
            weapons.UpdateSelectedWeapon();
        }
    }

    public void BuySniper()
    {
        if (playerStats.coins >= sniperPrice)
        {
            playerStats.coins -= sniperPrice;
            uiLogic.SetCoins();
            playerStats.selectedWeapon = sniper.weaponId;
            playerStats.weaponFireRate = sniper.fireRate;
            playerStats.weaponDamage = sniper.bulletForce;
            bullet.bulletDamage = sniper.bulletDamage;
            shooting.UpdateWeaponStats();
            weapons.UpdateSelectedWeapon();
        }
    }

    public void BuyRifle()
    {
        if (playerStats.coins >= riflePrice)
        {
            playerStats.coins -= riflePrice;
            uiLogic.SetCoins();
            playerStats.selectedWeapon = rifle.weaponId;
            playerStats.weaponFireRate = rifle.fireRate;
            playerStats.weaponDamage = rifle.bulletForce;
            bullet.bulletDamage = rifle.bulletDamage;
            shooting.UpdateWeaponStats();
            weapons.UpdateSelectedWeapon();
        }
    }
}
