using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int SpawnIndex;

    [SerializeField]
    GameObject playerGO;

    public int rotatingPillarMode = 3;

    public bool[] lockedDoorStates = new bool[6];

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        FindObjectOfType<FPSController>().enabled = true;
        FindObjectOfType<FPSCameraController>().enabled = true;
        FindObjectOfType<SpawnLocation>().SpawnPlayer();

        SceneManager.sceneLoaded += OnSceneLoaded;


        lockedDoorStates[0] = true;
        lockedDoorStates[1] = true;
        lockedDoorStates[2] = false;
        lockedDoorStates[3] = false;
        lockedDoorStates[4] = false;
        lockedDoorStates[5] = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindObjectOfType<FPSController>().enabled = true;
        FindObjectOfType<FPSCameraController>().enabled = true;
        FindObjectOfType<SpawnLocation>().SpawnPlayer();

        GameObject menu = GameObject.Find("MainMenu");
        if(menu!= null)
        {
            menu.SetActive(false);
        }


    }

}
