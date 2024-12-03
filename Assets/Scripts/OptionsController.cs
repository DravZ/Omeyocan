using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private GameObject map;
    private bool isMapActive;

    [SerializeField] private GameObject bestiary;
    private bool isBestActive;
    // Start is called before the first frame update
    void Start()
    {
        isMapActive = false;
        isBestActive = false;
        map.SetActive(false);
        bestiary.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            Debug.Log("Abri Bestiario");
            map.SetActive(true);
            isMapActive = true;
        }
        if(Input.GetKeyDown("b")) {
            Debug.Log("Abri Mapa");
            bestiary.SetActive(true) ;
            isBestActive = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isMapActive)
            {
                map.SetActive(false);
            }
            if(isBestActive)
            {
                bestiary.SetActive(false);
            }
        }
    }
}
