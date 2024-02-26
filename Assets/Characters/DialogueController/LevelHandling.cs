using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelHandling : MonoBehaviour
{
    TextMeshProUGUI currentText;
    private GameObject ds;
    private bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        currentText = (TextMeshProUGUI)FindObjectOfType(typeof(TextMeshProUGUI));
        ds = GameObject.FindWithTag("DialogueSystem");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        string world = "";
        if (collider.gameObject.layer == LayerMask.NameToLayer("Tod"))
        {
            string current = SceneManager.GetActiveScene().name;
            currentText.enabled = true;
            List<Node> l = new List<Node>();
            if (current == "DenialScene")
            {
                l.Add(new Node("Where does this lead to?", false));
                world = "DenialBossFloor";
                StartCoroutine(SwitchWorlds(world));
            }
            else if (current == "DenialBossFloor")
            {
                l.Add(new Node("Wow, hold on who is this?", false));
                l.Add(new Node("Stop making me fight people!", false));
                l[0].setNode(l[1]);
            }
            ds.GetComponent<DialogueStructure>().initializeVar(l, currentText);
            hit = true;
        }
    }

    void Update()
    {
        if (!currentText.enabled && hit)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SwitchWorlds(string w)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(w);
    }
}
