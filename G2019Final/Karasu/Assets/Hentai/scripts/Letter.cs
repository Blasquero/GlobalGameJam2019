using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public float speed;
    public GameObject children;
    public GameObject background;
    public bool catched;
    public GameObject particle;

    public AudioClip[] sonido;


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("trigger funciona");
        if (collision.gameObject.tag == "scoreLine")
        {
            Debug.Log("detección buena");
            string letra = children.GetComponent<Text>().text.ToLower();
            if (Input.GetKeyDown(letra))
            {
                catched = true;
                Instantiate(particle, transform.position, transform.rotation);
                gameObject.GetComponent<AudioSource>().clip = sonido[Random.Range(0, sonido.Length)];
                gameObject.GetComponent<AudioSource>().Play();

            }
        }
    }
    // Use this for initialization
    void Start()
    {
        catched = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        gameObject.transform.Translate(Vector2.down * speed);

        if (catched == true)
        {
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x / 2, gameObject.transform.localScale.y / 2);

        }

        if (gameObject.transform.position.y < -300 && catched == false)
        {
            background.GetComponent<UI_Score>().score--;
            Destroy(gameObject);
        }


        else if (gameObject.transform.position.y < -300 && catched == true)
        {
            background.GetComponent<UI_Score>().score++;
            Destroy(gameObject);
        }



    }





}




