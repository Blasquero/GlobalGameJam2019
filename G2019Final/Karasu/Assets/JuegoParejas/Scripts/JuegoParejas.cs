using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuegoParejas : MonoBehaviour {
    private int numCartas = 12;

    public Sprite[] reversos =new Sprite[4];
    public Sprite[] anversos = new Sprite[4];
    public Sprite[] letras = new Sprite[6];
    private List<GameObject> cartasMarcadas=new List<GameObject>();
    private GameObject[] cartas;
    private GameObject carta1, carta2;
    [SerializeField]
    private GameObject letra1, letra2;
    public List<GameObject> listaCartas;
    private SpriteRenderer imagenInicio;
    public GameObject goImagenInicio;
    
    private CartaScript infoCarta1, infoCarta2;
    public GameObject carta;

    private bool checking;
    void Start() {
        imagenInicio = goImagenInicio.GetComponent<SpriteRenderer>();
        checking = false;

        carta1 = null;
        carta2 = null;
        int x = 0;

        //Quitar foreach cuando tengamos sprite reverso
        foreach (GameObject carta in listaCartas) {
            int num = Random.Range(0, 3);
            carta.GetComponent<CartaScript>().SetReverso(reversos[num]);
            carta.GetComponent<CartaScript>().SetAnverso(anversos[num]);
        }  

        for (int i = 0; i < numCartas / 2; i++) {
            x = (int)Random.Range(0, listaCartas.Count);
            listaCartas[x].GetComponent<CartaScript>().SetParejaCarta(i);
            cartasMarcadas.Add(listaCartas[x]);
            listaCartas.RemoveAt(x);

            x = (int)Random.Range(0, listaCartas.Count);
            listaCartas[x].GetComponent<CartaScript>().SetParejaCarta(i);
            cartasMarcadas.Add(listaCartas[x]);
            listaCartas.RemoveAt(x);
        }
        StartCoroutine(ImagenInicio());

    }

    void Update() {
        if (Input.GetMouseButtonDown(0)&& Time.time>2) {

            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
            if (hit && !checking) {

                if (carta1 == null) {
                    carta1 = hit.transform.gameObject;
                    StartCoroutine(ShowCard1());
                }
                else {
                    carta2 = hit.transform.gameObject;
                    if (carta1 != carta2) {
                        checking = true;
                        infoCarta1 = carta1.GetComponent<CartaScript>();
                        infoCarta2 = carta2.GetComponent<CartaScript>();
                        StartCoroutine(Check());
                    }
                    else {
                        carta1 = null;
                        carta2 = null;
                    }
                }

            }
        }
    }

    private IEnumerator ShowCard1() {
        letra1.transform.position = carta1.transform.position;
        letra1.transform.eulerAngles = new Vector3(0, 90, 0);
        letra1.GetComponent<SpriteRenderer>().sprite = letras[carta1.GetComponent<CartaScript>().GetParejaCarta()];
        letra1.SetActive(true);

        while (carta1.transform.eulerAngles.y <= 90) {
            carta1.transform.Rotate(Vector2.up, 18);
            yield return new WaitForSeconds(0.1f);
        }
        carta1.GetComponent<CartaScript>().Swap();
        while (carta1.transform.eulerAngles.y >= 0.1) {
            carta1.transform.Rotate(Vector2.down, 18);
            letra1.transform.Rotate(Vector2.down, 18);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Check() {
       

        letra2.transform.position = carta2.transform.position;
        letra2.transform.eulerAngles = new Vector3(0, 90, 0);
        letra2.GetComponent<SpriteRenderer>().sprite = letras[carta2.GetComponent<CartaScript>().GetParejaCarta()];
        letra2.SetActive(true);

        while (carta2.transform.eulerAngles.y <= 90) {
            carta2.transform.Rotate(Vector2.up, 18);
            
            yield return new WaitForSeconds(0.1f);
        }
      
        carta2.GetComponent<CartaScript>().Swap();


        while (carta2.transform.eulerAngles.y >= 0.1) {
            carta2.transform.Rotate(Vector2.down, 18);
            letra2.transform.Rotate(Vector2.down, 18);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);

        if (infoCarta1.GetParejaCarta() == infoCarta2.GetParejaCarta()) {
            letra1.transform.eulerAngles = new Vector3(0, 90, 0);
            letra2.transform.eulerAngles = new Vector3(0, 90, 0);
            Destroy(carta1);
            Destroy(carta2);
            numCartas -= 2;
            if (numCartas == 0) {
                CambiarEscena();
            }
            checking = false;
        }
        else {
            while(carta1.transform.eulerAngles.y <= 90) {
                carta2.transform.Rotate(Vector2.up, 18);
                carta1.transform.Rotate(Vector2.up, 18);
                letra1.transform.Rotate(Vector2.up, 18);
                letra2.transform.Rotate(Vector2.up, 18);
                yield return new WaitForSeconds(0.1f);
            }
            carta1.GetComponent<CartaScript>().Swap();
            carta2.GetComponent<CartaScript>().Swap();
            while (carta1.transform.eulerAngles.y >= 0.1) {
                carta2.transform.Rotate(Vector2.down, 18);
                carta1.transform.Rotate(Vector2.down, 18);

                yield return new WaitForSeconds(0.1f);
            }

            carta1 = null;
            carta2 = null;
            checking = false;
        }
    }
    private IEnumerator ImagenInicio() {
        yield return new WaitForSeconds(1.0f);
        while (imagenInicio.color.a != 0) {
            Color color = new Color(255, 255, 255, imagenInicio.color.a - 0.05f);
            imagenInicio.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void CambiarEscena() {
        SceneManager.LoadScene("Diary");
    }
}
