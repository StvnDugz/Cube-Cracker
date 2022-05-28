using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballInitialVelocity = 600f;
    public AudioSource hitSound;
    private Rigidbody rb;
    private bool ballInPlay;
    private const float LowPitch = .5f;
    private const float HighPitch = 1.5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            hitSound.pitch = Random.Range(LowPitch, HighPitch);
            hitSound.Play();
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    }
    void OnCollisionEnter(Collision other)
    {
        hitSound.pitch = Random.Range(LowPitch, HighPitch);
        hitSound.Play();
    }
}
