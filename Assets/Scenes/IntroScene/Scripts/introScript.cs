using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class introScript : MonoBehaviour
{
    private string introD = "You are an omniscient being\n\nTod is the Grim Reaper\n\nTod has passed away\n\nYou must guide him through his grief\n\nTake care of how you talk to him\n\nTod can fight against you.\n\nSpace to Continue";
    public TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in introD.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(.10f);
        }
    }
}
