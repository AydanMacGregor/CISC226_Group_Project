using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class control : MonoBehaviour
{
    List<GameObject> obj = new List<GameObject>();
    List<GameObject> objTod = new List<GameObject>();
    private int offset = 10;
    private int check = 12;
    private int counter = 20;
    private GameObject tod;
    public GameObject acceptance;
    public GameObject acceptanceFinal;
    private float acceptanceFinalOffset = 9.5f;
    public TextMeshProUGUI currentText;
    private bool final = false;
    public GameObject todblockers;
    public GameObject finalTrigger;
    public bool finalBlocker = false;
    public GameObject grave;
    public GameObject checkP;

    void Start()
    {
        tod = GameObject.FindWithTag("Tod");
        objTod.Add(Instantiate(todblockers, new Vector3(-4.5f,0f,0f), Quaternion.identity));
        objTod.Add(Instantiate(todblockers, new Vector3(4.5f,0f,0f), Quaternion.identity));

        objTod.Add(Instantiate(todblockers, new Vector3(-4.5f,10f,0f), Quaternion.identity));
        objTod.Add(Instantiate(todblockers, new Vector3(4.5f,10f,0f), Quaternion.identity));

        objTod.Add(Instantiate(todblockers, new Vector3(-4.5f,20f,0f), Quaternion.identity));
        objTod.Add(Instantiate(todblockers, new Vector3(4.5f,20f,0f), Quaternion.identity));

        obj.Add(Instantiate(acceptance, new Vector3(0f,0f,0f), Quaternion.identity));
        obj.Add(Instantiate(acceptance, new Vector3(0f,10f,0f), Quaternion.identity));
        obj.Add(Instantiate(acceptance, new Vector3(0f,20f,0f), Quaternion.identity));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (finalBlocker)
        {
            objTod.Add(Instantiate(todblockers, new Vector3(0f,(float)counter + acceptanceFinalOffset-4f,0f), Quaternion.identity));
            objTod[objTod.Count-1].transform.localScale = new Vector3(1,20,1);
            objTod[objTod.Count-1].transform.Rotate(0, 0, -90);
            Destroy(this.gameObject);
        }
        if (!currentText.enabled && !final)
        {
            final = true;
            objTod.Add(Instantiate(todblockers, new Vector3(7.5f,(float)counter + acceptanceFinalOffset,0f), Quaternion.identity));
            objTod.Add(Instantiate(todblockers, new Vector3(-7.5f,(float)counter + acceptanceFinalOffset,0f), Quaternion.identity));

            Instantiate(finalTrigger, new Vector3(0f,(float)counter + acceptanceFinalOffset-4f,0f), Quaternion.identity);

            objTod.Add(Instantiate(todblockers, new Vector3(-6f,(float)counter + acceptanceFinalOffset-4f,0f), Quaternion.identity));
            objTod.Add(Instantiate(todblockers, new Vector3(6f,(float)counter + acceptanceFinalOffset-4f,0f), Quaternion.identity));
            objTod.Add(Instantiate(todblockers, new Vector3(0f,(float)counter + acceptanceFinalOffset+4f,0f), Quaternion.identity));
            objTod[objTod.Count-3].transform.localScale = new Vector3(1,4,1);
            objTod[objTod.Count-2].transform.localScale = new Vector3(1,4,1);
            objTod[objTod.Count-1].transform.localScale = new Vector3(1,20,1);
            objTod[objTod.Count-3].transform.Rotate(0, 0, -90);
            objTod[objTod.Count-2].transform.Rotate(0, 0, -90);
            objTod[objTod.Count-1].transform.Rotate(0, 0, -90);
            
            obj.Add(Instantiate(acceptanceFinal, new Vector3(0f,(float)counter + acceptanceFinalOffset,0f), Quaternion.identity));
            obj.Add(Instantiate(grave, new Vector3(0f,(float)counter + acceptanceFinalOffset,-1f), Quaternion.identity));
            obj.Add(Instantiate(checkP, new Vector3(0f,(float)counter + acceptanceFinalOffset,-1f), Quaternion.identity));
        }
        else if (tod.transform.position.y >= check && !final)
        {
            check += offset;
            counter += offset;
            Destroy(obj[0]);
            obj.RemoveAt(0);
            obj.Add(Instantiate(acceptance, new Vector3(0f,(float)counter,0f), Quaternion.identity));
            Destroy(objTod[0]);
            Destroy(objTod[1]);
            objTod.RemoveAt(0);
            objTod.RemoveAt(0);
            objTod.Add(Instantiate(todblockers, new Vector3(4.5f,(float)counter,0f), Quaternion.identity));
            objTod.Add(Instantiate(todblockers, new Vector3(-4.5f,(float)counter,0f), Quaternion.identity));
        }
    }
}
