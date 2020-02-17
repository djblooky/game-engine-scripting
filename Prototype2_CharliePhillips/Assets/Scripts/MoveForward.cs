﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speed = 20f;

    void Update()
    {
         transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
        
}
