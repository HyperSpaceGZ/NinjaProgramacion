using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    private int playerhalth;


    //power Up
    public GameObject DobleShootCanyon;
    private bool isDoubleShootActive = false;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical);
        movement.Normalize();

        // Aiming
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 aimDirection = (mousePosition - screenPoint).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward); // Modify this line

        // Set the "isMoving" parameter in the Animator controller
        animator.SetBool("isMoving", movement.magnitude > 0f);


        //doble shot
        
    }

    private void FixedUpdate()
    {
        // Apply movement using Rigidbody
        rb.velocity = movement * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerLooseHP();
        }

        if (collision.gameObject.tag == "enemybullet")
        {
            PlayerLooseHP();
        }

        if (collision.gameObject.tag == "EnemyMonsterAttack")
        {
            PlayerLooseHP();
            PlayerLooseHP();
        }

        if (collision.gameObject.tag == "EnemyElite")
        {
            PlayerLooseHP();
            PlayerLooseHP();
        }

        // get power up
        if(collision.gameObject.CompareTag("PowerUp"))
        {
            ActivateDoubleShootCanyon();
            Destroy(collision.gameObject);
        }
    }

    void ActivateDoubleShootCanyon()
    {
        if (!isDoubleShootActive)
        {
            StartCoroutine(ActivateAndDeactivateObjectCoroutine());
        }
    }

    IEnumerator ActivateAndDeactivateObjectCoroutine()
    {
        DobleShootCanyon.SetActive(true);
        isDoubleShootActive = true;
        yield return new WaitForSeconds(10f);
        DobleShootCanyon.SetActive(false);
        isDoubleShootActive = false;
    }


    public void PlayerLooseHP()
    {
        playerhalth--;
    }
}
