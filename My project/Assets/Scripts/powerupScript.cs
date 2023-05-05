using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            Pickup();
        }
    }

    void Pickup() 
    {
        Debug.Log("power up picked up");
    }
}
