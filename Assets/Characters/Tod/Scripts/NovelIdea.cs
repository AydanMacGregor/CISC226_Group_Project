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
    public static float scoreTime;
    private bool firstPushBack;
    private bool idc = true;
    private bool waitTime = false;
    public AudioSource src;
    public AudioClip sfx3;
    public bool flipx = false;
    public bool flipy = false;
    
    void Start()
    {
        blockInput = false;
        canStart = false;
        if (SceneManager.GetActiveScene().name == "DenialScene")
        {
            firstPushBack = true;
            this.GetComponent<TodNovelBar>().SetMaxVal(timedRebel);
        }
        else
        {
            firstPushBack = false;
        }
    }

    public void resetTime()
    {
        scoreTime = 0;
    }

    public void setTime(float t)
    {
        if (t > 0)
        {
            scoreTime = t;
        }
        if (SceneManager.GetActiveScene().name != "DenialScene")
        {
            this.GetComponent<TodNovelBar>().SetMaxVal(scoreTime);
            this.GetComponent<TodNovelBar>().SetVal(scoreTime);
            timedRebel = scoreTime;
        }
        
    }

    public float getTime()
    {
        return scoreTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (canStart)
        {
            if (timedRebel <= 0)
            {
                if (firstPushBack)
                {
                    if (idc){
                        src.clip=sfx3;
                        src.Play();
                        idc = false;
                        ran = 0;
                        List<Node> d = new List<Node>();
                        d.Add(new Node("Wait... are you doing that or am I?", false));
                        d.Add(new Node("- ...", true));
                        d.Add(new Node("ha! I can fight against you.", false));
                        d.Add(new Node("Better be nice to me, I don't always have to listen to you now.", false));
                        d[0].setNode(d[1]);
                        d[1].setNode(d[2]);
                        d[2].setNode(d[3]);
                        GameObject dc = GameObject.FindWithTag("DialogueSystem");
                        GameObject c = GameObject.Find("Dialogue");
                        currentText = c.GetComponent<TextMeshProUGUI>();;
                        currentText.enabled = true;
                        dc.GetComponent<DialogueStructure>().initializeVar(d, currentText);
                        this.GetComponent<AttackDefend>().s = true;
                        Matrix4x4 scale = Matrix4x4.Scale(new Vector3(1, -1, 1));
                        cam.projectionMatrix = cam.projectionMatrix * scale;
                        timedRebel = 0f;
                        waitTime = true;
                    }
                    else if (!idc)
                    {
                        if (!currentText.enabled)
                        {
                            firstPushBack = false;
                            this.GetComponent<AttackDefend>().s = false;
                            Matrix4x4 scale = Matrix4x4.Scale(new Vector3(1, -1, 1));
                            cam.projectionMatrix = cam.projectionMatrix * scale;
                            timedRebel = scoreTime;
                            this.GetComponent<TodNovelBar>().SetMaxVal(scoreTime);
                            waitTime = false;
                        }
                    }
                } 
                else if (!firstPushBack && !waitTime)
                {
                    src.clip=sfx3;
                    src.Play();
                    GameObject cameraShake = GameObject.Find("Virtual Camera");
                    cameraShake.GetComponent<CameraShake>().ShakeCamera();
                    ran = Random.Range(0,4);
                    waitTime = true;
                    if (ran == 0)
                    {
                        Vector3 scale = new Vector3(1, -1, 1);
                        cam.projectionMatrix = cam.projectionMatrix * Matrix4x4.Scale(scale);
                    }
                    else if (ran == 1)
                    {
                        this.GetComponent<AttackDefend>().s = true;
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
                            flipx = true;
                        }
                        else
                        {
                            flipy = true;
                        }
                    }
                    StartCoroutine(Finished(ran));
                }
            }
            if (!waitTime)
            {
                timedRebel -= Time.deltaTime;
                this.GetComponent<TodNovelBar>().SetVal(timedRebel);
            }
            
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
            this.GetComponent<AttackDefend>().s = false;
            blockInput = false;
        }
        else if (r == 2)
        {
            this.GetComponent<movement>().xFlip = 1;
            this.GetComponent<movement>().yFlip = 1;
        }
        else if (r == 3)
        {
            flipx = false;
            flipy = false;
        }
        timedRebel = scoreTime;
        waitTime = false;
    }
}
