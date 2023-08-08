using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Ienemybulletdstry;
using static IhealPlayer;

public class HealingItem : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ihealplayer>() != null)
        {
            collision.gameObject.GetComponent<Ihealplayer>().PlayerHealing();
            Destroy(this.gameObject);
        }
    }
}
