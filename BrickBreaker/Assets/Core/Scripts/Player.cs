using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Rigidbody2D board;
    [SerializeField] public float speed = 1f;
    public Vector2 direction { get; private set; }
    public float maxBounceAngle = 75f;
    Vector3 mousePosition;
    Vector2 position = new Vector2 (0, 0);
   
    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, speed);
        position.y = -4.12f;
    }

    public void ResetPlayer()
    {
        this.transform.position = new Vector2(0f, this.transform.position.y);
        board.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector3 playerPosition = this.transform.position;
            Vector2 contactpoint = collision.GetContact(0).point;

            float offset = playerPosition.x - contactpoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.GetComponent<Rigidbody2D>().velocity);
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.up * ball.GetComponent<Rigidbody2D>().velocity.magnitude;
        }

        if (collision.gameObject.tag == "PowerUp")
        {
            transform.localScale = new Vector3(0.6f, 0.4f, 0.4f);
        }

        if (collision.gameObject.tag == "Shrink")
        {
            transform.localScale = new Vector3(0.2f, 0.4f, 0.4f);
        }
    }

}
