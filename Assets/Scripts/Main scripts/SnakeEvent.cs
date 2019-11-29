using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEvent : MonoBehaviour {

    private Animator animator;

    [SerializeField]
    private bool directionFlag = true;
    [SerializeField]
    private float lx = 0.0f;
    [SerializeField]
    private float rx = 0.0f;
    [SerializeField]
    private float speed = 2;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        Vector3 movement = new Vector3(directionFlag ? 1 : -1, 0, 0);
        transform.position += movement * speed * Time.fixedDeltaTime;
        if ((directionFlag && transform.position.x >= rx) || (!directionFlag && transform.position.x <= lx)) {
            directionFlag = !directionFlag;
            transform.Rotate(new Vector3(0, -180, 0));
        }
        animator.SetFloat("speed", speed * Time.fixedDeltaTime);
    }
}
