using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenInstance : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Slingshot player = collision.gameObject.GetComponent<Slingshot>();

            if (player != null)
            {
                RemoveToken(player);
                ScoreMeneger.Instance.AddPoint();
            }
        }
    }

    void RemoveToken(Slingshot player)
    {
        Destroy(gameObject); 
    }
}
