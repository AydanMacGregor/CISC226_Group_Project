using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueStructure : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private float textSpeed;
    private int index;
    private int wordIndex;
    public ArrayList dialogue = new ArrayList();
    public ArrayList isPrompt = new ArrayList();
    private string currentNode;
    private bool currentPrompt;
    
    void Start()
    {
        textSpeed = .08f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPrompt)
        {
            if (Input.GetMouseButtonDown(0))
            {
                wordIndex = TMP_TextUtilities.FindIntersectingLine(textComponent, Input.mousePosition, null);
                if (wordIndex != -1)
                {
                    index += wordIndex;
                    NextLine();
                }
            }
        }
        else if (Input.GetKeyDown("space"))
        {
            if (index > dialogue.Count - 2)
            {
                textComponent.enabled = false;
            }
            else if (textComponent.text == currentNode)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = currentNode;
            }
        }
        
    }

    public void initializeVar(bool[] s, string[] d, TextMeshProUGUI t, int i) 
    {
        foreach (string str in d) 
        {
            dialogue.Add(str);
        }
        foreach (bool p in s) 
        {
            isPrompt.Add(p);
        }
        textComponent = t;
        index = i;
        StartDialogue();
    }
    
    public void StartDialogue()
    {
        textComponent.text = string.Empty;
        currentNode = (string) dialogue[0];
        currentPrompt = (bool) isPrompt[0];
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentNode.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        index++;
        currentNode = (string) dialogue[index];
        currentPrompt = (bool) isPrompt[index];
        if (currentPrompt)
        {
            StopAllCoroutines();
            textComponent.text = currentNode;
        }
        else
        {
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
}
