using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {

    private bool flip = false;

    [SerializeField]
    private Rigidbody2D fishBody;

    private void FixedUpdate() {
        if (fishBody.velocity.y <= -0.01f && !flip) {
            flip = true;
            transform.Rotate(new Vector3(0, 0, -180));
        }
    }
}
