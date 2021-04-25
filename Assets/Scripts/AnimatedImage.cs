using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedImage : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    Image image;
    
    Color color;
    void Start()
    {
        color = image.color;
    }

    // Update is called once per frame
    float t;
    void Update()
    {
        t += Time.deltaTime;
        image.color = color * Mathf.Sin(t);
    }
}
