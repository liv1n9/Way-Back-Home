using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour {

    [SerializeField]
    private UnityEngine.UI.Button button;

    void Start() {
        button.onClick.AddListener(Next);
    }

    void Next() {
        int currentLevel = PlayerPrefs.GetInt("current_level");
        if (currentLevel == 1) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(string.Format("Level{0}Scene", currentLevel + 1));
        } else {
            PlayerPrefs.DeleteKey("current_level");
            UnityEngine.SceneManagement.SceneManager.LoadScene(string.Format("SelectLevelScene"));
        }
    }
}
