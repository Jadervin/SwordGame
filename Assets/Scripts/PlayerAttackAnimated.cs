using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAnimated : MonoBehaviour
{
    /*
    [System.Serializable]
    public class Triggers
    {
        public string TriggerName;



    }
    */
    //[SerializeField]
    public Animator animator;
    public string SlashTrigger1;
    public string SlashTrigger2;
    public string SlashTrigger3;
    //public string isSecondSlashTrigger;
    //private enum Triggers { slash1, slash2};


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        
        animator.SetTrigger(SlashTrigger1);
        animator.SetTrigger(SlashTrigger2);
        animator.SetTrigger(SlashTrigger3);
        //animator.SetTrigger(isSecondSlashTrigger);
    }
}
