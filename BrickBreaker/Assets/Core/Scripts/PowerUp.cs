using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Rigidbody2D powerUp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Player")
            {
            Destroy(gameObject);
          // collision.gameObject.GetComponent<> 
            }
    }
}
