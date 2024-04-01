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
    public GameObject tod;
    // Start is called before the first frame update
    void Start()
    {
        isprompts = new bool[] {false, false, true, false, true, true, true, false, false, false,
        true, true, true, true, true, true, true, true, true, false, false, false, true, true, true, false, false, false};
        listoftext = new string[] {"W-where am I? What happened?\n\n\nSpace to Continue",
        "Hello? I know you’re there, I know you’re watching me!",
        "- Hello Tod. +1\n(+1) Time it will take for Tod to fight back.\nClick Text to Continue",
        "Where are you? Reveal yourself!",
        "- You have passed on.",
        "- I saw your grave.",
        "- Do not worry about who I am.",
        "Passed like dead? I can’t be dead!",
        "That’s not my grave, I’m still alive….",
        "How can I not? Tell me who you are!",
        "- I saw your name on the grave.",
        "- You are here to make amends.",
        "- You are dead Tod.",
        "- I am here to guide you.",
        "- You are not immortal.",
        "- No you are not Tod.",
        "- You are here to make amends.",
        "- I am of no concern to you.",
        "- No.",
        "Why are you so cryptic?",
        "I am alive, why are you lying?!",
        "You need to tell me the truth.",
        "- You are in denial, Tod.",
        "- I am not lying.",
        "- Answers in time.",
        "If you won't answer me, I guess I'll have to find answers myself.",
        "I have to get out of here.",
        "Fine."};

        if (tod.GetComponent<NovelIdea>().getTime() > 0f)
        {
            listoftext[0] = "W-where am I? What happened?\n\n\nRight Click to Skip Dialogue";
            listoftext[2] = "- Hello Tod.";
        }


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
