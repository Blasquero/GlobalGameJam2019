using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPez : MonoBehaviour {

    private Vector3 direction;
    private float speed = 1;
    private SpriteRenderer spriteRender;
    private int posInicial;

    void Start() {
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(Respawn());
    }

    void Update() {
        if(transform.position.x<13 || transform.position.x>-13) {
            transform.Translate(direction *speed * Time.deltaTime);
        }
        else {
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn() {
        float RandomTime = Random.Range(3, 7);
        yield return new WaitForSeconds(RandomTime);
        Color newColor = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 1);
        spriteRender.color = newColor;
        if (Random.Range(0, 100) > 50) {
            transform.position = new Vector3(12, Random.Range(-4, 4), 0);
            direction = Vector3.left;
            spriteRender.flipX = false;
        }
        else {
            transform.position = new Vector3(-12, Random.Range(-5, 5), 0);
            direction = Vector3.right;
            spriteRender.flipX = true;
        }
    }
}
