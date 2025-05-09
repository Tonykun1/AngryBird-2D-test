using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Slingshot : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPosition;
    public Transform center;
    public Transform idlePosition;
    public Vector3 currentPosition;
    public float maxLength;
    public float bottomBoundary;
    public GameObject birdPrefab;

    public TextMeshProUGUI scoreText; 
    private int score = 0; 

    Rigidbody2D bird;
    Collider2D birdCollider;
    public float birdPositionOffSet;
    public float force;
    bool isMouseDown;
    public bool grounded;

    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPosition[0].position);
        lineRenderers[1].SetPosition(0, stripPosition[1].position);

        CreateBird();
       
    }

    void CreateBird()
    {
        bird = Instantiate(birdPrefab).GetComponent<Rigidbody2D>();
        birdCollider = bird.GetComponent<Collider2D>();

        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
        cameraFollow.SetBird(bird.transform);
        grounded = false;
    }

    void Update()
    {
        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);
            currentPosition = ClampBoundary(currentPosition);
            SetStrips(currentPosition);
        }
        else
        {
            ResetStrips();
        }
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        Shoot();
        currentPosition = idlePosition.position;
    }

    void Shoot()
    {
        Vector3 birdForce = (currentPosition - center.position) * force * -1;
        bird.velocity = birdForce;
        grounded = true;

        bird = null;
        birdCollider = null;
        Invoke("CreateBird", 2);

    }

    void ResetStrips()
    {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);
        if (bird)
        {
            Vector3 dir = position - center.position;
            bird.transform.position = position + dir.normalized * birdPositionOffSet;
            bird.transform.right = -dir.normalized;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdCollider&& collision.gameObject.CompareTag("Target"))
        {
            ScoreMeneger.Instance.AddPoint();
            Destroy(collision.gameObject);
            Debug.Log(collision.gameObject + " Target");
        }
    }
    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.x = Mathf.Clamp(vector.x, -8, 8);
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 5);
        return vector;
    }
    



}
