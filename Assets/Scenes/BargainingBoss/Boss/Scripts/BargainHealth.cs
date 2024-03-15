using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainHealth : MonoBehaviour
{
    private float bargainBossHealth = 100f;
    public bossHealthBar healthBar;
    public GameObject check;

    void Update()
    {
        healthBar.SetHealth(bargainBossHealth);

        if (bargainBossHealth <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        Instantiate(check, new Vector3(-100, 0, 0), Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "SlashAttack(Clone)")
        {
            bargainBossHealth -= 10;
        }
        else if (other.gameObject.name == "Raven(Clone)")
        {
            bargainBossHealth -= 25;
        }

        healthBar.SetHealth(bargainBossHealth);
    }
}
