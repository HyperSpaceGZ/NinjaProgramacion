using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform Spawner1;
    [SerializeField] private Transform Spawner2;
    [SerializeField] private Transform Spawner3;
    [SerializeField] private Transform Spawner4;

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
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }


}
