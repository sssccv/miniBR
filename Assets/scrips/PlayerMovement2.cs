using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 movement;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal2");
        float vertical = Input.GetAxisRaw("Vertical2");
        movement = new Vector3(horizontal, 0f, vertical);

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        Move();
    }

    void Move()
    {
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pelota"))
        {
            Destroy(gameObject);
        }
    }
}

