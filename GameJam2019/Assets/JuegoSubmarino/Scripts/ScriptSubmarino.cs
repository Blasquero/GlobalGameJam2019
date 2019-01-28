using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptSubmarino : MonoBehaviour {

    public GameObject pulpo;
    private AudioSource audioSource;
    private const float RELOADTIME = 1.5f;
    private const int MAXMISILES = 3;
    private const float speed = 2.5f;
    private int maxVidas;
    private float startTime;
    [SerializeField]
    private GameObject misil;


    [SerializeField]
    private int vidas;

    public int Vidas {
        get => vidas;
        set {
            vidas = value;
        }
    }
    [SerializeField]
    private Queue<GameObject> poolMisiles = new Queue<GameObject>();

    public void Damage(int damage) {
        vidas -= damage;
        startTime = Time.time;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(Damaged());
    }

    private void Awake() {
        vidas =25;
        //Añadimos los misiles
        for(int i = 0; i < MAXMISILES; i++) {
            GameObject misilNuevo = Instantiate(misil);
            misilNuevo.transform.localScale = new Vector3(3, 3, 1);
            misilNuevo.GetComponent<SpriteRenderer>().enabled = false;
            misilNuevo.GetComponent<MisilScript>().SetCola(poolMisiles);
            poolMisiles.Enqueue(misilNuevo);
        }
        audioSource = GetComponent<AudioSource>();
    }
    private IEnumerator Damaged() {
        if (vidas== 0) {
            pulpo.GetComponent<CircleCollider2D>().enabled = false;
        }
        while (Time.time < startTime + 3) {
            gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled;
            yield return new WaitForSeconds(0.1f);
        }
        if (vidas <= 0) {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;


        }

    }

    void Update() {
        if (Time.time > 3) {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                Vector3 posicionActual = transform.position;
                float nuevaY = posicionActual.y - speed * Time.deltaTime;
                posicionActual.y = (nuevaY < -4) ? -4 : nuevaY;
                transform.position = posicionActual;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                Vector3 posicionActual = transform.position;
                float nuevaY = posicionActual.y + speed * Time.deltaTime;
                posicionActual.y = (nuevaY > 4) ? 4 : nuevaY;
                transform.position = posicionActual;
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                if (poolMisiles.Count != 0) {
                    audioSource.Play();
                    GameObject misilLanzado = poolMisiles.Dequeue();
                    Vector3 misilPos = transform.position;
                    misilPos.x += 1.25f;
                    misilLanzado.transform.position = misilPos;

                    misilLanzado.GetComponent<MisilScript>().Activate();
                }

            }

        }
    }
}
