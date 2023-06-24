using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : EnemyAI
{  
    // Start is called before the first frame update
    void Start()
    {
        NavMeshStart();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collisions when is hits or hits the player
        if (collision.gameObject.tag == "bullet")
        {
            enemyHP--;
        }

        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("IsAttacking", true);   
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("IsAttacking", false);
        }
    }
}
