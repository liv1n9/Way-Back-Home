using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitScript : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    void Start() {
        PlayerPrefs.SetInt("score", 0);
    }

    void FixedUpdate() {
        int score = PlayerPrefs.GetInt("score");
        scoreText.text = "Score: " + score;
    }
}
