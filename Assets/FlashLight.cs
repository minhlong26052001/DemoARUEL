using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Light myLight;
     
     
    void StartFlashLight ()
    {
        myLight = GetComponent<Light>();
    }
     
    void UpdateFlashLight ()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            myLight.enabled = !myLight.enabled;
        }
    }
}
