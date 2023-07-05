using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float BulletSpawnedTime;
    public float BulletDespawnTime;
    void Update()
    {
        BulletSpawnedTime += Time.deltaTime;
        if (BulletSpawnedTime >= BulletDespawnTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            DestroyBullet();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyBullet();
        }

    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
