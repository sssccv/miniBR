using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{
    public float minSpeedX, minSpeedZ, maxAbsoluteSpeed;
    public float speedIncremen;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 randomVector = Random.onUnitSphere;
        randomVector.y = 0f;
        rb.velocity = randomVector.normalized;
    }

    private void FixedUpdate()
    {
        LimitVelocity();
        
    }

    void LimitVelocity()
    {
        Vector3 velocity = rb.velocity;
        float signVx = Mathf.Sign(velocity.x);
        float signVz = Mathf.Sign(velocity.z);

        if (Mathf.Abs(velocity.x) < minSpeedX)
        {
            rb.velocity = new Vector3(signVx*minSpeedX,0,velocity.z);
        }
        if (Mathf.Abs(velocity.z)< minSpeedZ)
        {
            rb.velocity = new Vector3(velocity.x, 0, signVz * minSpeedZ);
        }
        if (rb.velocity.magnitude > maxAbsoluteSpeed)
        {
            rb.velocity = maxAbsoluteSpeed * (rb.velocity.normalized);
        }

        if (minSpeedX >=maxAbsoluteSpeed)
        {
            minSpeedX = maxAbsoluteSpeed;
        }
        if (minSpeedZ >=maxAbsoluteSpeed)
        { minSpeedZ = maxAbsoluteSpeed;}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pared"))
        {
            minSpeedX += speedIncremen;
            minSpeedZ += speedIncremen;
        }
    }

    public void ResetShell()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = Vector3.zero;

        Vector3 randomVector = Random.onUnitSphere;
        randomVector.y = 0f;
        rb.velocity = randomVector.normalized;

  

    }
}
