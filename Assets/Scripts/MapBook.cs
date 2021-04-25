using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBook : MonoBehaviour
{
    [SerializeField]
    GameObject uiMap;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Interactable>().onInteraction += ShowMap;
        //HideMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideMap();
        }
    }

    void ShowMap()
    {
        uiMap.SetActive(true);
        FindObjectOfType<FPSCameraController>().enabled = false;
        FindObjectOfType<FPSController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideMap()
    {
        uiMap.SetActive(false);
        FindObjectOfType<FPSCameraController>().enabled = true;
        FindObjectOfType<FPSController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
