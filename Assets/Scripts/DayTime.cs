using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour
{
    public float daySeconds;
    public float daySpeed=1;
    float radday;
    float intensity;
    Light mylight;
    public Gradient nightdaycolor;
    public delegate void Dawn();
    public delegate void Dusk();
    public Dawn DawnCall;
    public Dusk DuskCall;
    public static DayTime instance;
    bool day =false;
    void Awake()
    {
        instance=this;
    }
    void Start()
    {
        DawnCall+=Sunset;
        DuskCall+=Sunrise;
        mylight=GetComponent<Light>();
    }
    void Update()
    {
        daySeconds+=Time.deltaTime*daySpeed;
        radday=daySeconds/(86400/2);
        transform.localRotation=Quaternion.Euler(radday*(180/Mathf.PI),0,0);
        intensity= Mathf.Clamp01(Vector3.Dot(transform.forward,Vector3.down)+0.2f);
        RenderSettings.ambientLight=nightdaycolor.Evaluate(intensity);
        mylight.intensity=intensity*1.3f;
        if(intensity>0.4f && day){
            DuskCall();
            day=false;
        }
        if(intensity<0.4f && !day){
            DawnCall();
             day=true;
        }

    }
    void Sunrise(){
            print("Good Day");
    }
    void Sunset(){
             print("Good Night");
    }
}
