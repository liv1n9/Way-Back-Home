using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameController : MonoBehaviour {
    
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button introButton;
    [SerializeField]
    private ButtonEvent buttonEvent;

    void Awake() {
        PlayerPrefs.SetInt("unlock_level_1", 1);
    }

    void Start() {
        playButton.onClick.AddListener(buttonEvent.PlayGame);
        introButton.onClick.AddListener(buttonEvent.Intro);
    }

}
