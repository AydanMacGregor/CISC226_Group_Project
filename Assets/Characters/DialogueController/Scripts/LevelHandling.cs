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
                StartCoroutine(SwitchWorlds("DenialBossFloor"));
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
                StartCoroutine(SwitchWorlds("BargainingBossFloor"));
            }
            else if (current == "BargainingBossFloor")
            {
                hit = true;
                l.Add(new Node("I hate you.", false));
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
            StartCoroutine(SwitchWorlds("BargainingScene"));
        }
        if (GameObject.Find("Boss") == null && !bossDead && current == "BargainingBossFloor")
        {
            bossDead = true;
            StartCoroutine(SwitchWorlds("AngerScene"));
        }
    }

    IEnumerator SwitchWorlds(string w)
    {
        if (!currentText.enabled)
        {
            SceneManager.LoadScene(w);
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(w);
    }
}
