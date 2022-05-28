using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float paddleSpeed = 1f;

    void Update()
    {
        float xPosition = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        Vector3 playerPos = new Vector3(Mathf.Clamp(xPosition, -8f, 8f), -9.5f, 0);
        transform.position = playerPos;
    }

}
