using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int minHealth;
    [SerializeField] private int currentHealth;
    private int defaultHealth = 150;
    private int defaultDamageAmount = 50;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = setDefaultHealth(maxHealth);
        currentHealth = maxHealth; 

        sprite = GetComponent<SpriteRenderer>();
    }

    // Set a default health for the bat
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

    // Makes the bat red
    public IEnumerator FlashRed()
    {
        sprite.color = new Color (1, 0, 0, 1);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color (1, 1, 1, 1);
    }

    // Check if the slash hit the bat
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "SlashAttack(Clone)")
        {
            damage(defaultDamageAmount);
        }
        else if (collision.gameObject.name == "Raven(Clone)")
        {
            damage(defaultDamageAmount);
        }
    }

    // Damage the bat when the slash hit into it
    public void damage(int damageAmount)
    {
        StartCoroutine(FlashRed());
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
