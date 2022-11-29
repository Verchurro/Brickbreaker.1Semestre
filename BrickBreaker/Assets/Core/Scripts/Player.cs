using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Rigidbody2D board;
    [SerializeField] public float speed = 1f;
    Vector3 mousePosition;
    Vector2 position = new Vector2 (0, 0);
   
    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, speed);
        position.y = -4.12f;
    }

    private void FixedUpdate()
    {
        board.MovePosition(position);
    }
    private void Start()
    {
        board = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.AddComponent<Ball>();
        if (ball != null)
        {
            Vector3 playerPosition = this.transform.position;
            Vector2 contactpoint = collision.GetContact(0).point;

            float offset = playerPosition.x - contactpoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
        }
    }

}
