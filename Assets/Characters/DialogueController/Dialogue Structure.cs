using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueStructure : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private float textSpeed;
    private int wordIndex;
    public List<Node> dialogue = new List<Node>();
    private Node currentNode;
    
    void Start()
    {
        textSpeed = .08f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNode.getPrompt())
        {
            if (Input.GetMouseButtonDown(0))
            {
                wordIndex = TMP_TextUtilities.FindIntersectingLine(textComponent, Input.mousePosition, null);
                if (wordIndex != -1)
                {
                    currentNode = currentNode.nextPrompt(wordIndex);
                    NextLine();
                }
            }
        }
        else if (Input.GetKeyDown("space"))
        {
            if (currentNode.getNext() == null)
            {
                textComponent.enabled = false;
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
            textComponent.alignment = TextAlignmentOptions.Left;
            textComponent.text = currentNode.getText();
        }
        else
        {
            textComponent.text = string.Empty;
            textComponent.alignment = TextAlignmentOptions.Center;
            StartCoroutine(TypeLine());
        }
    }
}
