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
    private string current;
    private bool bossDead = false;
    // Start is called before the first frame update
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
                StartCoroutine(SwitchWorlds(current));
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
        if (GameObject.Find("Boss") == null && !bossDead)
        {
            bossDead = true;
            StartCoroutine(SwitchWorlds("BargainingScene"));
        }
    }

    IEnumerator SwitchWorlds(string w)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(w);
    }
}
