using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DenialDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private bool select;
    // Start is called before the first frame update
    void Start()
    {
        select = false;
        textSpeed = .08f;
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (select)
        {
            if (Input.GetMouseButtonDown(0))
            {
                int wordIndex = TMP_TextUtilities.FindIntersectingLine(textComponent, Input.mousePosition, null);
                if (wordIndex != -1)
                {
                    NextLine();
                    select = false;
                }
            }
        }
        else if (Input.GetKeyDown("space"))
        {
            if (index > lines.Length - 1)
            {
                textComponent.enabled = false;
            }
            else if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        index++;
        Debug.Log("Increase index to: " + index + " " + (lines.Length - 1));
        if ((index % 2) == 0 && index != 0 && index <= lines.Length - 1)
        {
            Debug.Log("Now start prompting");
            StopAllCoroutines();
            textComponent.text = lines[index];
            select = true;
        }
        else if (index <= lines.Length - 1)
        {
            Debug.Log("Tod Talking");
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
        
}
