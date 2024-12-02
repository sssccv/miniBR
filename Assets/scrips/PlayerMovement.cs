using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 movement;

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontal, 0f, vertical).normalized;

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }
    }

    void FixedUpdate()
    {
        Vector3 velocity = movement * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + velocity);
    }
}
