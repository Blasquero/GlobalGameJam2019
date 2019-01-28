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
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
