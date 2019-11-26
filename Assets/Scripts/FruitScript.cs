using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour {
    private bool consumed = false;

    public void Consume() {
        if (consumed) {
            return;
        }
        consumed = true;
        Destroy(gameObject);
        int score = PlayerPrefs.GetInt("score");
        if (name.StartsWith("apple")) {
            score += 50;
        } else {
            score += 100;
        }
        PlayerPrefs.SetInt("score", score);
    }
}
