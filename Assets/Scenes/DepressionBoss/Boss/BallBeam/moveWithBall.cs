using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithBall : MonoBehaviour
{
    public GameObject ball;
    private Transform t;
    public Vector2 rotation;
    float timeRotate = 0.1f;
    float scale = 0f;
    float original;
    // Start is called before the first frame update
    void Start()
    {
        original = this.transform.rotation.eulerAngles.z;
        Destroy(this.gameObject, 4f);
        t = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRotate < 0)
        {
            this.transform.Rotate(0f,0f,0.5f);
            if (this.transform.localScale.y < 20)
            {
                this.transform.localScale = new Vector3(1,scale,1);
                scale += 0.25f;
            }
            timeRotate = 0.02f;
        }
        timeRotate -= Time.deltaTime;
    }
}
