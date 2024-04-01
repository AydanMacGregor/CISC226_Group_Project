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
        for (int i = 0; i < this.GetComponent<AngerAttack>().flames.Count; i++)
        {
            Destroy(this.GetComponent<AngerAttack>().flames[i].gameObject);
        }
        this.GetComponent<AngerAttack>().flames.Clear();
        Instantiate(check, new Vector3(-100, 0, 0), Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "SlashAttack(Clone)")
        {
            angerBossHealth -= 10;
        }

        healthBar.SetHealth(angerBossHealth);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Raven(Clone)")
        {
            angerBossHealth -= 5;
        }
        healthBar.SetHealth(angerBossHealth);
    }
}
