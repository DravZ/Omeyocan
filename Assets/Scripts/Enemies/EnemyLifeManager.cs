using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour
{
    [SerializeField] private float life;

    private void Start()
    {

    }

    public void GetDamage(float damage)
    {
        life -= damage;

        Debug.Log("Enemigo tomo daño");

        if (life < 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        Debug.Log("Enemigo Murio");
        Destroy(gameObject);
    }
}
