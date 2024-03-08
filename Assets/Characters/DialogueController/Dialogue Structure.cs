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
    public float todScore;
    private float[] timeScores = {3f, 6f, 9f};
    private GameObject tutorial;
    
    void Start()
    {
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
        if (currentNode.getPrompt())
        {
            if (Input.GetMouseButtonDown(0))
            {
                wordIndex = TMP_TextUtilities.FindIntersectingLine(textComponent, Input.mousePosition, null);
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
                StopAllCoroutines();
                textComponent.text = string.Empty;
                textComponent.enabled = false;
                tod.GetComponent<NovelIdea>().scoreTime = todScore;
                tod.GetComponent<movement>().doneDialogue = true;
                if (tutorial != null)
                {
                    tutorial.GetComponent<guide>().start = true;
                }
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

    public void initializeVar(List<Node> d, TextMeshProUGUI t) 
    {
        todScore = 0;
        tod.GetComponent<NovelIdea>().scoreTime = 0f;
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
