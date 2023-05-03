using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float maxHitpoints = 5;
    public HealthBarBehaviour HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = maxHitpoints;
        HealthBar.setHealth(Hitpoints, maxHitpoints);
    }

    public void TakeHit(float damage) 
    {
        Hitpoints -= damage;
        HealthBar.setHealth(Hitpoints, maxHitpoints);

        if(Hitpoints <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
