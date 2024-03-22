using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithBall : MonoBehaviour
{
    public GameObject ball;
    private Transform t;
    public Vector2 rotation;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3f);
        ball = GameObject.Find("StressBallProjectile(Clone)");
        t = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        t.position = new Vector3(ball.transform.position.x + rotation.x  + 0.025f, ball.transform.position.y + rotation.y + 0.02f, -1);
    }
}
