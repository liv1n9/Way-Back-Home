using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : MonoBehaviour {

    [SerializeField]
    private UnityEngine.UI.Button button;

    void Start() {
        button.onClick.AddListener(Home);
    }

    private void Home() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
}
