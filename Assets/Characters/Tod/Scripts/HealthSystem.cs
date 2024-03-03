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
    private int beamDamageAmount = 25;
    private float damageTime = 0f;

    private int screechDamageAmount = 50;

    private int batDamageAmount = 25;

    public Sprite eyeball;
    public Sprite Charge;


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
        if (!gameObject.GetComponent<AttackDefend>().s)
        {
            if (other.gameObject.name == "Soul" && other.gameObject.GetComponent<SpriteRenderer>().sprite == Charge)
            {
                damage(chargeDamageAmount);
            }
            else if (other.gameObject.name == "projectile")
            {
                damage(eyeballDamageAmount);
            }
            if (other.gameObject.name == "Bat" || other.gameObject.name == "Bat(Clone)")
            {
                damage(batDamageAmount);
            }
            if (other.gameObject.name == "ScreechSymbol(Clone)")
            {
                damage(screechDamageAmount);
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.GetComponent<AttackDefend>().s)
        {
            if (other.gameObject.name == "Beam" || other.gameObject.name == "BeamLine(Clone)")
            {
                damageTime -= Time.deltaTime;
                if (damageTime <= 0)
                {
                    damage(beamDamageAmount);
                    damageTime = 1f;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!gameObject.GetComponent<AttackDefend>().s)
        {
            if (other.gameObject.name == "Beam" || other.gameObject.name == "BeamLine(Clone)")
            {
                damageTime = 0;
            }
        }
        
    }

    // Damage Tod's health when the souls attack him
    public void damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= minHealth)
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

