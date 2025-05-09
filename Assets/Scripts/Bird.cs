using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool hasBeenHit = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasBeenHit && collision.gameObject.CompareTag("Target"))
        {
           
            hasBeenHit = true;
        }
    }
}
