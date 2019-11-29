using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {

    [SerializeField]
    private UnityEngine.UI.Button button;

    void Start() {
        button.onClick.AddListener(Restart);
    }

    private void Restart() {
        int currentLevel = PlayerPrefs.GetInt("current_level");
        UnityEngine.SceneManagement.SceneManager.LoadScene(string.Format("Level{0}Scene", currentLevel));
    }
}
