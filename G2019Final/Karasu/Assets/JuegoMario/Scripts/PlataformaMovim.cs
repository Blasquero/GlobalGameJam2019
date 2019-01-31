using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovim : MonoBehaviour {

    public float speed = 1f;

    private float rotateTime;
    public Vector3 direction = Vector3.left;
    private SpriteRenderer sprit;
    private void Start()
    {
        rotateTime = Random.Range(2.0f, 4.0f);
        sprit = GetComponent<SpriteRenderer>();
        StartCoroutine(Movement());    
    }

    void Update ()
    {
        MoveDirection();
        if (direction == Vector3.left) sprit.flipX = true;
        else sprit.flipX = false;
    }

    private void MoveDirection()
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    private IEnumerator Movement()
    {
        while(true)
        {
            yield return new WaitForSeconds(rotateTime);
            direction *= -1;
        }
    }
}
