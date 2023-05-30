using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = transform;
    }

    private void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        playerTransform.position += movement * moveSpeed * Time.deltaTime;

        // Aiming
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(playerTransform.localPosition);
        Vector2 aimDirection = (mousePosition - screenPoint).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        playerTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
