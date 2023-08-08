using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nextLVL : MonoBehaviour
{
    public delegate void Level1Event();
    public static Level1Event level1event;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            level1event?.Invoke();
        }
    }
}
