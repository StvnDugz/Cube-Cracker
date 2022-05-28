using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLifeTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameManager.instance.LoseLife();
    }
}
