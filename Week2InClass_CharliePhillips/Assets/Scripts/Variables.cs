using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    void Start()
    {
        int num = 10;
        float f = 10f;
        double d = 20.2;

        decimal money = 10m; //for currency?

        bool invincible = true;

        float averageScore = (10 + 5 + 7) / 3;

        Debug.Log($"Average score is {averageScore}"); //interpolated string

        float[] itemCosts = { 10, 5.5f, 7.25f }; //arrays are fixed size

        for(int i=0; i < itemCosts.Length; i++)
        {

        }

        foreach(float cost in itemCosts)
        {

        }
    }

}
