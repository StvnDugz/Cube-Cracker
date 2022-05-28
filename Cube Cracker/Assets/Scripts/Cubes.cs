using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    public GameObject cubeParticleEffect;

    void OnCollisionEnter(Collision other)
    {
        Instantiate(cubeParticleEffect, transform.position, Quaternion.identity);
        GameManager.instance.DestroyCube();
        Destroy(gameObject);
    }
}
