using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constructBeam : MonoBehaviour
{
    public GameObject beamLine;
    private Transform t;
    
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }
}
