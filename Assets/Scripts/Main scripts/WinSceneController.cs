using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSceneController : MonoBehaviour {
    [SerializeField]
    private UnityEngine.UI.Text scoreText;

    void Start() {
        int score = PlayerPrefs.GetInt("score");
        int totalScore = PlayerPrefs.GetInt("total_score");
        scoreText.text = string.Format(scoreText.text, score, totalScore);
    }
}
