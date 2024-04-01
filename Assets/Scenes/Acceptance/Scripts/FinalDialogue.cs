using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalDialogue : MonoBehaviour
{
    private string[] listoftext;
    private bool[] isprompts;
    private GameObject ds;
    public TextMeshProUGUI tmpro;
    public List<Node> prompts = new List<Node>();
    public bool canStart = false;

    void Update()
    {
        if (canStart)
        {
            canStart = false;
            isprompts = new bool[] {false, true, false, true, false, true, false, true, false, true, false, true, false};
            listoftext = new string[] {"So this is it? What comes next?",
            "- That’s up to you Tod. What awaits is your peace.",
            "But who is going to move souls from the mortal realm?",
            "- That is not your concern, you are not the first Reaper to pass through my odyssey and you will not be the last.",
            "Who are you?",
            "- Your guide, who you no longer need.",
            "What do I do now ?",
            "-Whatever you want Tod, my time with you is almost over.",
            "Is this what the afterlife is?",
            "-Yes, you are now at peace.",
            "Thank you. I’m sorry for being difficult.",
            "-Your journey is now over, you can pass on, your soul is at rest.",
            "Thank you."
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
            prompts[7].setNode(prompts[8]);
            prompts[8].setNode(prompts[9]);
            prompts[9].setNode(prompts[10]);
            prompts[10].setNode(prompts[11]);
            prompts[11].setNode(prompts[12]);


            ds.GetComponent<DialogueStructure>().initializeVar(prompts, tmpro);
        }
    }
}
