using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
   
      void OnCollisionEnter(Collision other)
    {
        
        if(other.rigidbody!=null){
            other.rigidbody.AddForce(-transform.right*
            other.relativeVelocity.magnitude);
           
        }
    }
}
