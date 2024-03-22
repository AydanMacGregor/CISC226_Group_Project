using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelHandling : MonoBehaviour
{
    public TextMeshProUGUI currentText;
    private GameObject ds;
    private bool hit = false;
    private string current;
    private bool bossDead = false;
    
    void Start()
    {
        current = SceneManager.GetActiveScene().name;
        currentText = (TextMeshProUGUI)FindObjectOfType(typeof(TextMeshProUGUI));
        ds = GameObject.FindWithTag("DialogueSystem");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Tod"))
        {
            currentText.enabled = true;
            List<Node> l = new List<Node>();
            if (current == "DenialScene")
            {
                l.Add(new Node("Where does this lead to?", false));
                StartCoroutine(SwitchWorlds("DenialBossFloor", 3f));
            }
            else if (current == "DenialBossFloor")
            {
                hit = true;
                l.Add(new Node("Wow, hold on who is this?", false));
                l.Add(new Node("Stop making me fight people!", false));
                l[0].setNode(l[1]);
            }
            else if (current == "BargainingScene")
            {
                l.Add(new Node("Please not again, anything but this!", false));
                StartCoroutine(SwitchWorlds("BargainingBossFloor", 3f));
            }
            else if (current == "BargainingBossFloor")
            {
                hit = true;
                l.Add(new Node("I hate you.", false));
            }
            else if (current == "AngerScene")
            {
                hit = true;
                l.Add(new Node("Once I'm done with this person you're next you hear me!", false));
                StartCoroutine(SwitchWorlds("AngerBossFloor", 5f));
            }
            else if (current == "DepressionScene")
            {
                hit = true;
                l.Add(new Node("I don't think I can take another.", false));
                StartCoroutine(SwitchWorlds("DepressionBossFloor", 3f));
            }
            else if (current == "DepressionBossFloor")
            {
                hit = true;
                l.Add(new Node("Maybe I just stop fighting all together now.", false));
            }
            ds.GetComponent<DialogueStructure>().initializeVar(l, currentText);
        }
    }

    void Update()
    {
        if (!currentText.enabled && hit)
        {
            Destroy(gameObject);
        }
        if (GameObject.Find("Boss") == null && !bossDead && current == "DenialBossFloor")
        {
            bossDead = true;
            StartCoroutine(SwitchWorlds("BargainingScene", 3f));
        }
        if (GameObject.Find("Boss") == null && !bossDead && current == "BargainingBossFloor")
        {
            bossDead = true;
            StartCoroutine(SwitchWorlds("AngerScene", 3f));
        }
        if (GameObject.Find("DepressionBoss") == null && !bossDead && current == "DepressionBossFloor")
        {
            bossDead = true;
            StartCoroutine(SwitchWorlds("Acceptance", 3f));
        }
    }

    IEnumerator SwitchWorlds(string w, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(w);
    }
}
