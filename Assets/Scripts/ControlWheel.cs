using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWheel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject wheelObject;
    RotatingPillar rp;


    float animationTime = 0.8f;

    GameObject soundEffect;

    void Start()
    {
        rp = FindObjectOfType<RotatingPillar>();
        GetComponent<Interactable>().onInteraction += RotateWheel;
        soundEffect = Resources.Load<GameObject>("SoundPrefabs/slide_door");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateWheel()
    {
        t = 0;
        Instantiate(soundEffect);
        StartCoroutine(RotateAnimation());
    }



    void OnRotateFinish()
    {
        FindObjectOfType<GameManager>().rotatingPillarMode = (FindObjectOfType<GameManager>().rotatingPillarMode + 1) % 4;
        rp.SetRotation();
    }
    float t = 0;
    IEnumerator RotateAnimation()
    {
        while (t < animationTime)
        {

            wheelObject.transform.Rotate(new Vector3(0, 60*Time.deltaTime / animationTime, 0)); 
            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        OnRotateFinish();
    }
}
