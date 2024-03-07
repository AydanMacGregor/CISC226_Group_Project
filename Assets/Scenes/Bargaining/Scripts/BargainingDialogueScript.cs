using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BargainingDialogueScript : MonoBehaviour
{
    private string[] listoftext;
    private bool[] isprompts;
    private GameObject ds;
    public TextMeshProUGUI tmpro;
    public List<Node> prompts = new List<Node>();
    // Start is called before the first frame update
    void Start()
    {
        isprompts = new bool[] {false, false, true, true, true, false, false, false, false, false, false, false, false, true, true, true,
        true, true, true, true, true, true, false, false, false, true, true, true, true, true, true, true, true, true, false, false,
        false, false, false, true, true, true, true, true, true, true, true, true, false, false, false, true, true, true, true, true,
        true, true, true, true, false, true, false};
        listoftext = new string[] {"What was that?!",
        "Can you please tell me what is going on!",
        "- You will be safe.",
        "- I told you not to worry.",
        "- No.",
        "Oh that's reassuring.",
        "Please just let me out of here!",
        "Not to worry? What?!",
        "How can I not! Things are trying to kill me!",
        "I beg you, tell me what is going on!",
        "What do you mean?!",
        "Why can't you just tell me?!",
        "How can I convince you to let me leave?",
        "- You know I cannot do that.",
        "- You need to make amens first.",
        "- No.",
        "- You will be ok, keep going.",
        "- I cannot.",
        "- I will not.",
        "- Keep going Tod.",
        "- You need to finish first.",
        "- You are not leaving.",
        "What do you want from me?!",
        "Amens for what?",
        "Stop! Just answer me!",
        "- I do not want anything.",
        "- You tell me.",
        "- For you to keep going.",
        "- In time.",
        "- Your past.",
        "- You know what.",
        "- Later Tod.",
        "- Answers will come.",
        "Do not question me.",
        "You really know how to sweet talk.",
        "Let me leave and I can spare you.",
        "Yes you can, just tell me.",
        "Of course you won't.",
        "You love being difficult.",
        "- That will not work on me.",
        "- Sure you can.",
        "- I do not need sparing.",
        "- Later.",
        "- Asking will not work.",
        "- I will not.",
        "- You will be fine Tod.",
        "- I am not.",
        "- Believe what you want.",
        "Why? What's at the end?",
        "Why wont you just let me leave?",
        "You won't tell me, I won't move.",
        "- Nothing.",
        "- Do not worry about it.",
        "- You will find out.",
        "- You will be fine.",
        "- I cannot.",
        "- You are not leaving.",
        "- Keep going, you will be fine.",
        "- Just move.",
        "- Yes you will.",
        "Please.",
        "- I am not bargaining with you Tod.",
        "Just let me out."};


        ds = GameObject.FindWithTag("DialogueSystem");
        for (int i = 0; i < isprompts.Length; i++)
        {
            prompts.Add(new Node(listoftext[i], isprompts[i]));
        }

        prompts[0].setNode(prompts[1]);
        prompts[1].setNode(prompts[2]);

        prompts[2].setPrompt(prompts[3], prompts[4]);

        prompts[2].setNode(prompts[5]);
        prompts[5].setNode(prompts[6]);
        prompts[6].setNode(prompts[13]);

        prompts[13].setPrompt(prompts[14], prompts[15]);
        prompts[13].setNode(prompts[22]);
        prompts[14].setNode(prompts[23]);
        prompts[15].setNode(prompts[24]);

        prompts[22].setNode(prompts[25]);
        prompts[25].setPrompt(prompts[26], prompts[27]);
        prompts[25].setNode(prompts[60]);
        prompts[26].setNode(prompts[60]);
        prompts[27].setNode(prompts[60]);

        prompts[23].setNode(prompts[28]);
        prompts[28].setPrompt(prompts[29], prompts[30]);
        prompts[28].setNode(prompts[60]);
        prompts[29].setNode(prompts[60]);
        prompts[30].setNode(prompts[60]);

        prompts[24].setNode(prompts[31]);
        prompts[31].setPrompt(prompts[32], prompts[33]);
        prompts[31].setNode(prompts[60]);
        prompts[32].setNode(prompts[60]);
        prompts[33].setNode(prompts[60]);


        prompts[3].setNode(prompts[7]);

        prompts[7].setNode(prompts[8]);
        prompts[8].setNode(prompts[9]);
        prompts[9].setNode(prompts[16]);

        prompts[16].setPrompt(prompts[17], prompts[18]);
        prompts[16].setNode(prompts[34]);
        prompts[17].setNode(prompts[36]);
        prompts[18].setNode(prompts[37]);

        prompts[34].setNode(prompts[35]);
        prompts[35].setNode(prompts[39]);
        prompts[39].setPrompt(prompts[40], prompts[41]);
        prompts[39].setNode(prompts[60]);
        prompts[40].setNode(prompts[60]);
        prompts[41].setNode(prompts[60]);

        prompts[36].setNode(prompts[42]);
        prompts[42].setPrompt(prompts[43], prompts[44]);
        prompts[42].setNode(prompts[60]);
        prompts[43].setNode(prompts[60]);
        prompts[44].setNode(prompts[60]);

        prompts[37].setNode(prompts[38]);
        prompts[38].setNode(prompts[45]);
        prompts[45].setPrompt(prompts[46], prompts[47]);
        prompts[45].setNode(prompts[60]);
        prompts[46].setNode(prompts[60]);
        prompts[47].setNode(prompts[60]);



        prompts[4].setNode(prompts[10]);

        prompts[10].setNode(prompts[11]);
        prompts[11].setNode(prompts[12]);
        prompts[12].setNode(prompts[19]);

        prompts[19].setPrompt(prompts[20], prompts[21]);
        prompts[19].setNode(prompts[48]);
        prompts[20].setNode(prompts[49]);
        prompts[21].setNode(prompts[50]);

        prompts[48].setNode(prompts[51]);
        prompts[51].setPrompt(prompts[52], prompts[53]);
        prompts[51].setNode(prompts[60]);
        prompts[52].setNode(prompts[60]);
        prompts[53].setNode(prompts[60]);

        prompts[49].setNode(prompts[54]);
        prompts[54].setPrompt(prompts[55], prompts[56]);
        prompts[54].setNode(prompts[60]);
        prompts[55].setNode(prompts[60]);
        prompts[56].setNode(prompts[60]);

        prompts[50].setNode(prompts[57]);
        prompts[57].setPrompt(prompts[58], prompts[59]);
        prompts[57].setNode(prompts[60]);
        prompts[58].setNode(prompts[60]);
        prompts[59].setNode(prompts[60]);

        prompts[60].setNode(prompts[61]);
        prompts[61].setNode(prompts[62]);


        ds.GetComponent<DialogueStructure>().initializeVar(prompts, tmpro);
    }
}
