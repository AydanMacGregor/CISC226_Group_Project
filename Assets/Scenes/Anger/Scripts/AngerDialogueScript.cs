using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngerDialogueScript : MonoBehaviour
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
        listoftext = new string[] {"Stop! Stop doing this to me!",
        "I will not go on any longer! I will make sure you burn in hell.",
        "- You must continue.",
        "- You cannot harm me.",
        "- You will continue Tod.",
        "No, I must go back to my work.",
        "I will not go on!",
        "Oh I'll find a way.",
        "You will feel a world of pain never experienced before.",
        "And when I am done with you I can finally leave.",
        "Nope, give me answers or I will come for you.",
        "Tell me why I am here or you won't live to tell this story.",
        "And Once you're a corpse I'll finally get the hell out of here.",
        "- This is not an option.",
        "- This is not your choice.",
        "- You cannot go back.",
        "- Threats will not work.",
        "- You cannot touch me.",
        "- You may try.",
        "- You cannot leave just yet.",
        "- You will not leave.",
        "- You cannot kill me.",
        "Why should I keep going?",
        "You're not in control remember? I can disobey you.",
        "I will, whether you like it or not.",
        "- I have already answered this.",
        "- You cannot stop.",
        "- Reasons beyond your comprehension.",
        "- Trust you are on the right path.",
        "- You will not break free.",
        "- You will listen eventually.",
        "- You cannot Tod.",
        "- Not up to you.",
        "- Listen to me Tod.",
        "It's not a threat! I've brought billions to their graves.",
        "What's one more?",
        "You will feel my scythe on your neck.",
        "Oh I will. It won't be pretty.",
        "Do you even know who I am? Who are you?",
        "- I cannot be slain.",
        "- You are the one in their grave.",
        "- Try.",
        "- I am not mortal.",
        "- Do not threaten me.",
        "- Just follow my words.",
        "- I am ascended.",
        "- I know who you are.",
        "- I am no one.",
        "I will and you can't stop me!",
        "Yeah, and I won't kill you on my way out. You're funny.",
        "I will, you are only one of billions I've brought six feet under.",
        "- I am.",
        "- I can.",
        "- I will.",
        "- You cannot kill me.",
        "- There is no way out.",
        "- Continue on Tod.",
        "- I am not human.",
        "- Your scythe has no effect.",
        "- Your threats are null.",
        "I'm going to find you. When I do you'll wish you never trapped me here!",
        "- Do not get angry Tod. Save your energy.",
        "You have sealed your fate."};


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
