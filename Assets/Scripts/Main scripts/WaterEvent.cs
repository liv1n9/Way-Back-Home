using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEvent : MonoBehaviour {

    private System.Random random = new System.Random(26051996);
    private float totalWidth = 0.0f;
    private int lastIndex;
    private GameObject[] fishList;
    private GameObject[] waveList;
    private float[] delay;

    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private float limit;
    [SerializeField]
    private GameObject fish;
    [SerializeField]
    private int fishNumber;
    [SerializeField]
    private int waveLength;
    [SerializeField]
    private float lx;
    [SerializeField]
    private float rx;
    [SerializeField]
    private GameObject wave;
    [SerializeField]
    private float jumpForce = 530.0f;
    [SerializeField]
    private float landing = 2.0f;

    private void InitWater() {
        waveList = new GameObject[waveLength];
        lastIndex = waveLength - 1;
        float w = wave.gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        totalWidth = waveLength * w;
        float x = transform.position.x;
        float y = transform.position.y;
        for (int i = 0; i < waveLength; i++) {
            waveList[i] = Instantiate(wave, new Vector3(x + w * i, y, 0), Quaternion.identity);
        }
    }

    IEnumerator FishJump(int i, float delay) {
        yield return new WaitForSeconds(delay);
        float w = (rx - lx) / fishNumber;
        float x = lx + w * (i * 2 + 1) / 2.0f;
        fishList[i] = Instantiate(fish, new Vector3(x, -6, 0), Quaternion.identity);
        fishList[i].transform.Rotate(new Vector3(0, 0, 90));
        fishList[i].GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jumpForce, 0));
    }

    private void RecreateFist() {
        for (int i = 0; i < fishNumber; i++) {
            Destroy(fishList[i]);
            StartCoroutine(FishJump(i, delay[i]));
        }
    }

    private void InitFish() {
        fishList = new GameObject[fishNumber];
        delay = new float[fishNumber];
        float maxDelay = 0.0f;
        for (int i = 0; i < fishNumber; i++) {
            delay[i] = (float)random.NextDouble() * fishNumber;
            maxDelay = Mathf.Max(maxDelay, delay[i]);
        }
        InvokeRepeating("RecreateFist", 0.0f, maxDelay + landing);
    }

    void Start() {
        InitWater();
        InitFish();
    }

    void FixedUpdate() {
        float fixedSpeed = speed * Time.fixedDeltaTime;
        for (int i = 0; i < waveLength; i++) {
            waveList[i].transform.position += new Vector3(fixedSpeed, 0, 0);
        }
        if (waveList[lastIndex].transform.position.x >= limit) {
            waveList[lastIndex].transform.position -= new Vector3(totalWidth, 0, 0);
            lastIndex -= 1;
            if (lastIndex < 0) {
                lastIndex += waveLength;
            }
        }
    }
}
