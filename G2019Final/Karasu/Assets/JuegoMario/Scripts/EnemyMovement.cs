using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float raycastLength;
    public float goombaSpeed;

    private Vector3 direction = Vector3.left;

    void Update()
    {
        if (direction == Vector3.left) GetComponent<SpriteRenderer>().flipX = false;
        else GetComponent<SpriteRenderer>().flipX = true;

        transform.Translate(direction * goombaSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Personaje")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("muerto", true);
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            StartCoroutine(GameMan.restartScene());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        direction *= -1;
    }
}