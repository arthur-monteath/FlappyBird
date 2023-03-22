using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce, rotationFactor;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();

        HandleRotation();
    }

    private void Jump()
    {
        rb.velocity = Vector2.zero;

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void HandleMovement()
    {
        if(Input.anyKeyDown)
        {
            Jump();
        }
    }

    private void HandleRotation()
    {
        float ySpeed = rb.velocity.y;

        float birdRotation = ySpeed * rotationFactor;

        rb.MoveRotation(birdRotation);
    }
}
