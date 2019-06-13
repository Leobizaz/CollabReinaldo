using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableOBJ : MonoBehaviour
{
    public GameObject fxDestroy;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Character1_LeftHand" || other.gameObject.name == "Character1_RightHand")
        {
            gameObject.SetActive(false);
            Instantiate(fxDestroy, transform.position, Quaternion.identity);
        }
    }
}
