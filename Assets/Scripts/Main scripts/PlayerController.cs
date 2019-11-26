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
        StartCoroutine(RestartScene());
    }

    IEnumerator RestartScene() {
        yield return new WaitForSeconds(2);
        int currentLevel = PlayerPrefs.GetInt("current_level");
        SceneManager.LoadScene(string.Format("Level{0}Scene", currentLevel));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string name = collision.gameObject.name.ToLower();
        if (name.StartsWith("spike") || name.StartsWith("bottombound")) {
            Die();
        } else if (name.StartsWith("rightbound")) {
                    
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.otherCollider.name == "foot") {
            movement.SetAbleToJump(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        string name = collision.gameObject.name.ToLower();
        if (name.StartsWith("fish")) {
            Die();
        }
    }
}
