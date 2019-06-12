using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light mylight;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        DayTime.instance.DawnCall+=TurnOn;
        DayTime.instance.DuskCall+=TurnOff;
    }

    void TurnOn(){
       Invoke("LightOn",Random.Range(0,3));
    }
    void TurnOff(){
        Invoke("LightOff",Random.Range(0,3));
        
    }
    
    void LightOn(){
        rend.materials[1].EnableKeyword("_EMISSION");
        mylight.enabled=true;

    }
    void LightOff(){
        rend.materials[1].DisableKeyword("_EMISSION");
        mylight.enabled=false;
        
    }
}
