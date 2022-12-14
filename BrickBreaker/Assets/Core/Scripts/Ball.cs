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

    public void ResetBall()
    {
        this.transform.position = Vector2.zero;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Invoke(nameof(SetRandomTrajectory), 1f);
    }
    private void Awake()
    {
        ball = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Tile = collision.gameObject.GetComponent<Tiles>();
        if (Tile != null)
        {
            Tile.Hit();
        }

        if (ball.velocity.y < 1f && ball.velocity.y > -1f && ball.velocity.x < 1f && ball.velocity.x > -1f)
        {
            Vector3 direction = ball.velocity.normalized;
            direction.x = Random.Range(-5f, 5f);
            direction.y = Random.Range(0f, 5f);
            ball.AddForce(direction.normalized * speed * ball.velocity.magnitude);
        }
    }

    void FixedUpdate()
    {
        if (ball.velocity.magnitude > speed)
        {
            ball.velocity = ball.velocity.normalized * speed;
        }
    }
}
