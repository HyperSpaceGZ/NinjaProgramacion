using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    //bullet effect
    public GameObject hitEffect;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ienemydmg>()!= null)
        {
            collision.gameObject.GetComponent<Ienemydmg>().EnemyDamage();
        }

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.12f);
        Destroy(gameObject);

    }
}
