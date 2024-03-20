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
            GameObject up = GameObject.Instantiate(ExtendLine, new Vector3(t.position.x, t.position.y + i, -2), Quaternion.identity);
            up.GetComponent<moveWithBoss>().rotation = new Vector2(0, i);
            GameObject down = GameObject.Instantiate(ExtendLine, new Vector3(t.position.x, t.position.y - i, -2), Quaternion.identity);
            down.GetComponent<moveWithBoss>().rotation = new Vector2(0, i * -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        t.position = new Vector3(boss.transform.position.x, boss.transform.position.y, -1);
    }
}
