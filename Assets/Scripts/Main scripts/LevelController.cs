using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private int level;

    void Start() {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt(string.Format("unlock_level_{0}", level), 1);
        PlayerPrefs.SetInt("current_level", level);
    }

    void FixedUpdate() {
        int score = PlayerPrefs.GetInt("score");
        scoreText.text = "Score: " + score;
    }
}
