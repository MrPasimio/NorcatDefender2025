using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int pointValue = 10;
    public GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            Die();
        }

        else if(collision.gameObject.CompareTag("Player"))
        {
            GameOver();
        }
    }

    public void Die()
    {
        gm.AddScore(pointValue);
        Destroy(gameObject);
    }

    public void GameOver()
    {
       StartCoroutine(gm.GameOver());
        Debug.Log("Game Over");
    }
}
