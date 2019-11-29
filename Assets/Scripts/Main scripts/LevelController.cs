using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private int level;
    [SerializeField]
    private GameObject fruits;

    private void InitSetting() {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt(string.Format("unlock_level_{0}", level), 1);
        PlayerPrefs.SetInt("current_level", level);
        int totalScore = 0;
        foreach (Transform fruit in fruits.transform) {
            string name = fruit.name.ToLower();
            if (name.StartsWith("apple")) {
                totalScore += 50;
            } else {
                totalScore += 100;
            }
        }
        PlayerPrefs.SetInt("total_score", totalScore);
    }

    void Start() {
        InitSetting();
    }

    void FixedUpdate() {
        int score = PlayerPrefs.GetInt("score");
        scoreText.text = "Score: " + score;
    }
}
