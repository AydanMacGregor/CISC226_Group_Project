using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueStructure : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private float textSpeed;
    private int wordIndex;
    public List<Node> dialogue = new List<Node>();
    private Node currentNode;
    public GameObject tod;
    public bool done = false;
    public float todScore = 0;
    private float[] timeScores = {14f, 12f, 10f};
    private GameObject tutorial;
    public GameObject background;
    public Camera c;
    
    void Start()
    {
        //GameObject temp = GameObject.Find("CameraUI");
        //c = temp.GetComponent<Camera>();
        tod = GameObject.FindWithTag("Tod");
        textSpeed = .08f;
        if (SceneManager.GetActiveScene().name == "DenialScene")
        {
            tutorial = GameObject.FindWithTag("Tutorial");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tod.GetComponent<NovelIdea>().getTime() > 0f && Input.GetMouseButtonDown(1))
        {
            if (tod.GetComponent<NovelIdea>().getTime() > 0)
            {
                endText();
            }
        }
        if (currentNode.getPrompt())
        {
            if (Input.GetMouseButtonDown(0))
            {
                wordIndex = TMP_TextUtilities.FindIntersectingLine(textComponent, Input.mousePosition, c);
                Debug.Log(wordIndex);
                if (wordIndex >= 0 && wordIndex < 3)
                {
                    if (currentNode.extraNodes.Count < 1 && wordIndex == 0)
                    {
                        currentNode = currentNode.nextPrompt(wordIndex);
                        NextLine();
                    }
                    else if (currentNode.extraNodes.Count >= 1)
                    {
                        todScore += timeScores[wordIndex];
                        currentNode = currentNode.nextPrompt(wordIndex);
                        NextLine();
                    }
                }
            }
        }
        else if (Input.GetKeyDown("space"))
        {
            if (currentNode.getNext() == null)
            {
                endText();
            }
            else if (textComponent.text == currentNode.getText())
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = currentNode.getText();
            }
        }
        
    }

    void endText()
    {
        StopAllCoroutines();
        background.SetActive(false);
        textComponent.text = string.Empty;
        textComponent.enabled = false;
        tod.GetComponent<NovelIdea>().setTime(todScore);
        tod.GetComponent<movement>().doneDialogue = true;
        if (tutorial != null)
        {
            tutorial.GetComponent<guide>().start = true;
        }
    }

    public void initializeVar(List<Node> d, TextMeshProUGUI t) 
    {
        if (GameObject.Find("Tutorial") != null && tod.GetComponent<NovelIdea>().getTime() > 0f)
        {
            Destroy(GameObject.Find("Tutorial"));
        }
        background.SetActive(true);
        tod.GetComponent<movement>().doneDialogue = false;
        dialogue = new List<Node>();
        for (int i = 0; i < d.Count; i ++)
        {
            dialogue.Add(d[i]);
        }
        textComponent = t;
        StartDialogue();
    }
    
    public void StartDialogue()
    {
        textComponent.text = string.Empty;
        currentNode = dialogue[0];
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentNode.getText().ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        currentNode = currentNode.getNext();
        if (currentNode.ip)
        {
            StopAllCoroutines();
            textComponent.alignment = TextAlignmentOptions.TopLeft;
            textComponent.text = currentNode.getText();
        }
        else
        {
            textComponent.text = string.Empty;
            textComponent.alignment = TextAlignmentOptions.Center;
            textComponent.alignment = TextAlignmentOptions.Top;
            StartCoroutine(TypeLine());
        }
    }
}
