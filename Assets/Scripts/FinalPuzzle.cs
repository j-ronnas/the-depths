using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinalPuzzle : MonoBehaviour
{
    [SerializeField]
    LevelComponent[] levers;

    List<int> correctSolution = new List<int> { 0, 3,4};

    [SerializeField]
    GameObject lavaPlane;

    [SerializeField]
    GameObject endScreen;

    float animationTime = 6f;
    Vector3 startPos;
    Vector3 endPos;


    [SerializeField]
    Image fadeImage;
    GameObject soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levers.Length; i++)
        {
            levers[i].fp = this;
        }

        startPos = lavaPlane.transform.position;
        endPos = startPos + Vector3.down * 7f;

        soundEffect = Resources.Load<GameObject>("SoundPrefabs/FinalSoundEffect");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckSolution()
    {
        Debug.Log("Checkling solution!");

        bool isSolved = true;

        for (int i = 0; i < levers.Length; i++)
        {
            if (correctSolution.Contains(i))
            {
                isSolved = isSolved && levers[i].isPressed;
            }
            else
            {
                isSolved = isSolved && !levers[i].isPressed;
            }
        }

        Debug.Log(isSolved);
        if (isSolved)
        {
            FindObjectOfType<FPSController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            StartCoroutine(FinalAnimation());
            Instantiate(soundEffect);
            Debug.Log("GAME OVER");
        }
    }

    float t = 0;
    IEnumerator FinalAnimation()
    {
        while (t < animationTime)
        {
            Debug.Log("Running");
            lavaPlane.transform.position = Vector3.Lerp(startPos, endPos, t / animationTime);
            fadeImage.color = Color.Lerp(Color.clear, Color.black, t / animationTime);
            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        EndGame();
    }

    void EndGame()
    {
        endScreen.SetActive(true);

    }


}

