using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class guide : MonoBehaviour
{
    public TextMeshProUGUI currentText;
    private GameObject ds;
    int i = 0;
    List<Node> l = new List<Node>();
    private Collider2D hitColliders;
    string current;
    public bool start = false;
    private bool check = false;
    GameObject tod;
    
    void Start()
    {
        current = SceneManager.GetActiveScene().name;
        ds = GameObject.FindWithTag("DialogueSystem");
        tod = GameObject.FindWithTag("Tod");
        l.Add(new Node("WASD to Move", false));
        l.Add(new Node("Click to Attack", false));
        l.Add(new Node("Press E to Launch Raven", false));
        l.Add(new Node("Right Click to Shield", false));
    }

    void Write()
    {
        currentText.enabled = true;
        currentText.text = string.Empty;
        currentText.text = l[i].getText();
    }

    void Update()
    {
        tod.GetComponent<NovelIdea>().canStart = false;
        if (start)
        {
            if (!currentText.enabled && i > 0)
            {
                hitColliders = Physics2D.OverlapCircle(tod.transform.transform.localPosition, 5f, LayerMask.GetMask("Bat", "Soul"));
                if (hitColliders != null)
                    Write();
                    check = true;
            }
            else
            {
                Write();
                check = true;
            }
        }

        if (check)
        {
            switch(i) 
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                    {
                        currentText.enabled = false;
                        check = false;
                        i++;
                    }
                    break;
                case 1:
                    if (Input.GetMouseButtonDown(0))
                    {
                        currentText.enabled = false;
                        check = false;
                        i++;
                    }
                    break;
                case 2:
                    if (GameObject.Find("Raven(Clone)"))
                    {
                        currentText.enabled = false;
                        check = false;
                        i++;
                    }
                    break;
                case 3:
                    if (Input.GetMouseButtonDown(1))
                    {
                        currentText.enabled = false;
                        check = false;
                        tod.GetComponent<NovelIdea>().canStart = true;
                        Destroy(gameObject);
                    }
                    break;
            }
        }
    }
}
