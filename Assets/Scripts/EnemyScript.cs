﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : EntityScript
{
    [Header("Navigation Attributes")]
    public NavMeshAgent pathfinding;
    public GameObject eyes;
    public float visionRange;
    public bool found = false;
    protected GameObject target;
    public string hurtTag;


    
    new private void Start()
    {
        base.Start();
        //pathfinding.speed = speed;

    }
   

    // Update is called once per frame
    protected void Update()
    {

        if(!found)
        {
                Ray ray = new Ray(eyes.transform.position, eyes.transform.forward * visionRange);

                Debug.DrawRay(ray.origin, ray.direction*visionRange, Color.red);

                RaycastHit hit;

                if(Physics.Raycast(ray, out hit) && hit.transform.tag=="Player")
                {

                    Debug.Log("I see something");
                    found = true;
                    
                //target = hit.transform.gameObject;

                }
                
        }
        else
        {
            if(target==null)
            {
                found = false;
            }
            //pathfinding.SetDestination(target.transform.position);


        }
    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Barrier")
        {
            found = false;
            pathfinding.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {

    }


    
    public void Slash()
    {


    }


}
