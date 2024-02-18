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
    bool OnTriggerEnter()
    {
        if(gameObject.name.Equals("slash"))
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the slash hit the soul
        if (OnTriggerEnter())
        {
            damage(defaultDamageAmount);
        }
    }

    // Damage the soul when the slash hit into it
    public void damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= minHealth)
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
