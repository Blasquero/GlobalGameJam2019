using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintaScript : MonoBehaviour {

    [SerializeField]
    private const float SPEED = 7.5f, RELOADTIME = 2f;
    [SerializeField]
    private const int damage = 5;
    
  
    
    void Update() {
        transform.Translate(Vector3.left * Time.deltaTime * SPEED);
        if (transform.position.x < -25) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Submarino") {
            collision.gameObject.GetComponent<ScriptSubmarino>().Damage(damage);
            Destroy(gameObject);
        }
    }

}
