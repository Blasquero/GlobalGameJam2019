using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour {

    private IEnumerator coroutine;
    public GameObject panel;
    public GameObject panelAnimation;
    public GameObject[] letras;
    public float countdown;
    public float total_time;
    private int letra;
    public float velocidad;
    public float rotacion;
    public bool lockHardMode;
    private float timer = 5f;
    public int modo;

    // Use this for initialization
    void Start () {
        StartCoroutine(generate());
        lockHardMode = false;
    }

    

    // Update is called once per frame
    void Update () {

        if (lockHardMode == true)
        {
            countdown = Random.Range(0.25f, 0.5f);
            velocidad = Random.Range(4f, 5f);
            rotacion = Random.Range(5f, 15f);
           
        }
        else
        {
            switch (modo)
            {
                case 0:

                    countdown = 3f;
                    velocidad = 1f;
                    rotacion = 0;
                    ; break;
                case 1:
                    countdown = 2f;
                    velocidad = 2f;
                    rotacion = 0;
                    ; break;
                case 2:
                    countdown = Random.Range(0.75f, 1f);
                    velocidad = Random.Range(3f, 4f);
                    rotacion = 0;
                    ; break;
                case 3:
                    countdown = Random.Range(0.25f, 0.5f);
                    velocidad = Random.Range(4f, 5f);
                    rotacion = Random.Range(5f, 15f);
                    lockHardMode = true;
                    ; break;
                default: break;
            }


        }

        if (panel.GetComponent<UI_Score>().score < 0)
        {
            panel.GetComponent<UI_Score>().score = 0;
        }

        if (panel.GetComponent<UI_Score>().score == 0 && lockHardMode)
        {
            countdown = 0;
            velocidad = 10;
            rotacion = Random.Range(5f, 15f);
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            panelAnimation.GetComponent<Animator>().SetBool("fade", true);
        }

        

    }
	

    public IEnumerator generate()
    {
        while (true)
        {
            yield return new WaitForSeconds(countdown);
            letra = Random.Range(0, letras.Length);
            GameObject letter = Instantiate(letras[letra],transform.position,transform.rotation);
            letter.transform.parent = panel.transform;
            letter.GetComponent<Letter>().background = GameObject.Find("background");
            letter.GetComponent<Letter>().speed = velocidad;
            letter.GetComponent<Rigidbody2D>().AddTorque(rotacion);
            float positionX = Random.Range(100, 630);
            letter.transform.position = new Vector2(positionX, letter.transform.position.y);
        }
    }
}
