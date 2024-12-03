using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkInRange : MonoBehaviour
{
    public static bool isPlayerDetected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Voy a atacar");
            isPlayerDetected = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Ya no voy a atacar");
            isPlayerDetected = false;
        }
    }
}
