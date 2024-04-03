using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int minHealth;
    [SerializeField] private int currentHealth;
    private int defaultHealth = 200;
    private int defaultDamageAmount = 50;
    public AudioSource src;
    public AudioClip sfx1;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = setDefaultHealth(maxHealth);
        currentHealth = maxHealth; 
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
        // Flash Red
        src.clip=sfx1;
        src.Play();
        StartCoroutine(RedFlash());
        
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Flashes red upon taking damage
    IEnumerator RedFlash()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
