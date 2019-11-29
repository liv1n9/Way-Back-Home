using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonEvent : MonoBehaviour {

    [SerializeField]
    private Button button;
    [SerializeField]
    private int level;
    void Start() {
        string levelKey = string.Format("unlock_level_{0}", level);
        int unlocked = PlayerPrefs.GetInt(levelKey, 0);
        if (unlocked == 0) {
            button.interactable = false;
        }
        button.onClick.AddListener(StartLevel);
    }

    private void StartLevel() {
        SceneManager.LoadScene(string.Format("Level{0}Scene", level));
    }
}
