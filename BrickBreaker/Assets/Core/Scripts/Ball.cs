using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D ball { get; set; }
    public float speed = 500f;

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-0.5f, 0.5f);
        force.y = -1f;
        ball.AddForce(force.normalized * speed);
    }
    private void Awake()
    {
        ball = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    void Update()
    {
        
    }
}
