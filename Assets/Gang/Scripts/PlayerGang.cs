using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGang : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    float movement;
    float lastMovement;

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("horizontal", movement);
        if (movement < 0.01 && lastMovement > 0.01)
        {
            animator.SetFloat("idle_horizontal", lastMovement);
        }

        lastMovement = movement;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(movement, 0f) * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger!!!!11!111!!");
    }
}