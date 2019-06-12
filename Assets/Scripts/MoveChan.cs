using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChan : MonoBehaviour
{

    CharacterController charctrl;
    Animator anim;
    Vector3 movaxis,turnaxis;
     void Start()
    {
        charctrl=GetComponent<CharacterController>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movaxis=new Vector3(0,0,Input.GetAxis("Vertical"));
        turnaxis=new Vector3(0,Input.GetAxis("Horizontal"),0);
    }
    void FixedUpdate(){
        charctrl.SimpleMove(transform.TransformDirection(movaxis*4));
        charctrl.transform.Rotate(turnaxis);
        anim.SetFloat("Speed",charctrl.velocity.magnitude);
        anim.SetFloat("Turn",turnaxis.y);

       if(Input.GetButtonDown("Fire1")){
           anim.SetTrigger("Punch");
       }
    }
     
}
