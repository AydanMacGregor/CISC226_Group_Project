using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class construct : MonoBehaviour
{
    public GameObject beamLine;
    private Transform t;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindWithTag("DenialBoss");
        //beamLine = GameObject.FindWithTag("BeamLine");
        t = this.transform;
        for (int i = 2; i < 30; i+=2)
        {
            GameObject up = GameObject.Instantiate(beamLine, new Vector3(t.position.x, t.position.y + i, -2), Quaternion.identity);
            up.GetComponent<moveWithBoss>().rotation = new Vector2(0, i);
            GameObject down = GameObject.Instantiate(beamLine, new Vector3(t.position.x, t.position.y - i, -2), Quaternion.identity);
            down.GetComponent<moveWithBoss>().rotation = new Vector2(0, i * -1);
            GameObject right = GameObject.Instantiate(beamLine, new Vector3(t.position.x + i, t.position.y, -2), Quaternion.identity);
            right.GetComponent<Transform>().Rotate(0,0,90);
            right.GetComponent<moveWithBoss>().rotation = new Vector2(i, 0);
            GameObject left = GameObject.Instantiate(beamLine, new Vector3(t.position.x - i, t.position.y, -2), Quaternion.identity);
            left.GetComponent<Transform>().Rotate(0,0,90);
            left.GetComponent<moveWithBoss>().rotation = new Vector2(i * -1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        t.position = new Vector3(boss.transform.position.x, boss.transform.position.y, -1);
    }
}
