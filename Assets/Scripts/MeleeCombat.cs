using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    [SerializeField] private float hitDamage;

    [SerializeField] private GameObject normalAtack;
    private Transform trfNormalaAtack;
    [SerializeField] private SpriteRenderer spRendNormalAtack;

    private void Start()
    {
        normalAtack.SetActive(false);
        trfNormalaAtack = normalAtack.GetComponent<Transform>();
    }

    public void NormalHit()
    {
        normalAtack.SetActive(true);
        if(spRendNormalAtack.flipX)
        {
            //Debug.Log("Fliepeado");
            trfNormalaAtack.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            //Debug.Log("No Fliepeado");
            trfNormalaAtack.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

    } 
    public void EndNormalHit()
    {
        normalAtack.SetActive(false);
    }
}
