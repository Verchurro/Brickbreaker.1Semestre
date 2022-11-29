using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tiles : MonoBehaviour
{
    public Tilemap breakBricks;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Ball"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                breakBricks.SetTile(breakBricks.WorldToCell(hit.point), null);
                breakBricks.RefreshAllTiles();
                Debug.Log("World");
            }

            Debug.Log("Hit");
        }

    }
    private void Start()
    {
        breakBricks = GetComponent<Tilemap>();
    }
}
