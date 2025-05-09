using UnityEngine;

public class TargetItems : MonoBehaviour
{
    private bool hasBeenHit = false;
    public bool ground = false;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            hasBeenHit = true;
        }
        else if (collision.gameObject.CompareTag("Ground") && hasBeenHit)
        {
            ground = true;
            ScoreMeneger.Instance.AddPoint();
        }
    }
}
