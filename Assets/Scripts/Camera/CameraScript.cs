using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Target;
    private Vector3 TargetPos;


    public float FrontMargin;
    public float TopMargin;
    public float Smoothing;

    //private bool hasFlip = false;

    private SpriteRenderer targetRenderer;
    // Start is called before the first frame update
    void Start()
    {
        targetRenderer = Target.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        TargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y + TopMargin, transform.position.z);

        if (targetRenderer.flipX)
        {
            //Debug.Log("Esta flipeado");
            TargetPos = new Vector3(TargetPos.x - FrontMargin, TargetPos.y, transform.position.z);
            
        }
        else
        {
            //Debug.Log("No esta flipeado");
            TargetPos = new Vector3(TargetPos.x + FrontMargin*2, TargetPos.y, transform.position.z);
            
        }

        transform.position = Vector3.Lerp(transform.position, TargetPos, Smoothing * Time.deltaTime);
        
    }
}
