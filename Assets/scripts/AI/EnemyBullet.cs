using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Ienemybulletdstry;

public class EnemyBullet : MonoBehaviour
{
    public float BulletSpawnedTime;
    public float BulletDespawnTime;
    void Update()
    {
        //Sets a timer based on Delta Time to destroy the bullet
        BulletSpawnedTime += Time.deltaTime;
        if (BulletSpawnedTime >= BulletDespawnTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy "Bullet" Collisions
        if (collision.gameObject.CompareTag("wall"))
        {
            DestroyBullet();
        }

        if (collision.gameObject.CompareTag("Heal"))
        {
            DestroyBullet();
        }

        if (collision.gameObject.GetComponent<Ienemybulletdtry>() != null)
        {
            collision.gameObject.GetComponent<Ienemybulletdtry>().PlayerDmg();
            DestroyBullet();
        }

    }

    public void DestroyBullet()
    {
        //Destroys the object
        Destroy(this.gameObject);
    }
}
