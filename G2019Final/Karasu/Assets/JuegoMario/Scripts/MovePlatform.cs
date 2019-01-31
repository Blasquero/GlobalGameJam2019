using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.parent = transform;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.transform.parent = null;
    }
}
