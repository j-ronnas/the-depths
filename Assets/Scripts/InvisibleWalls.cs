using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWalls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (MeshRenderer item in GetComponentsInChildren<MeshRenderer>())
        {
            item.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
