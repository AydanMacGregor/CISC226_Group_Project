using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class control : MonoBehaviour
{
    List<GameObject> obj = new List<GameObject>();
    private int offset = 10;
    private int check = 12;
    private int counter = 20;
    private GameObject tod;
    public GameObject acceptance;
    public GameObject acceptanceFinal;
    private float acceptanceFinalOffset = 9.5f;
    public TextMeshProUGUI currentText;
    private bool final = false;

    void Start()
    {
        tod = GameObject.FindWithTag("Tod");
        obj.Add(Instantiate(acceptance, new Vector3(0f,0f,0f), Quaternion.identity));
        obj.Add(Instantiate(acceptance, new Vector3(0f,10f,0f), Quaternion.identity));
        obj.Add(Instantiate(acceptance, new Vector3(0f,20f,0f), Quaternion.identity));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!currentText.enabled && !final)
        {
            final = true;
            obj.Add(Instantiate(acceptanceFinal, new Vector3(0f,(float)counter + acceptanceFinalOffset,0f), Quaternion.identity));
            Destroy(this.gameObject);
        }
        else if (tod.transform.position.y >= check && !final)
        {
            check += offset;
            counter += offset;
            Destroy(obj[0]);
            obj.RemoveAt(0);
            obj.Add(Instantiate(acceptance, new Vector3(0f,(float)counter,0f), Quaternion.identity));
        }
    }
}
