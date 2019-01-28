using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovim : MonoBehaviour {

    public float speed = 1f;

    private Vector3 direction = Vector3.left;

    private void Start()
    {
        StartCoroutine(Movement());    
    }

    void Update ()
    {
        MoveDirection();
    }

    private void MoveDirection()
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    private IEnumerator Movement()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            direction *= -1;
        }
    }
}
