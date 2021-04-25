using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonComponent : MonoBehaviour
{

    public bool isPressed = false;
    [SerializeField]
    GameObject buttonGO;

    public ButtonPuzzle bp;

    GameObject soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Interactable>().onInteraction += TogglePress;
        soundEffect = Resources.Load<GameObject>("SoundPrefabs/buttonPress");
        Debug.Log(soundEffect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePress()
    {
        isPressed = !isPressed;
        if (isPressed)
        {
            buttonGO.transform.position += transform.up * -0.02f;
            buttonGO.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        }
        else
        {
            buttonGO.transform.position += transform.up * 0.02f;
            buttonGO.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        }

        Instantiate(soundEffect);

        bp.CheckSolution();
        
    }
}
