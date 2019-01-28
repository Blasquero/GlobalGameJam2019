using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float raycastDistance = 0.6f;
    public LayerMask mask;
    public GameObject posicionRay1, posicionRay2;
    public float jumpSpeed;

    private Rigidbody2D rb2;

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump")) rb2.gravityScale = 0.9f;
        if (Input.GetButtonUp("Jump")) rb2.gravityScale = 8f;

        if(Input.GetButtonDown("Jump") && Grounded())
        {
            rb2.velocity = new Vector2(rb2.velocity.x, jumpSpeed);
        }
    }

    private bool Grounded()
    {
        bool grounded = Physics2D.Raycast(posicionRay1.transform.position, Vector2.down, raycastDistance, mask);
        grounded |= Physics2D.Raycast(posicionRay2.transform.position, Vector2.down, raycastDistance, mask);
        return grounded;
    }
}