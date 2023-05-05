// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Shooting : MonoBehaviour
// {
//     public int numberOfBullets = 1;
//     public float bulletSpeed = 20f;
//     public GameObject bulletPrefab;
//     private Vector3 firePoint;
//     private const float radius = 1f;

//     // Update is called once per frame
//     void Update()
//     {
//         if(Input.GetButtonDown("Fire1"))
//         {
//             firePoint = transform.position;
//             SpawnBullet(numberOfBullets);
//         }
//     }

//     private void SpawnBullet(int _numberOfBullets)
//     {
//         float angleStep = 360f / _numberOfBullets;
//         float angle = 0f;

//         for (int i = 0; i <= _numberOfBullets - 1; i++)
//         {
//             float bulletDirXPosition = firePoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
//             float bulletDirYPosition = firePoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

//             // Create vectors.
//             Vector3 bulletVector = new Vector3(bulletDirXPosition, bulletDirYPosition, 0);
//             Vector3 bulletMoveDirection = (bulletVector - firePoint).normalized * bulletSpeed;

//             // Create game objects.
//             GameObject tmpObj = Instantiate(bulletPrefab, firePoint, Quaternion.identity);
//             tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(bulletMoveDirection.x, 0, bulletMoveDirection.y);

//             // Destory the gameobject after 10 seconds.
//             Destroy(tmpObj, 10F);

//             angle += angleStep;
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool canTripleShot;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(canTripleShot)
            {
                tripleShot();
            }
            else
            {
                singleShot();
            }
        }
    }

    void singleShot() 
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void tripleShot()
    {
        for(int i = -1; i < 2; i++) // repeat 3 times
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0f, 0f, i * 15f));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); // get existing rigidbody component
            rb.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
