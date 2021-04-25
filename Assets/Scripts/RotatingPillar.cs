using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPillar : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        SetRotation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRotation()
    {
        int i = FindObjectOfType<GameManager>().rotatingPillarMode;
        transform.rotation = Quaternion.Euler(new Vector3(0, 90 * i, 0));
    }
}
