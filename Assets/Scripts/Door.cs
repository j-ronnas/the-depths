using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public int ID;


    Vector3 startPos;
    Vector3 endPos;
    [SerializeField]
    float moveDis = 2f;


    [SerializeField]
    float animationTime = 0.8f;

    [SerializeField]
    int leadsToScene = -1;
    [SerializeField]
    int spawnIndex;


    GameObject soundEffect;
    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + transform.right * moveDis;

        GetComponent<Interactable>().onInteraction += Open;

        soundEffect = Resources.Load<GameObject>("SoundPrefabs/slide_door");

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void Open()
    {
        Debug.Log("Door id: " + ID);
        Debug.Log(FindObjectOfType<GameManager>().lockedDoorStates[ID]);
        if (FindObjectOfType<GameManager>().lockedDoorStates[ID])
        {
            FindObjectOfType<UIMessage>().Display();
            return;
        }
        t = 0;
        Instantiate(soundEffect);
        StartCoroutine(OpenAnimation());
    }

    void OnOpenFinish()
    {
        if(leadsToScene < 0)
        {
            return;
        }
        FindObjectOfType<GameManager>().SpawnIndex = spawnIndex;
        SceneManager.LoadScene(leadsToScene);
    }
    float t=0;
    IEnumerator OpenAnimation()
    {
        Debug.Log("In coroutine");
        while (t < animationTime)
        {
            Debug.Log("Running");
            transform.position = Vector3.Lerp(startPos, endPos, t / animationTime);
            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        OnOpenFinish();
    }
}
