using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: https://www.youtube.com/watch?v=N1BKXCxM_hA, https://www.youtube.com/watch?v=7iYWpzL9GkM

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float health = 30;
    public float damage = 10;
    public float score = 100;
    public Animator animator;
    public PlayerStats playerStats;
    private bool isPlayerDamagedable = false;
    private float damageInterval = 1f;
    private float time;

    [SerializeField] private AudioSource deathSound;
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
        deathSound.Play();
        animator.SetTrigger("death");
    }

    public void Defeated()
    {
        playerStats.Score += score;
        GetComponent<LootBag>().CreateLoot(transform.position);
        Destroy(gameObject);
    }

    private void Start()
    {
        time = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();

            if (player != null)
            {
                if(player.health > 0) {
                    player.Health -= damage;
                    player.GetHit();
                }
                
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isPlayerDamagedable)
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();

            if (player != null)
            {
                if (player.health > 0)
                {
                    player.Health -= damage;
                    player.GetHit();
                    isPlayerDamagedable = false;
                    time = Time.time;
                }
                
            }
        }
    }

    private void FixedUpdate()
    {
        if(time + damageInterval < Time.time)
        {
            isPlayerDamagedable = true;
        }
    }
}