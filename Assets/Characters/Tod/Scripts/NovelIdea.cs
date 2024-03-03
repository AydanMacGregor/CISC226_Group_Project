using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NovelIdea : MonoBehaviour
{
    private float timedRebel = 20f;
    public Camera cam;
    TextMeshProUGUI currentText;
    public bool blockInput;
    private int ran;
    public bool canStart;
    public float scoreTime;
    private bool firstPushBack;
    
    void Start()
    {
        blockInput = false;
        canStart = false;
        if (SceneManager.GetActiveScene().name == "DenialScene")
        {
            firstPushBack = true;
        }
        else
        {
            firstPushBack = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canStart)
        {
            if (timedRebel < 0)
            {
                ran = Random.Range(0,4); 
                if (firstPushBack)
                {
                    ran = 0;
                    List<Node> d = new List<Node>();
                    d.Add(new Node("Wait... are you doing that or am I?", false));
                    d.Add(new Node("- ...", true));
                    d.Add(new Node("ha! I can fight against you.", false));
                    d.Add(new Node("Better not cross me", false));
                    d[0].setNode(d[1]);
                    d[1].setNode(d[2]);
                    d[2].setNode(d[3]);
                    GameObject dc = GameObject.FindWithTag("DialogueSystem");
                    currentText = (TextMeshProUGUI)FindObjectOfType(typeof(TextMeshProUGUI));
                    currentText.enabled = true;
                    dc.GetComponent<DialogueStructure>().initializeVar(d, currentText);
                    firstPushBack = false;
                } 
                if (ran == 0)
                {
                    Vector3 scale = new Vector3(1, -1, 1);
                    cam.projectionMatrix = cam.projectionMatrix * Matrix4x4.Scale(scale);
                }
                else if (ran == 1)
                {
                    blockInput = true;
                }
                else if (ran == 2)
                {
                    this.GetComponent<movement>().xFlip = -1;
                    this.GetComponent<movement>().yFlip = -1;
                }
                else if (ran == 3)
                {
                    if (Random.Range(0,2) == 0)
                    {
                        this.GetComponent<AttackDefend>().randFlip.x = -1;
                    }
                    else
                    {
                        this.GetComponent<AttackDefend>().randFlip.y = -1;
                    }
                }
                StartCoroutine(Finished(ran));
                timedRebel = 20f;
            }
            timedRebel -= Time.deltaTime;
        }
    }

    IEnumerator Finished(int r)
    {
        yield return new WaitForSeconds(5f);
        if (r == 0)
        {
            Vector3 scale = new Vector3(1, -1, 1);
            cam.projectionMatrix = cam.projectionMatrix * Matrix4x4.Scale(scale);
        }
        else if (r == 1)
        {
            blockInput = false;
        }
        else if (r == 2)
        {
            this.GetComponent<movement>().xFlip = 1;
            this.GetComponent<movement>().yFlip = 1;
        }
        else if (r == 3)
        {
            this.GetComponent<AttackDefend>().randFlip = new Vector2(1,1);
        }
        timedRebel = scoreTime;
    }
}
