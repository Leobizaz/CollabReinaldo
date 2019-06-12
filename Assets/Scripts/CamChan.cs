using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChan : MonoBehaviour
{
    public GameObject player;
    public float height,distance,heightfocus,ajust=1;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dir=player.transform.position+Vector3.up*heightfocus-transform.position;
        Vector3 postogo=player. transform.position+ Vector3.up*height + player.transform.forward*distance;
        
        transform.rotation=Quaternion.LookRotation(dir);

        RaycastHit hit;
        if(Physics.Raycast(player.transform.position+ Vector3.up*height,
        player.transform.forward*distance+Vector3.up*heightfocus,out hit,10))
        {
               postogo=hit.point+hit.normal*ajust; 
              
        }


        transform.position=Vector3.Lerp(transform.position,postogo,Time.smoothDeltaTime);
    }
}
