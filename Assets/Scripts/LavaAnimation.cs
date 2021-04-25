﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaAnimation : MonoBehaviour
{
    Material mat;
    [SerializeField]
    Vector2 speed;
    Vector2 offset = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += speed*Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}
