using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int score = 0;

    void OnTriggerEnter(Collider other)
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }
}
