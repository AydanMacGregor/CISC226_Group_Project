using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int minHealth = 0;
    [SerializeField] private int currentHealth;
    private int defaultHealth = 100;
    private int eyeballDamageAmount = 50;
    private int chargeDamageAmount = 25;

    public GameObject eyeball;
    public GameObject Charge;

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
    int OnTriggerEnter()
    {
        if(gameObject.name.Equals("Charge3"))
        {
            return 1;
        }
        else if (gameObject.name.Equals("Projectile"))
        {
            return 2;
        }

        return -1;
    }

    // Update is called once per frame
    void Update()
    {
        int attackCase = OnTriggerEnter();
        // Check which attack hit Tod
        if (attackCase == 1)
        {
            damage(eyeballDamageAmount);
        }
        else if (attackCase == 2)
        {
            damage(chargeDamageAmount);
        }
    }

    // Damage Tod's health when the souls attack him
    public void damage(int damageAmount)
    {
        currentHealth -= damageAmount;

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

