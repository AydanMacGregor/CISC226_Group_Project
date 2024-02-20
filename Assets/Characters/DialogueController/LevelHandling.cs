using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelHandling : MonoBehaviour
{
    TextMeshProUGUI currentText;
    private GameObject ds;
    // Start is called before the first frame update
    void Start()
    {
        currentText = (TextMeshProUGUI)FindObjectOfType(typeof(TextMeshProUGUI));
        ds = GameObject.FindWithTag("DialogueSystem");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Tod"))
        {
            currentText.enabled = true;
            List<Node> l = new List<Node>();
            l.Add(new Node("Where does this lead to?", false));
            ds.GetComponent<DialogueStructure>().initializeVar(l, currentText);
            StartCoroutine(SwitchWorlds());
        }
    }

    IEnumerator SwitchWorlds()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("DenialBossFloor");
    }
}
