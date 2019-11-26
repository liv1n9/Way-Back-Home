using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        string name = other.gameObject.name;
        if (name.StartsWith("apple") || name.StartsWith("banana")) {
            FruitScript script = other.gameObject.GetComponent<FruitScript>();
            script.Consume();
        }
    }
}
