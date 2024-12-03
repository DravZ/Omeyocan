using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private float life;

    private void Start()
    {
        
    }

    public void GetDamage(float damage) { 
        life -= damage;

        Debug.Log("Player tomo daño");

        if(life < 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        Debug.Log("Player Murio");
    }
}
