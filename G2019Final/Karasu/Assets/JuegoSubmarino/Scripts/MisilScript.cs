using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilScript : MonoBehaviour {

    private Queue<GameObject> colaMisiles;
    [SerializeField]
    private const float SPEED = 7.5f, RELOADTIME = 1;
    [SerializeField]
    private const int damage = 5;
    private bool isActive = false;

    public void SetCola(Queue<GameObject> cola) {
        colaMisiles = cola;
    }
    public void Activate() {
        isActive = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    void Update() {
        if (isActive) {
            transform.Translate(Vector3.right * Time.deltaTime * SPEED);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Boss") {
            collision.gameObject.GetComponent<ScriptBoss>().Damage(damage);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(ReloadMissile());
        }
    }
    private IEnumerator ReloadMissile() {
        yield return new WaitForSeconds(RELOADTIME);
        colaMisiles.Enqueue(gameObject);
    }

}
