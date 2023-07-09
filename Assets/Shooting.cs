using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

// Used as reference: https://www.youtube.com/watch?v=LNLVOjbrQj4


public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerInputActions playerControls;
    public PlayerStats PlayerStats;
    private InputAction shoot;
    private float shooting;
    private float fireRate;
    private float bulletForce;
    private float lastShot = 0f;
    

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        shoot = playerControls.Player.Fire;
        shoot.Enable();
        bulletForce = PlayerStats.weaponDamage;
        fireRate = PlayerStats.weaponFireRate;
    }

    private void OnDisable()
    {
        shoot.Disable();
        
    }

    public void UpdateWeaponStats()
    {
        bulletForce = PlayerStats.weaponDamage;
        fireRate = PlayerStats.weaponFireRate;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        shooting = shoot.ReadValue<float>();
        if (shooting == 1 && (Time.time > fireRate + lastShot) && PlayerStats.selectedWeapon >= 0)
        {
            Shoot();
            lastShot = Time.time;
        }

       
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
