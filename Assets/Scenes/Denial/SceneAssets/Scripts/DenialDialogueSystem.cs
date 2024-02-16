using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DenialDialogueSystem : MonoBehaviour
{
    private string[] listoftext;
    private bool[] isprompts;
    private GameObject ds;
    public TextMeshProUGUI tmpro;
    // Start is called before the first frame update
    void Start()
    {
        isprompts = new bool[] {false, false, true, false, false, false};
        listoftext = new string[] {"Where, where am I? What is happening? How did I get here? Did I die?", "No, that can't be, I can't be dead?! I'm the Grim Reaper God Dammit!", "This is a test<br>This is a test<br>This is a test", "you picked choice 1", "you picked choice 2", "you picked choice 3"};
        ds = GameObject.FindWithTag("DialogueSystem");
        ds.GetComponent<DialogueStructure>().initializeVar(isprompts, listoftext, tmpro, 0);
    }

}
