﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformer : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float angularSpeed = 45f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
    }
}
