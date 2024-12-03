using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackManager : MonoBehaviour
{
    [SerializeField] private int hitDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.GetComponent<LifeManager>().GetDamage(hitDamage);
        }
    }

}
