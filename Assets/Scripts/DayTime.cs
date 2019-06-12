using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour
{
    public delegate void Dawn();
    public delegate void Dusk();
    public Dawn DawnCall;
    public Dusk DuskCall;
    private TOD_Sky sky;
    public static DayTime instance;
    bool day =false;
    void Awake()
    {
        instance=this;
        sky = GetComponent<TOD_Sky>();
    }
    void Start()
    {
        DawnCall+=Sunset;
        DuskCall+=Sunrise;
    }
    void Update()
    {
        if (sky.Cycle.Hour > 7 && sky.Cycle.Hour < 19) DuskCall();
        else DawnCall();

    }
    void Sunrise(){
            print("Good Day");
    }
    void Sunset(){
             print("Good Night");
    }
}
