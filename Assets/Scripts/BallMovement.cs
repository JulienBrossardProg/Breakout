using System;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody ballRigidbody;
    [SerializeField] private float startVelocity = -1;
    [SerializeField] private float speed = 5;
    [SerializeField] private Vector3 lastVelocity;
    [SerializeField] private Transform padelTransform;


    private void Start()
    {
        ballRigidbody.velocity = new Vector3(ballRigidbody.velocity.x, startVelocity, ballRigidbody.velocity.z )*speed;
        lastVelocity = ballRigidbody.velocity.normalized;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Padel"))
        {
            Movement((other.contacts[0].normal+new Vector3(0,0,transform.position.z-padelTransform.position.z)).normalized); 
        }
        else
        {
            Movement(other.contacts[0].normal.normalized);
        }
    }

    void Movement(Vector3 normal)
    {
        ballRigidbody.velocity = Vector3.Reflect(lastVelocity.normalized, normal.normalized)*speed;
        lastVelocity = ballRigidbody.velocity;
        Debug.DrawRay(transform.position,ballRigidbody.velocity.normalized, Color.green, 5 );
        Debug.DrawRay(transform.position,normal, Color.red, 5 );
    }
}
