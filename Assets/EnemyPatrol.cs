using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    Transform[] ways;
    public GameObject player;
    public GameObject wayfather;
    public ParticleSystem weapons;
    public AudioSource audioFire;
    public bool playerFound;
    bool coroutineStarted;
    bool cooldown;
    int indexway = 0;

    void Start()
    {
        ways = wayfather.GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        Vector3 dir = ways[indexway].position - transform.position;
        Quaternion newrot = Quaternion.LookRotation(dir);
        if (!playerFound)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, newrot, Time.deltaTime);
            transform.Translate(Vector3.forward * Time.deltaTime * 2);
            if (Vector3.Distance(transform.position, ways[indexway].position) < 2)
            {
                indexway++;
                if (indexway == ways.Length) indexway = 0;
            }
        }

        if (Vector3.Distance(transform.position, player.transform.position) < 6) playerFound = true;
        if(Vector3.Distance(transform.position, player.transform.position) > 7)
        {
            playerFound = false;
        }

        if (playerFound && !cooldown)
        {
            Vector3 lookDir = player.transform.position - transform.position;
            lookDir = new Vector3(lookDir.x, lookDir.y + 1f, lookDir.z);
            newrot = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, newrot, Time.deltaTime * 4);
            //transform.LookAt(player.transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime * 3);
        }

    }

    IEnumerator WeaponsRange()
    {
        coroutineStarted = true;
        Shoot();
        yield return new WaitForSeconds(0.2f);
        Shoot();
        yield return new WaitForSeconds(0.2f);
        Shoot();
        StopCoroutine("WeaponsRange");

    }

    void Shoot()
    {
        weapons.Emit(1);
        audioFire.Play();
    }

    void EndCooldown()
    {
        coroutineStarted = false;
        cooldown = false;
    }
}
