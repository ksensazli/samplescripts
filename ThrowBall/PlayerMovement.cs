using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    private inputBall inputball;
    public float forwardForce = 1f;
    [SerializeField] private float movementSpeed = 0.5f;
    [SerializeField] private float maxMovementAmount = 1f;
    [SerializeField] ParticleSystem dustEffect = null;
    
    public float jumpForce = 300f;
    float moveAmount;
    // Start is called before the first frame update
    private void Awake()
    {
        inputball = GetComponent<inputBall>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveAmount = Time.deltaTime * movementSpeed * inputball.MoveFactorX;
        moveAmount = Mathf.Clamp(moveAmount, -maxMovementAmount, maxMovementAmount);
        transform.Translate(moveAmount, 0, 0);
        rb.MovePosition(rb.position + Vector3.forward * forwardForce * Time.fixedDeltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(Vector3.up * jumpForce);
        dustEffect.Play();
    }
}
