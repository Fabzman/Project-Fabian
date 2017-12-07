using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    // Destroys other game objects when they leave the boundary
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy (other.gameObject);
    }
}