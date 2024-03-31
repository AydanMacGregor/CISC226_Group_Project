using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AcceptanceDialogueScript : MonoBehaviour
{
    private string[] listoftext;
    private bool[] isprompts;
    private GameObject ds;
    public TextMeshProUGUI tmpro;
    public List<Node> prompts = new List<Node>();

    void Start()
    {
        isprompts = new bool[] {false, false, true, false, true, false, true, false};
        listoftext = new string[] {"Why is it so bright? Where are all the souls?",
        "Please tell me I’m done. Am I finally going to get answers?",
        "- Yes, you have overcome your grief.",
        "Why have you been cryptic with me?",
        "- This was an odyssey Tod. Your journey through grief has come to an end.",
        "My grief? Odyssey? What do you mean? You told me I died a long time ago.",
        "-Go see for yourself.",
        "Ok."
        };


        ds = GameObject.FindWithTag("DialogueSystem");
        for (int i = 0; i < isprompts.Length; i++)
        {
            prompts.Add(new Node(listoftext[i], isprompts[i]));
        }

        prompts[0].setNode(prompts[1]);
        prompts[1].setNode(prompts[2]);
        prompts[2].setNode(prompts[3]);
        prompts[3].setNode(prompts[4]);
        prompts[4].setNode(prompts[5]);
        prompts[5].setNode(prompts[6]);
        prompts[6].setNode(prompts[7]);

        ds.GetComponent<DialogueStructure>().initializeVar(prompts, tmpro);
    }
}
