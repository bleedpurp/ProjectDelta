using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            var shootingComponent = collision.gameObject.GetComponent<Shooting>();
            shootingComponent.canTripleShot = true;
            Destroy(gameObject);
        }
    }

    void Pickup() 
    {
        
    }
}
