using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour {

    [SerializeField]
    private Sprite onSprite;
    [SerializeField]
    private Sprite offSprite;
    [SerializeField]
    private Button soundButton;

    void Start() {
        int soundOn = PlayerPrefs.GetInt("soundOn", 1);
        soundButton.image.sprite = soundOn == 0 ? offSprite : onSprite;
        soundButton.onClick.AddListener(TurnSound);
    }

    private void TurnSound() {
        int soundOn = PlayerPrefs.GetInt("soundOn", 1) ^ 1;
        soundButton.image.sprite = soundOn == 0 ? offSprite : onSprite;
        PlayerPrefs.SetInt("soundOn", soundOn);
    }
}
