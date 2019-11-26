using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "monkey") {
            StartCoroutine(RestartScene());
        }
    }

    IEnumerator RestartScene() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
