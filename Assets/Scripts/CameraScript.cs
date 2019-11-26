using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMin;
    [SerializeField]
    private float yMax;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject backgroundNear;

    [SerializeField]
    private GameObject backgroundFar;

    private float deltaX = 0.0f;
    private float deltaY = 0.0f;
    private float sx = 0.0f;
    private float sy = 0.0f;
    private float cx = 0.0f;
    private float cy = 0.0f;

    private void Start() {
        sx = target.transform.position.x;
        sy = target.transform.position.y;
    }

    private void Update() {
        cx = Mathf.Clamp(target.transform.position.x, xMin, xMax);
        cy = Mathf.Clamp(target.transform.position.y, yMin, yMax);
        deltaX = cx - transform.position.x;
        deltaY = cy - transform.position.y;
    }

    void FixedUpdate() {
        transform.position = new Vector3(cx, cy, transform.position.z);
        backgroundNear.transform.position += new Vector3(deltaX * 0.6f, deltaY * 0.6f, 0);
        backgroundFar.transform.position += new Vector3(deltaX * 0.7f, deltaY * 0.7f, 0);
    }
}
