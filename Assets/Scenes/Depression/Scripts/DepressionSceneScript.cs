using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepressionSceneScript : MonoBehaviour
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
        listoftext = new string[] {"Please just let me leave, I can’t take it anymore.",
        "I'm so tired… All I want is to go home.",
        "- You are so close.",
        "- You cannot stop.",
        "- You must keep going Tod.",
        "Close to what?...What is even the point anymore.",
        "I can't go on, just give up on me.",
        "I have no reason to keep going.",
        "All you do is put me through pain.",
        "Just leave me be.",
        "I am not sure I can.",
        "You put me through hell and although I can fight back it seems hopeless.",
        "I can't and won't kill you, let me give up please.",
        "- You are almost done.",
        "- You must try.",
        "- That is not my decision.",
        "- I will not.",
        "- It was not my decision.",
        "- Just a little further.",
        "- Peace awaits you.",
        "- Answers are close.",
        "- Fight, Tod.",
        "Fine, let me die then.",
        "I can't go on, I don't want to go on.",
        "I have no reason to go on.",
        "- You cannot die again.",
        "- Continue and you will see.",
        "- A devine spot is waiting.",
        "- You can go on.",
        "- There is no other way.",
        "- You must.",
        "- You will soon.",
        "- Not previously.",
        "- You will in time.",
        "Then i guess I'll just waste away here.",
        "Rotting in my own hell",
        "How do you even know that?",
        "Please just spare me from your sadistic hell.",
        "Just let me go back to where I was happy.",
        "- Your heaven is near.",
        "- You cannot leave.",
        "- You stay you rot.",
        "- I just do.",
        "- I see your future.",
        "- I know all.",
        "- Happiness awaits you.",
        "- This is not my hell.",
        "- This is your doing.",
        "Then why does it feel like its getting farther away.",
        "They're always just out of reach.",
        "No. I don't have the energy to continue.",
        "- This is your last fight.",
        "- Peace comes from adversity.",
        "- You must fight.",
        "- You are close.",
        "- You do not need them.",
        "- By design.",
        "- You do.",
        "- Find it within.",
        "- That mindset is defeat.",
        "I thought I was bringing souls peace, but if this is peace then I am a monster.",
        "- Do not get depressed Tod. You will see the fruits of your labour soon.",
        "If you say so..."};


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
