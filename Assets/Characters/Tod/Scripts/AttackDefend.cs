using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDefend : MonoBehaviour
{
    public GameObject slash;
    public GameObject tod;
    public GameObject raven;
    public Vector2 dir;
    private float attackTimer = 1f;
    public Animator an;
    public bool s = false;
    public bool sl = false;
    public Vector2 randFlip = new Vector2(1,1);
    public List<GameObject> ravens = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        dir = tod.GetComponent<movement>().direction;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<NovelIdea>().blockInput && this.GetComponent<movement>().doneDialogue)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer < 0) 
            {
                if (Input.GetMouseButtonDown(0))
                {
                    attackTimer = 0.5f;
                    sl = true;
                    Instantiate(slash, new Vector3(tod.transform.position.x + (0.5f * dir.x * randFlip.x), tod.transform.position.y + (0.5f * dir.y * randFlip.y), tod.transform.position.z), Quaternion.identity);
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    this.GetComponent<NovelIdea>().blockInput = true;
                    s = true;
                    an.Play("Shield");
                    StartCoroutine(StartShield());
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    if (ravens.Count < 3)
                    {
                        ravens.Add(Instantiate(raven, this.transform.position, Quaternion.identity));
                    }
                }
            }
        }
    }

    IEnumerator StartShield()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(EndShield());
    }

    IEnumerator EndShield()
    {
        an.Play("UnShield");
        yield return new WaitForSeconds(1f);
        this.GetComponent<NovelIdea>().blockInput = false;
        s = false;
        attackTimer = 0.5f;
    }
}
