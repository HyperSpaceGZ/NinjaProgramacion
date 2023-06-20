using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private NavMeshAgent EnemyNavMesh;
    [SerializeField] private bool hastriggered;

    [SerializeField] private int enemyHP;
 

    void Start()
    {
        EnemyNavMesh = GetComponent<NavMeshAgent>();
        EnemyNavMesh.updateRotation = false;
        EnemyNavMesh.updateUpAxis = false;

        hastriggered = false;

        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
        }
    }

    private void EnemyFollowerMovement()
    {
        EnemyNavMesh.SetDestination(PlayerTransform.position);
    }

}
