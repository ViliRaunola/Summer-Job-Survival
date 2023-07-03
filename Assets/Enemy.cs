using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: https://www.youtube.com/watch?v=N1BKXCxM_hA, https://www.youtube.com/watch?v=7iYWpzL9GkM

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float health = 30;
    public float damage = 10;
    public Animator animator;

    public float Health
    {
        set
        {
            health = value;
            if(health <= 0)
            {
                PlayDefeatedAnimation();
            }
        }

        get 
        { 
            return health;
        }
    }

    public void PlayDefeatedAnimation()
    {
        animator.SetTrigger("death");
    }

    public void Defeated()
    {
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();

            if (player != null)
            {
                player.Health -= damage;
                player.GetHit();
            }
        }
    }
}