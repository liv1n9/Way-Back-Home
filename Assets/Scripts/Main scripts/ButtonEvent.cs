using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadScene("SelectLevelScene");
    }

    public void Intro() {
        SceneManager.LoadScene("IntroScene");
    }

    public void Quit() {
        Application.Quit();
    }
}
