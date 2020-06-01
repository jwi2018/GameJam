using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeChat : MonoBehaviour
{
    private bool state;

    void Start()
    {
        state = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (state == true)
            {
                gameObject.SetActive(true);
                
                state = true;
            }
            else
            {
                gameObject.SetActive(false);
               
                state = false;
            }
        }
    }
}