using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkTod : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Tod")
        {
            other.gameObject.GetComponent<NovelIdea>().canStart = true;
        }
    }
}
