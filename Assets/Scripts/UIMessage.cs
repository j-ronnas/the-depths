using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMessage : MonoBehaviour
{

    [SerializeField]
    GameObject messageGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display()
    {
        StartCoroutine(DisplayTimeOut());
    }

    IEnumerator DisplayTimeOut()
    {
        messageGO.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        messageGO.SetActive(false);
    }
}
