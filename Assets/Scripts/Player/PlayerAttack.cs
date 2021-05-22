using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{


    
    public void OnTriggerEnter2D(Collider2D collision)
    {
         if (gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyAI>().ApplyDamage(5);
        }
    }
}
