using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
       //if(gameObject.CompareTag("Ball"))
        { 
         // FindObjectOfType<GameManager>().Miss();

        }
        
       if (!other.gameObject.CompareTag("Ball")) return;
        {
           SceneManager.LoadScene("GameOver");
        }


        
    }
}
