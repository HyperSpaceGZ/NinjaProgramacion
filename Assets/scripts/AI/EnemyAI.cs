using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private NavMeshAgent EnemyNavMesh;
    [SerializeField] private bool hastriggered;

    public Animator animator;

    public int enemyHP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Sets the destination to the player ONLY ONCE when it gets inside the trigger.
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            animator.SetBool("IsWalking", true);
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
        }
    }

    private void EnemyFollowerMovement()
    {
        EnemyNavMesh.SetDestination(PlayerTransform.position);
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
    

}
