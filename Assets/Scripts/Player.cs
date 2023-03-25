using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce, rotationFactor;

    [SerializeField] private Transform deathParticle;

    [SerializeField] private ParticleSystem jumpParticle;

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

    public void Die(Transform pipe)
    {
        Debug.Log("dead");

        Instantiate(deathParticle, transform).parent = pipe;

        Destroy(gameObject);
    }

    private void Jump()
    {
        jumpParticle.Play();

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
