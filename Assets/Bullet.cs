using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public float deadZoneXNeg = -1000;
    public float deadZoneXPos = 1000;
    public float deadZoneYNeg = -1000;
    public float deadZoneYPos = 1000;
    public float bulletDamage = StateNameController.bulletDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Add damaging here

        if(collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if(enemy != null)
            {
                
                enemy.Health -= bulletDamage;
            }
        }

        Destroy(gameObject);

    }

    private void FixedUpdate()
    {
        if (transform.position.x < deadZoneXNeg 
            || transform.position.x > deadZoneXPos 
            || transform.position.y < deadZoneYNeg 
            || transform.position.y > deadZoneYPos
            )
        {
            Destroy(gameObject);
        }
    }

}
