using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Ienemybulletdstry;

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
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("IsAttacking", true);   
        }

        if(collision.gameObject.GetComponent<Ienemybulletdtry>() != null)
        {
            collision.gameObject.GetComponent<Ienemybulletdtry>().PlayerDmg();
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
