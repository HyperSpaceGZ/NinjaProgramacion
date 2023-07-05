using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private EnemyAI enemy;

    //void Start()
    //{
        //enemy = GameObject.FindObjectOfType<EnemyAI>().EnemyDmg();
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ienemydmg>()!= null)
        {
            collision.gameObject.GetComponent<Ienemydmg>().EnemyDamage();
        }
      
    }
}
