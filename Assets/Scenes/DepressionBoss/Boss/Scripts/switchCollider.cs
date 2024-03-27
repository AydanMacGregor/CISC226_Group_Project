using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCollider : MonoBehaviour
{

    public PolygonCollider2D one;
    public PolygonCollider2D two;

    // Update is called once per frame
    public void UpdateCollider()
    {
        one.enabled = one.enabled ? false : true;
        two.enabled = two.enabled ? false : true;
    }
}
