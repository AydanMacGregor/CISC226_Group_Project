using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerHealth : MonoBehaviour
{
    private float angerBossHealth = 100f;
    public bossHealthBar healthBar;
    public GameObject check;

    void Update()
    {
        healthBar.SetHealth(angerBossHealth);

        if (angerBossHealth <= 0)
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
            angerBossHealth -= 10;
        }
        else if(other.gameObject.name == "Raven(Clone)")
        {
            angerBossHealth -= 25;
        }

        healthBar.SetHealth(angerBossHealth);
    }
}
