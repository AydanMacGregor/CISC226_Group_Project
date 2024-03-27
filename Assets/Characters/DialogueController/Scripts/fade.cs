using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fade : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    Color col;
    private bool canFade = false;
    // Start is called before the first frame update
    void Start()
    {
        col = textComponent.color;
        StartCoroutine(delayFade());
    }

    IEnumerator delayFade()
    {
        yield return new WaitForSeconds(8f);
        canFade = true;
    }

    void Update()
    {
        if (canFade)
        {
            if (col.a > 0)
            {
                col.a-=Time.deltaTime;
                textComponent.color=col;
            }
        }
    }
}
