using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEvent : MonoBehaviour {   
    [SerializeField]
    private float speed;
    [SerializeField]
    private float limit;
    [SerializeField]
    private GameObject fish;
    [SerializeField]
    private int fishNumber;

    [SerializeField]
    private float lx;
    [SerializeField]
    private float rx;
    private System.Random random = new System.Random(26051996);
    private float totalWidth = 0.0f;
    private int n;
    private int lastIndex;
    private GameObject[] fishList;
    private float[] delay;

    private void InitWater() {
        n = transform.childCount;
        lastIndex = n - 1;
        float w = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;
        totalWidth = n * w;
        float x = transform.GetChild(0).position.x;
        float y = transform.GetChild(0).position.y;
        for (int i = 1; i < n; i++) {
            transform.GetChild(i).position = new Vector3(x + w * i, y, 0);
        }
    }

    IEnumerator FishJump(int i, float delay) {
        yield return new WaitForSeconds(delay);
        float w = (rx - lx) / fishNumber;
        float x = lx + w * (i * 2 + 1) / 2.0f;
        fishList[i] = Instantiate(fish, new Vector3(x, -6, 0), Quaternion.identity);
        fishList[i].transform.Rotate(new Vector3(0, 0, 90));
        fishList[i].GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 500, 0));
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
        for (int i = 0; i < fishNumber; i++) {
            delay[i] = (float)random.NextDouble() * fishNumber;
        }
        InvokeRepeating("RecreateFist", 0.0f, 6.0f);
    }

    void Start() {
        InitWater();
        InitFish();
    }

    void FixedUpdate() {
        float fixedSpeed = speed * Time.fixedDeltaTime;
        for (int i = 0; i < n; i++) {
            transform.GetChild(i).position += new Vector3(fixedSpeed, 0, 0);
        }
        if (transform.GetChild(lastIndex).position.x >= limit) {
            transform.GetChild(lastIndex).position -= new Vector3(totalWidth, 0, 0);
            lastIndex = (lastIndex - 1 + n) % n;
        }
    }
}
