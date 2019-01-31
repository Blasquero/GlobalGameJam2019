using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float startMovementSpeed;
    public float raycastDistance = 0.6f;
    public LayerMask mask;
    public GameObject posicionRay1, posicionRay2;
    public float jumpSpeed;
    private float fallMultiplier = 5f;
    private float lowJumpMultiplier = 1;
    private Rigidbody2D rb2;
    private Animator anim;
    private SpriteRenderer sprit;

    private float movementSpeed;


    private void Start()
    {
        movementSpeed = startMovementSpeed;
        anim = GetComponent<Animator>(); 
        sprit = GetComponent<SpriteRenderer>();
        rb2 = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1")) movementSpeed = startMovementSpeed * 1.5f;
        else movementSpeed = startMovementSpeed;

        float axisH = Input.GetAxis("Horizontal");
        
        if (axisH < 0) sprit.flipX = true;
        else if (axisH > 0) sprit.flipX = false;

        if (axisH == 0) anim.SetBool("idle", true);
        else anim.SetBool("idle", false);

        transform.position += Vector3.right * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        if (rb2.velocity.y < 0)
            rb2.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb2.velocity.y > 0 && !Input.GetButton("Jump"))
            rb2.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            rb2.velocity = new Vector2(rb2.velocity.x, jumpSpeed);
        }

        if (rb2.velocity.y < 0) anim.SetBool("cayendo", true);
        else anim.SetBool("cayendo", false);
    }

    private bool Grounded()
    {
        bool grounded = Physics2D.Raycast(posicionRay1.transform.position, Vector2.down, raycastDistance, mask);
        grounded |= Physics2D.Raycast(posicionRay2.transform.position, Vector2.down, raycastDistance, mask);
        return grounded;
    }
}