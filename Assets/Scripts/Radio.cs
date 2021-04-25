using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    GameObject soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        soundEffect = Resources.Load<GameObject>("SoundPrefabs/RadioSound");
        GetComponent<Interactable>().onInteraction += OnRadio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRadio()
    {
        Instantiate(soundEffect);
    }
}
