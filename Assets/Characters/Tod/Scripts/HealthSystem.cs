﻿using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int minHealth = 0;
    [SerializeField] private int currentHealth;
    private int defaultHealth = 100;
    private int eyeballDamageAmount = 50;
    private int chargeDamageAmount = 25;

    private int screechDamageAmount = 50;

    private int batDamageAmount = 25;

    public Sprite eyeball;
    public Sprite Charge;
    public Sprite Screech;
    public Sprite Bat;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = setDefaultHealth(maxHealth);
        currentHealth = maxHealth;
    }

    // Set a default health for Tod
    private int setDefaultHealth(int curMaxVal)
    {
        if (curMaxVal > 0)
        {
            return curMaxVal;
        }
        else
        {
            return defaultHealth;
        }
    }

    // Check which attack hit Tod
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Soul")
        {
            if (other.gameObject.GetComponent<SpriteRenderer>().sprite == Charge)
            {
                damage(chargeDamageAmount);
            }
            else if (other.gameObject.GetComponent<SpriteRenderer>().sprite == eyeball)
            {
                damage(eyeballDamageAmount);
            }
        }

        if (other.gameObject.name == "Bat")
        {
            if (other.gameObject.GetComponent<SpriteRenderer>().sprite == Bat)
            {
                damage(batDamageAmount);
            }
            else if (other.gameObject.GetComponent<SpriteRenderer>().sprite == Screech)
            {
                damage(screechDamageAmount);
            }
        }
        
    }

    // Damage Tod's health when the souls attack him
    public void damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(currentHealth);

        if (currentHealth < minHealth)
        {
            kill();
        }
    }

    // Destroy Tod if health >= minHealth
    public void kill()
    {
        Destroy(this.gameObject);
    }
}

