using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int minHealth = 0;
    [SerializeField] private int currentHealth;
    private int defaultHealth = 100;
    private int eyeballDamageAmount = 50;
    private int chargeDamageAmount = 25;
    private int beamDamageAmount = 25;
    private int flameDamageAmount = 50;
    private float damageTime = 0f;

    private int screechDamageAmount = 50;

    private int batDamageAmount = 25;

    public Sprite eyeball;
    public Sprite Charge;

    private float regenTimer = 8f;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = setDefaultHealth(maxHealth);
        currentHealth = maxHealth;

        this.GetComponent<TodHealthBar>().SetMaxHealth(currentHealth);
    }

    void Update()
    {
        regen();
    }

    // Set a default health for Tod
    public int setDefaultHealth(int curMaxVal)
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
            if (other.gameObject.tag == "Soul" && other.gameObject.GetComponent<SpriteRenderer>().sprite == Charge)
            {
                damage(chargeDamageAmount);
            }
            else if (other.gameObject.name == "projectile(Clone)")
            {
                damage(eyeballDamageAmount);
            }
            else if (other.gameObject.name == "Bat" || other.gameObject.name == "Bat(Clone)")
            {
                damage(batDamageAmount);
            }
            else if (other.gameObject.name == "Bat" && other.gameObject.GetComponent<SpriteRenderer>().sprite == Charge)
            {
                damage(chargeDamageAmount);
            }
            else if (other.gameObject.name == "ScreechSymbol(Clone)")
            {
                damage(screechDamageAmount);
            }
            else if (other.gameObject.name == "BatBaby" || other.gameObject.name == "BatBaby(Clone)")
            {
                damage(batDamageAmount);
            }
            else if (other.gameObject.tag == "Flame")
            {
                damage(flameDamageAmount);
            }
            else if (other.gameObject.tag == "AngerBoss" && other.gameObject.GetComponent<AngerAttack>().damage)
            {
                damage(chargeDamageAmount);
            }
            else if (other.gameObject.name == "ChainClap3(Clone)")
            {
                damage(screechDamageAmount);
            }
            else if (other.gameObject.tag == "DenialBoss" && other.gameObject.GetComponent<bossMovement>().chargeFlag)
            {
                damage(chargeDamageAmount);
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
            if (other.gameObject.name == "BeamOfBall" || other.gameObject.name == "BeamOfBall(Clone)")
            {
                damageTime -= Time.deltaTime;
                if (damageTime <= 0)
                {
                    damage(10);
                    damageTime = 2f;
                }
            }
            if (other.gameObject.name == "DevineLine" || other.gameObject.name == "DevineLine(Clone)")
            {
                damageTime -= Time.deltaTime;
                if (damageTime <= 0)
                {
                    damage(beamDamageAmount);
                    damageTime = 1f;
                }
            }
            if (other.gameObject.name == "DevineCenter" || other.gameObject.name == "DevineCenter(Clone)")
            {
                damageTime -= Time.deltaTime;
                if (damageTime <= 0)
                {
                    damage(beamDamageAmount);
                    damageTime = 1f;
                }
            }
            if (other.gameObject.name == "ChainExtend3" || other.gameObject.name == "ChainExtend3(Clone)")
            {
                damageTime -= Time.deltaTime;
                if (damageTime <= 0)
                {
                    damage(beamDamageAmount);
                    damageTime = 1f;
                }
            }
            if (other.gameObject.name == "ChainExtend4" || other.gameObject.name == "ChainExtend4(Clone)")
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
            if (other.gameObject.name == "BeamOfBall" || other.gameObject.name == "BeamOfBall(Clone)")
            {
                damageTime = 0;
            }
            if (other.gameObject.name == "DevineLine" || other.gameObject.name == "DevineLine(Clone)")
            {
                damageTime = 0;
            }
            if (other.gameObject.name == "DevineCenter" || other.gameObject.name == "DevineCenter(Clone)")
            {
                damageTime = 0;
            }
            if (other.gameObject.name == "Extend" || other.gameObject.name == "Extend(Clone)")
            {
                damageTime = 0;
            }
            if (other.gameObject.name == "ExtendLines" || other.gameObject.name == "ExtendLines(Clone)")
            {
                damageTime = 0;
            }
            
        }
        
    }

    // Damage Tod's health when the souls attack him
    public void damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        regenTimer = 8f;
        this.GetComponent<TodHealthBar>().SetHealth(currentHealth);

        if (currentHealth <= minHealth)
        {
            kill();
        }
    }

    void regen()
    {
        if (regenTimer < 0 && currentHealth < 100)
        {
            currentHealth += 1;
            this.GetComponent<TodHealthBar>().SetHealth(currentHealth);
            regenTimer = 0.05f;
        }
        regenTimer -= Time.deltaTime;
    }

    // Destroy Tod if health >= minHealth
    public void kill()
    {
        GameObject.Find("GameM").GetComponent<Manager>().prevScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("DeathScene");
    }
}

