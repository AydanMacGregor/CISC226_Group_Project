using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NovelIdea : MonoBehaviour
{
    private float timedRebel = 20f;
    public Camera cam;
    public bool blockInput;
    private int ran;
    public bool canStart;
    public float scoreTime;

    void Start()
    {
        blockInput = false;
        canStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canStart)
        {
            if (timedRebel < 0)
            {
                ran = Random.Range(0,3);  
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
        timedRebel = scoreTime;
    }
}
