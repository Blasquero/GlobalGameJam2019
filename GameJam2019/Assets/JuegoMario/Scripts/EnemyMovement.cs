using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float raycastLength;
    public float goombaSpeed;

    private Vector3 direction = Vector3.left;
    
    void Update()
    {
        transform.Translate(direction * goombaSpeed * Time.deltaTime);
        if (Physics2D.Raycast(transform.position + direction/2, direction, raycastLength)) direction *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Personaje")
        {
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            StartCoroutine(GameMan.restartScene());
        }
    }
}