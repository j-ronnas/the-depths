using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Elevator : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    float moveDis = 10f;
    [SerializeField]
    bool goingDown = true;

    float animationTime = 2.0f;
    // Start is called before the first frame update
    [SerializeField]
    GameObject elevatorGO;
    [SerializeField]
    Image fadeScreen;

    [SerializeField]
    int leadsToScene = -1;
    [SerializeField]
    int spawnIndex;
    [SerializeField]
    GameObject leverGO;


    GameObject soundEffect;
    
    void Start()
    {
        GetComponent<Interactable>().onInteraction += OnElevatorRide;
        startPos = elevatorGO.transform.position;
        endPos = goingDown ?  startPos + Vector3.down * moveDis : startPos + Vector3.up * moveDis;

        soundEffect = Resources.Load<GameObject>("SoundPrefabs/buttonPress");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnElevatorRide()
    {
        FPSController player = FindObjectOfType<FPSController>();
        player.enabled = false;

        player.transform.parent = elevatorGO.transform;

        leverGO.transform.rotation = Quaternion.Euler(new Vector3(60, 0, 0));

        soundEffect = Resources.Load<GameObject>("SoundPrefabs/buttonPress");

        StartCoroutine(ElevatorRide());
    }

    float t = 0;
    IEnumerator ElevatorRide()
    {

        while (t < animationTime)
        {
            Debug.Log("Running");
            elevatorGO.transform.position = Vector3.Lerp(startPos, endPos, t / animationTime);
            fadeScreen.color = Color.Lerp(Color.clear, Color.black, t / animationTime);
            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        OnOpenFinish();
        
    }

    void OnOpenFinish()
    {
        if (leadsToScene < 0)
        {
            return;
        }
        FindObjectOfType<GameManager>().SpawnIndex = 0;
        SceneManager.LoadScene(leadsToScene);
    }
}
