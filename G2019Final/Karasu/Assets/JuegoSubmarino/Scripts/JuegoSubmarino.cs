using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoSubmarino : MonoBehaviour {
    private bool beingPlayed;
    private SpriteRenderer sprite;
    private AudioSource audioSource;
    public GameObject imagenInicio;

    private void Start() {
        sprite=imagenInicio.GetComponent<SpriteRenderer>();
        audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine(FadeIn());
    }
    private void Update() {
        if (!beingPlayed && Time.time>4) {
            beingPlayed = true;
            StartCoroutine(PlaySalpicon());
        }
    }

    IEnumerator PlaySalpicon() {
        float waitTime = Random.Range(3, 7);
        yield return new WaitForSeconds(waitTime);
        audioSource.Play();
        yield return new WaitForSeconds(3f);
        beingPlayed = false;

        
    }

    IEnumerator FadeIn() {
        yield return new WaitForSeconds(1.0f);
        while (sprite.color.a != 0) {
            Color color = new Color(255, 255, 255, sprite.color.a - 0.05f);
            sprite.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
