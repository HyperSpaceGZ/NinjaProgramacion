using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private NavMeshAgent EnemyNavMesh;
    [SerializeField] private bool hastriggered;

    // Start is called before the first frame update
    void Start()
    {
        EnemyNavMesh = GetComponent<NavMeshAgent>();
        EnemyNavMesh.updateRotation = false;
        EnemyNavMesh.updateUpAxis = false;

        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyNavMesh.SetDestination(PlayerTransform.position);
    }
}
