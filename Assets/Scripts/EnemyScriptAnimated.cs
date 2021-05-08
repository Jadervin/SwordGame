﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScriptAnimated : EnemyScript
{
    [Header("Animated Attributes")]
    public Animator animator;
    public string SlashTriggerName;
    //public float ArmTime;

    [Header("Damage Attributes")]
    public GameObject hitEffect;
    //public GameObject enemyExplosion;

    /*
    [Header("Sounds")]
    public AudioSource deathSoundSource;
    public AudioClip DeathSound;
    */

    new void Start()
    {
        base.Start();
    }


    // Update is called once per frame
    new protected void Update()
    {

        if (!found)
        {
            Ray ray = new Ray(eyes.transform.position, eyes.transform.forward * visionRange);

            Debug.DrawRay(ray.origin, ray.direction.normalized * visionRange, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Player")
            {

                Debug.Log("I see something");
                found = true;
                
                //animator.SetTrigger("Found");
                target = hit.transform.gameObject;

            }

        }
        else
        {
            this.transform.LookAt(target.transform, Vector3.up);

            RaycastHit hit;

            Ray ray = new Ray(eyes.transform.position, eyes.transform.forward * visionRange);
            Debug.DrawRay(ray.origin, ray.direction.normalized * visionRange, Color.red);

            if (Physics.Raycast(ray, out hit, visionRange) && hit.transform.tag == "Player")
            {

                Debug.Log("I see something in my face at " + 
                    Vector3.Distance(this.transform.position, hit.point));
                found = true;

               

                //animator.SetTrigger("Found");
                //target = hit.transform.gameObject;

            }
            else
            {
                animator.SetBool("Shoot", false);
            }

            if (target == null)
            {
                found = false;

            }
            //pathfinding.SetDestination(target.transform.position);


        }

        
        
    }

    private void OnTriggerEnter(Collider other)
    {

        HitBoxScript hit;

        if (other.TryGetComponent<HitBoxScript>(out hit))
        {

            Damage((uint)hit.damage);
            Instantiate(hitEffect, this.transform.position, this.transform.rotation);
            

            if (HP <= 0)
            {
                //Instantiate(enemyExplosion, this.transform.position, this.transform.rotation);
                //deathSoundSource.PlayOneShot(DeathSound);
                Destroy(this.gameObject);


            }



        }

    }
    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);   //Wait
        
        
        
    }


}
