using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private PlayerMovement movement;

    void Start() {

    }

    void Update() {
    }

    private void FixedUpdate() {
        movement.Move();
        movement.Jump();
    }

    private void Die() {
        movement.Die();
        StartCoroutine(LoseScene());
    }

    IEnumerator LoseScene() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("LoseScene");
    }

    private void WinScene() {
        SceneManager.LoadScene("WinScene");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string name = collision.gameObject.name.ToLower();
        if (name.StartsWith("spike") || name.StartsWith("bottombound") || name.StartsWith("snake")) {
            Die();
        } else if (name.StartsWith("rightbound")) {
            WinScene();
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.otherCollider.name == "foot") {
            movement.SetAbleToJump(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.otherCollider.name == "foot") {
            movement.SetAbleToJump(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        string name = collision.gameObject.name.ToLower();
        if (name.StartsWith("fish")) {
            Die();
        }
    }
}
