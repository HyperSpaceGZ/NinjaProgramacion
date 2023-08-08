using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Ienemybulletdstry;

public class EnemyAI : MonoBehaviour, Ienemydmg
{
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] protected NavMeshAgent EnemyNavMesh;
    [SerializeField] protected bool hastriggered;

    [SerializeField] protected Animator animator; 

    [SerializeField] protected int enemyHP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Sets the destination to the player ONLY ONCE when it gets inside the trigger.
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
        }
    }

    private void EnemyFollowerMovement()
    {
        //Set Enemy destionation to the player's position
        EnemyNavMesh.SetDestination(PlayerTransform.position);
        animator.SetBool("IsWalking", true);
    }

    public void NavMeshStart()
    {
        //Gets the enemy navmesh and animator components 
        EnemyNavMesh = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        //Fixes a bug where the sprite is in the wrong rotation
        EnemyNavMesh.updateRotation = false;
        EnemyNavMesh.updateUpAxis = false;

        hastriggered = false;

        //Gets the players transform for the navigation AI
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void EnemyDamage()
    {
        //Deals damage to the enemy, and if enemyHP is lower or equal to zero, it destroys the enemy
        enemyHP--;
        if(enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
