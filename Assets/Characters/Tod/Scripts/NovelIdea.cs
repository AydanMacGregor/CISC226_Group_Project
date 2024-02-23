using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NovelIdea : MonoBehaviour
{
    private float timedRebel = 20f;
    private bool flip = false;
    public Camera cam;
    public bool blockInput;
    private int ran;
    public bool canStart;
    public int scoreTime;

    void Start()
    {
        CheckScene();
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
                ran = Random.Range(0,2);
                if (flip)
                {
                    flip = flip ? false : true;
                    Vector3 scale = new Vector3(1, flip ? -1 : 1, 1);
                    cam.projectionMatrix = cam.projectionMatrix * Matrix4x4.Scale(scale);
                }
                else if (blockInput)
                {
                    blockInput = false;
                }
                else if (ran == 0)
                {
                    flip = flip ? false : true;
                    Vector3 scale = new Vector3(1, flip ? -1 : 1, 1);
                    cam.projectionMatrix = cam.projectionMatrix * Matrix4x4.Scale(scale);
                }
                else if (ran == 1)
                {
                    blockInput = blockInput ? false : true;
                }
                timedRebel = scoreTime;
            }
            timedRebel -= Time.deltaTime;
        }
        
    }

    void CheckScene()
    {
        if (SceneManager.GetActiveScene().name == "DenialBossFloor")
        {
            blockInput = false;
        }
    }
}
