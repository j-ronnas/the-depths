using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    public bool isPressed = false;
    [SerializeField]
    GameObject leverGO;

    public FinalPuzzle fp;

    GameObject soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        soundEffect = Resources.Load<GameObject>("SoundPrefabs/buttonPress");
        GetComponent<Interactable>().onInteraction += ToggleLever;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleLever()
    {
        isPressed = !isPressed;
        if (isPressed)
        {
            leverGO.transform.Rotate(new Vector3(60,0,0));
            
        }
        else
        {
            leverGO.transform.Rotate(new Vector3(-60, 0, 0));
            
        }
        fp.CheckSolution();

        Instantiate(soundEffect);
    }
}
