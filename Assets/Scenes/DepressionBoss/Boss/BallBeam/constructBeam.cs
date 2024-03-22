using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constructBeam : MonoBehaviour
{
    public GameObject beamLine;
    private Transform t;
    
    void Start()
    {
        Destroy(this.gameObject, 3f);
        t = this.transform;
        for (int i = 1; i < 30; i++)
        {
            GameObject up = GameObject.Instantiate(beamLine, new Vector3(t.position.x + 0.025f, t.position.y + i  + 0.02f, -1), Quaternion.identity);
            up.GetComponent<moveWithBall>().rotation = new Vector2(0, i);
            GameObject down = GameObject.Instantiate(beamLine, new Vector3(t.position.x + 0.025f, t.position.y - i + 0.02f, -1), Quaternion.identity);
            down.GetComponent<moveWithBall>().rotation = new Vector2(0, i * -1);
            GameObject right = GameObject.Instantiate(beamLine, new Vector3(t.position.x + i + 0.025f, t.position.y + 0.02f, -1), Quaternion.identity);
            right.GetComponent<Transform>().Rotate(0,0,90);
            right.GetComponent<moveWithBall>().rotation = new Vector2(i, 0);
            GameObject left = GameObject.Instantiate(beamLine, new Vector3(t.position.x - i + 0.025f, t.position.y + 0.02f, -1), Quaternion.identity);
            left.GetComponent<Transform>().Rotate(0,0,90);
            left.GetComponent<moveWithBall>().rotation = new Vector2(i * -1, 0);
        }
    }
}
