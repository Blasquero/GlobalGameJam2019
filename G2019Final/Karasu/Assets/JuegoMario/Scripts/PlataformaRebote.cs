using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaRebote : MonoBehaviour {

    public float platformStrength;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Personaje")
        {
            Rigidbody2D rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            rb2d.velocity = transform.TransformDirection(Vector3.up) * platformStrength;
            StartCoroutine(destruir());
        }
    }

    private IEnumerator destruir()
    {
        SpriteRenderer sprend = GetComponent<SpriteRenderer>();
        BoxCollider2D boxC = GetComponent<BoxCollider2D>();
        GetComponent<Animator>().SetBool("saltar", true);
        boxC.enabled = false;

        yield return new WaitForSeconds(3f);

        GetComponent<Animator>().SetBool("saltar", false);
        boxC.enabled = true;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
