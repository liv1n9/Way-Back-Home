using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour {
    private bool consumed = false;

    private void Start() {
        
    }

    public void Consume() {
        if (consumed) {
            return;
        }
        consumed = true;
        Destroy(gameObject);
        int score = PlayerPrefs.GetInt("score");
        if (name.ToLower().StartsWith("apple")) {
            score += 50;
        } else {
            score += 100;
        }
        PlayerPrefs.SetInt("score", score);
    }
}
