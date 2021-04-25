using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        int index = FindObjectOfType<GameManager>().SpawnIndex;
        if (index > transform.childCount)
        {
            Debug.LogError("Spawn INdex out of range");
        }
        GameObject player = FindObjectOfType<FPSController>().gameObject;
        player.transform.position = transform.GetChild(index).position;
        player.transform.rotation = transform.GetChild(index).rotation;
    }
}
