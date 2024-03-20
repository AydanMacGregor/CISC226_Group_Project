using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainMoveWithBoss : MonoBehaviour
{
    public GameObject boss;
    private Transform t;
    public Vector2 rotation;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindWithTag("DenialBoss");
        t = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        t.position = new Vector3(boss.transform.position.x + rotation.x, boss.transform.position.y + rotation.y, -2);
    }
}
