using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // public GameObject hitEffect;

    private void OnBecameInvisible()
    {
        // Destroy the game object when it goes off screen
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        var enemy = collision.collider.GetComponent<EnemyBehaviour>();
        if(enemy)
        {
            enemy.TakeHit(1);
        }

        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        // Destroy(effect, 5f);
    }
}
