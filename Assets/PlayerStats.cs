using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        animator.SetTrigger("isPlayerDeath");
    }

    public void HandleDefeatedCleanUp()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }

    private IEnumerator showGameOverMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameOver");
    }

}
