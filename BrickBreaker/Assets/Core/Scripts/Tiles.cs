using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
  
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] states;
    public int health { get; private set; }
    public int points = 100;
    [SerializeField] GameObject powerUp;
    [SerializeField] GameObject shrink;

    public void ResetTiles()
    {
       this.gameObject.SetActive(true);
        
        health = states.Length;
        spriteRenderer.sprite = states[health - 1];
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ResetTiles();
    }

    public void Hit()
    {
        health--;

        if (health <= 0)
        {
            //power up drops
            if (Random.value>0.5f)
            {

                if(Random.value>0.7f)
                {
                    Instantiate(powerUp, transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(shrink, transform.position, transform.rotation);
                }
            }
            //destroys brick
           gameObject.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = states[health - 1];
        }

        FindObjectOfType<GameManager>().Hit(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }

}
