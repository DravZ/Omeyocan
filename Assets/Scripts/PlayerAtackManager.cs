using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtackManager : MonoBehaviour
{
    [SerializeField] private int hitDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyLifeManager>().GetDamage(hitDamage);
        }
    }
}
