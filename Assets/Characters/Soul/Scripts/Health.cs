using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int minHealth;
    [SerializeField] private int currentHealth;
    private int defaultHealth = 100;
    private int defaultDamageAmount = 50;
    public GameObject slash;
    

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = setDefaultHealth(maxHealth);
        currentHealth = maxHealth;
    }

    // Set a default health for the soul
    private int setDefaultHealth(int curMaxVal)
    {
        if(curMaxVal > 0)
        {
            return curMaxVal;
        }
        else
        {
            return defaultHealth;
        }
    }

    // Check if the slash hit the soul
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "SlashAttack(Clone)")
        {
            damage(defaultDamageAmount);
        }
    }

    // Damage the soul when the slash hit into it
    public void damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            kill();
        }
    }

    // Destroy soul if health >= minHealth
    public void kill()
    {
        Destroy(this.gameObject);
    }
}
