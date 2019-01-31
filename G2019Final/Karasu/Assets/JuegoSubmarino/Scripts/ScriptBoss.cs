using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBoss : MonoBehaviour {
    public GameObject ImagenFin, ImagenSuicidio;
    private SpriteRenderer sprite, sprite2;
    private AudioSource audioSource;
    public GameObject submarino;
    public GameObject tinta;
    [SerializeField]
    private int vidas = 50;
    [SerializeField]
    private float speed = 1, upperBound = 3.8f, lowerBound = -3.8f, startTime, timer, maxTime = 3, fullSpeed = 3, changeLife = 25;
    public bool thrown = false, goingUp = true;

    public int Vidas { get => vidas; set => vidas = value; }

    private void Awake() {
        ImagenSuicidio = GameObject.Find("ImagenSuicidio");
        audioSource = gameObject.GetComponent<AudioSource>();
        sprite = ImagenFin.GetComponent<SpriteRenderer>();
        sprite2 = ImagenSuicidio.GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (Time.time > 3) {
            gameObject.GetComponent<Animator>().SetBool("Attack", false);
            if (transform.position.y >= upperBound || transform.position.y <= lowerBound) {
                goingUp = !goingUp;
            }
            if (goingUp) {
                transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
            }
            else {
                transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
            }
            if (!thrown) {
                StartCoroutine(ThrowTint());
            }
        }
    }


    private IEnumerator ThrowTint() {
        thrown = true;
        float delay = Random.Range(1, maxTime);

        yield return new WaitForSeconds(delay);
        if (vidas > 0) {
            gameObject.GetComponent<Animator>().SetBool("Attack", true);
            audioSource.Play();
            yield return new WaitForSeconds(0.4f);
            audioSource.Stop();
            GameObject newTinta = Instantiate(tinta);
            Vector3 pos = gameObject.transform.position;
            pos.x -= 2;
            newTinta.transform.position = pos;
            thrown = false;
        }
    }

    private IEnumerator Damaged() {
        if (vidas == 0) {
            submarino.GetComponent<BoxCollider2D>().enabled = false;
        }
        while (Time.time < startTime + 3) {
            gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled;
            yield return new WaitForSeconds(0.1f);
        }
        if (vidas > 0) {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(2f);
            StartCoroutine(ShowEnd());
        }
    }
    public void Damage(int hp) {
        vidas -= hp;
        startTime = Time.time;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(Damaged());
        if (vidas <= changeLife && speed != fullSpeed) {
            speed = fullSpeed;
            maxTime = fullSpeed;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private IEnumerator ShowEnd() {

        while (sprite.color.a <= 0.95f) {
            Color color = new Color(255, 255, 255, sprite.color.a + 0.05f);
            sprite.color = color;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        while (sprite.color.a>=0.05f) {
            Color color = new Color(255, 255, 255, sprite.color.a - 0.05f);
            sprite.color = color;
            color = new Color(255, 255, 255, sprite2.color.a + 0.05f);
            sprite2.color = color;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
    }
}

