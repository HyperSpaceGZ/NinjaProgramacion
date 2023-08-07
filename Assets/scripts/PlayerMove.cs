using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Ienemybulletdstry;
using static IhealPlayer;

public class PlayerMove : MonoBehaviour, Ienemybulletdtry, Ihealplayer
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    public int playerhalth;
    //troleando
    public int lifeRealTime;
    public List<Image> hearts;

    //power Up DoubleShoot
    public GameObject DoubleShootCanyon;
    private bool isDoubleShootActive = false;
    public float DoubleShootTime = 10f;

    //power up FourShoot
    public GameObject[] FourCanyons;
    private bool isFourShootActive = false;
    public float FourShootTime = 10f;

    




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //trrolling
        lifeRealTime = playerhalth;
        refreshUI();
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
    }

    private void FixedUpdate()
    {
        // Apply movement using Rigidbody
        rb.velocity = movement * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // get power up double shoot
        if (collision.gameObject.CompareTag("DoubleShoot"))
        {
            ActivateDoubleShootCanyon();
            Destroy(collision.gameObject);
        }

        // get power up four shoots
        if (collision.gameObject.CompareTag("FourShoots"))
        {
            ActivateFourShootCantons();
            Destroy(collision.gameObject);
        }
    }


    //power ups corutines
    void ActivateDoubleShootCanyon()
    {
        if (!isDoubleShootActive)
        {
            StartCoroutine(ActivateAndDeactivateObjectCoroutine());
        }
    }

    void ActivateFourShootCantons()
    {
        if (!isFourShootActive)
        {
            StartCoroutine(ActivateAndDeactivateObjectFour());
        }
    }

    IEnumerator ActivateAndDeactivateObjectCoroutine()
    {
        //double shoot
        DoubleShootCanyon.SetActive(true);
        isDoubleShootActive = true;
        yield return new WaitForSeconds(DoubleShootTime);
        DoubleShootCanyon.SetActive(false);
        isDoubleShootActive = false;


    }
    IEnumerator ActivateAndDeactivateObjectFour()
    {
        //four shoots
        foreach (GameObject cannon in FourCanyons)
        {
            cannon.SetActive(true);
        }
        isFourShootActive = true;
        yield return new WaitForSeconds(FourShootTime);
        foreach (GameObject cannon in FourCanyons)
        {
            cannon.SetActive(false);
        }
        isFourShootActive = false;


    }

    public void PlayerDmg()
    {


        playerhalth--;

        

        lifeRealTime = Math.Clamp(lifeRealTime, 0, playerhalth);
        refreshUI();
        
        
    }

    public void PlayerHealing()
    {
        playerhalth++;
    }

    private void refreshUI()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if(i < lifeRealTime)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        } 
    }

    
}
