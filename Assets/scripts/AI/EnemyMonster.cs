using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonster : EnemyAI
{
    [SerializeField] private Transform Spawner1;
    [SerializeField] private Transform Spawner2;
    [SerializeField] private Transform Spawner3;
    [SerializeField] private Transform Spawner4;

    public GameObject RangeAttackObj;
    [SerializeField] private float RangeAttackForce = 10f;

    void Start()
    {
        NavMeshStart();

        //Gets the transform component for each empty to spawn all the bullets
        Spawner1 = transform.GetChild(1);
        Spawner2 = transform.GetChild(2);
        Spawner3 = transform.GetChild(3);
        Spawner4 = transform.GetChild(4);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Sets the destination to the player ONLY ONCE when it gets inside the trigger.
        if (hastriggered == false && collision.gameObject.tag == "Player")
        {
            hastriggered = true;
            InvokeRepeating("GuardianAttack", 1f, 2.5f);
            InvokeRepeating("GuardianAttackAnimationExit", 1.5f, 2.5f);
            InvokeRepeating("EnemyFollowerMovement", 0f, 0.02f);
        }
    }

    private void GuardianAttack()
    {
        //Instantiates 4 ranged attacks from each empty object inside the Enemy
        
        //Spawner1
        GameObject RangeAttackClone1 = Instantiate(RangeAttackObj, Spawner1.position, Spawner1.rotation);
        Rigidbody2D rb1 = RangeAttackClone1.GetComponent<Rigidbody2D>();
        rb1.AddRelativeForce(Vector3.up * RangeAttackForce, ForceMode2D.Impulse);

        //Spawner2
        GameObject RangeAttackClone2 = Instantiate(RangeAttackObj, Spawner2.position, Spawner2.rotation);
        Rigidbody2D rb2 = RangeAttackClone2.GetComponent<Rigidbody2D>();
        rb2.AddRelativeForce(Vector3.up * RangeAttackForce, ForceMode2D.Impulse);

        //Spawner3
        GameObject RangeAttackClone3 = Instantiate(RangeAttackObj, Spawner3.position, Spawner3.rotation);
        Rigidbody2D rb3 = RangeAttackClone3.GetComponent<Rigidbody2D>();
        rb3.AddRelativeForce(Vector3.up * RangeAttackForce, ForceMode2D.Impulse);

        //Spawner3
        GameObject RangeAttackClone4 = Instantiate(RangeAttackObj, Spawner4.position, Spawner4.rotation);
        Rigidbody2D rb4 = RangeAttackClone4.GetComponent<Rigidbody2D>();
        rb4.AddRelativeForce(Vector3.up * RangeAttackForce, ForceMode2D.Impulse);

        //Sets the animation
        animator.SetBool("IsAttacking", true);
    }

    private void GuardianAttackAnimationExit()
    {
        animator.SetBool("IsAttacking", false);
    }
}
