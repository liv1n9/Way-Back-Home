using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private bool ableToMove = true;
    private bool ableToJump = true;
    private bool directionFlag = true;
    private float moveHorizontal = 0.0f;

    [SerializeField]
    private Rigidbody2D monkeyBody;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Animator animator;

    private void Update() {
        moveHorizontal = Input.GetAxis("Horizontal");
        animator.SetBool("jumping", !ableToJump);
    }

    public void Move() {
        if (!ableToMove) return;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            if (!directionFlag) {
                directionFlag = true;
                transform.Rotate(new Vector3(0, -180, 0));
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            if (directionFlag) {
                directionFlag = false;
                transform.Rotate(new Vector3(0, -180, 0));
            }
        }
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        monkeyBody.transform.position += movement * speed * Time.fixedDeltaTime;
        float horizontalSpeed = moveHorizontal * speed * Time.fixedDeltaTime;
        animator.SetFloat("speed", Mathf.Abs(horizontalSpeed));
    }

    public void Jump() {
        if (Mathf.Abs(monkeyBody.velocity.y) > 0.0f) {
            ableToJump = false;
        }
        if (!ableToMove || !ableToJump) {
            return;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            monkeyBody.velocity = new Vector2(monkeyBody.velocity.x, 0);
            Vector3 force = new Vector3(0, 300, 0);
            monkeyBody.AddForce(force);
            ableToJump = false;
        }
        float horizontalSpeed = moveHorizontal * speed * Time.fixedDeltaTime;
        animator.SetFloat("speed", Mathf.Abs(horizontalSpeed));
    }

    public void Die() {
        ableToJump = ableToMove = false;
        monkeyBody.velocity = Vector3.zero;
        monkeyBody.AddForce(new Vector3(0, 200, 0));
        gameObject.transform.Find("head").GetComponent<CircleCollider2D>().enabled = false;
        gameObject.transform.Find("body").GetComponent<BoxCollider2D>().enabled = false;
        gameObject.transform.Find("foot").GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetAbleToJump(bool value) {
        ableToJump = value;
    }
}
