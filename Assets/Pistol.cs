using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    private float fireRate = 0.5f;
    private float bulletForce = 2f;
    private int weaponId = 0;
    private float bulletDamage = 10;
    public Shooting shooting;
    public Weapons weapons;
    public Bullet bullet;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();

            if (player != null)
            {
                player.selectedWeapon = weaponId;
                player.weaponFireRate = fireRate;
                player.weaponDamage = bulletForce;
                bullet.bulletDamage = bulletDamage;
                shooting.UpdateWeaponStats();
                weapons.UpdateSelectedWeapon();
                Destroy(gameObject);
            }
        }
    }
}
