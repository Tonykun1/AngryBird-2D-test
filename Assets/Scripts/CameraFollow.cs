using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform bird;
    public Vector3 offset;
    public float followSpeed = 5f;
    public Vector3 initialPosition;

    // גבולות המצלמה
    public float minX, maxX, minY, maxY;

    void Start()
    {
        initialPosition = transform.position;

        if (bird != null)
        {
            offset = transform.position - bird.position;
        }
    }

    void Update()
    {
        if (bird != null)
        {
            if (bird.GetComponent<Rigidbody2D>().velocity.magnitude > 0.1f)
            {
                Vector3 targetPosition = bird.position + offset;

                // להבטיח שהמצלמה לא יוצאת מהגבולות
                targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
                targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

                transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, followSpeed * Time.deltaTime);
        }
    }

    public void SetBird(Transform newBird)
    {
        bird = newBird;
    }
}
