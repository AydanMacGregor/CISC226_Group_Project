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
    public List<Node> prompts = new List<Node>();
    // Start is called before the first frame update
    void Start()
    {
        isprompts = new bool[] {false, false, true, false, true, true, true, false, false, false,
        true, true, true, true, true, true, true, true, true, false, false, false, true, true, true, false, false, false};
        listoftext = new string[] {"Where... where am I? What happened? Am I dead?",
        "No... no, that can't be, I can't be dead?! I'm the Grim Reaper God Dammit!",
        "- Hello Tod.",
        "Who is there? Where am I? What is happening!?",
        "- You're dead Tod.",
        "- Don't worry about who I am.",
        "- You're not dead, you're on a new assignment.",
        "How did I die? How do you know me and who are you?!",
        "What do you mean? Answer me!",
        "Why? Who are you? How did I get here?",
        "- You have reached the end.",
        "- You're here to ammend your grief.",
        "- That information is of no importance.",
        "- Do not be afraid, I am here to help.",
        "- You are in a new relm.",
        "- Stop asking questions.",
        "- You are here to make amens with your actions.",
        "- I am you, Tod.",
        "- I am of no concern, refrain from questioning me.",
        "Are you always this criptic? What is going on!",
        "If you just answered my questions I would be at ease!",
        "What? You are making no sense.",
        "- Happy Reaping Tod.",
        "- You will find what you seek.",
        "- Answers in time.",
        "If you won't answer me, I guess I'll have to find answers myself.",
        "How about I seek you?",
        "I have to get out of here."};


        ds = GameObject.FindWithTag("DialogueSystem");
        for (int i = 0; i < isprompts.Length; i++)
        {
            prompts.Add(new Node(listoftext[i], isprompts[i]));
        }

        prompts[0].setNode(prompts[1]);
        prompts[1].setNode(prompts[2]);
        prompts[2].setNode(prompts[3]);
        prompts[3].setNode(prompts[4]);

        prompts[4].setPrompt(prompts[5], prompts[6]);

        prompts[4].setNode(prompts[7]);
        prompts[5].setNode(prompts[8]);
        prompts[6].setNode(prompts[9]);

        prompts[7].setNode(prompts[10]);
        prompts[10].setNode(prompts[19]);
        prompts[11].setNode(prompts[19]);
        prompts[12].setNode(prompts[19]);
        prompts[10].setPrompt(prompts[11], prompts[12]);

        prompts[8].setNode(prompts[13]);
        prompts[13].setNode(prompts[20]);
        prompts[14].setNode(prompts[20]);
        prompts[15].setNode(prompts[20]);
        prompts[13].setPrompt(prompts[14], prompts[15]);

        prompts[9].setNode(prompts[16]);
        prompts[16].setNode(prompts[21]);
        prompts[17].setNode(prompts[21]);
        prompts[18].setNode(prompts[21]);
        prompts[16].setPrompt(prompts[17], prompts[18]);


        prompts[19].setNode(prompts[22]);

        prompts[20].setNode(prompts[23]);

        prompts[21].setNode(prompts[24]);

        prompts[22].setNode(prompts[25]);

        prompts[23].setNode(prompts[26]);

        prompts[24].setNode(prompts[27]);


        ds.GetComponent<DialogueStructure>().initializeVar(prompts, tmpro);
    }

}
