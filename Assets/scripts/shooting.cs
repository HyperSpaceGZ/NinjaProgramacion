using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform spawnPosition;

    public GameObject bulletPrefab;

    public float bulletForce;

    public float bulletLifetime = 2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {







            GameObject bulletClone = Instantiate(bulletPrefab, spawnPosition.position, spawnPosition.rotation);



            Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();



            rb.AddRelativeForce(Vector3.up * bulletForce, ForceMode2D.Impulse);

            Destroy(bulletClone, bulletLifetime);




        }
    }
}
