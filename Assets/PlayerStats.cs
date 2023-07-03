using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float health = 100;
    public Animator animator;

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

    public void GetHit()
    {
        animator.SetTrigger("isHit");
    }

    public void Defeated()
    {
        Destroy(gameObject);
    }

}
