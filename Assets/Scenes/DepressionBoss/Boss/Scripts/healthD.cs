using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthD : MonoBehaviour
{
    private float damage;
    private float bossHealth = 300f;
    public bossHealthBar healthBar;
    public GameObject check;


    void Update()
    {
        healthBar.SetHealth(bossHealth);

        if (bossHealth <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        Instantiate(check, new Vector3(-100, 0, 0), Quaternion.identity);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.name == "SlashAttack(Clone)")
        {
            bossHealth -= 15;
            Debug.Log(bossHealth);
        }
        healthBar.SetHealth(bossHealth);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.name == "Raven(Clone)")
        {
            bossHealth -= 5;
            Debug.Log(bossHealth);
        }
        healthBar.SetHealth(bossHealth);
    }
}
