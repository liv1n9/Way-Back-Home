using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb2d;

    private bool direction = true;
    private bool ableToMove = true;
    private bool ableToJump = true;
    private float moveHorizontal;
    private float moveVertical;
    private float preVelocY = 0.0f;

    void Start() {
        
    }

    void Update() {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Debug.Log(Mathf.Abs(rb2d.velocity.y));
        if (Mathf.Abs(rb2d.velocity.y) > 0.0f) {
            ableToJump = false;
        } else if (preVelocY <= 0.0f) {
            ableToJump = true;
        }
        preVelocY = rb2d.velocity.y;
    }

    void Move() {
        if (!ableToMove) return;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            if (!direction) {
                direction = true;
                transform.Rotate(new Vector3(0, -180, 0));
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            if (direction) {
                direction = false;
                transform.Rotate(new Vector3(0, -180, 0));
            }
        }
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        rb2d.transform.position += movement * speed * Time.fixedDeltaTime;
        float horizontalSpeed = moveHorizontal * speed * Time.fixedDeltaTime;
        animator.SetFloat("speed", Mathf.Abs(horizontalSpeed));
    }

    

    void FixedUpdate() {
        Move();
        animator.SetBool("jumping", !ableToJump);
    }

    private void DieBySpike(Collision2D spike) {
        rb2d.velocity = new Vector3();
        ableToJump = true;
        Destroy(animator);
        Destroy(spike.gameObject.GetComponent<BoxCollider2D>());
    }

    void OnCollisionEnter2D(Collision2D collision) {
        string name = collision.gameObject.name;
        if (name.StartsWith("spike")) {
            DieBySpike(collision);
            ableToMove = false;
            return;
        }
        if (name == "BottomBound") {
            ableToMove = false;
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        string name = collision.gameObject.name;
        Debug.Log(name);
        if (name.StartsWith("Fish")) {
            
        }
    }
}
