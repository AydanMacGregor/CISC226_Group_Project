using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainConstruct : MonoBehaviour
{
    public GameObject ExtendLine;
    private Transform t;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindWithTag("BargainingBoss");
        t = this.transform;
        for (int i = 2; i < 30; i += 2)
        {
            GameObject right = GameObject.Instantiate(ExtendLine, new Vector3(t.position.x + i, t.position.y, -2), Quaternion.identity);
            right.GetComponent<Transform>().Rotate(0, 0, 90);
            right.GetComponent<moveWithBoss>().rotation = new Vector2(i, 0);
            GameObject left = GameObject.Instantiate(ExtendLine, new Vector3(t.position.x - i, t.position.y, -2), Quaternion.identity);
            left.GetComponent<Transform>().Rotate(0, 0, 90);
            left.GetComponent<moveWithBoss>().rotation = new Vector2(i * -1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        t.position = new Vector3(boss.transform.position.x, boss.transform.position.y, -1);
    }
}
