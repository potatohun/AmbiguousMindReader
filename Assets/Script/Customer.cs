using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public int payment;

    public bool isHappy;
    public bool isAngry;

    public bool isEnter;
    public bool isLeave;

    public Animator animator;

    private void Awake()
    {
        Debug.Log("»ý¼º");
        payment = Random.RandomRange(100, 1000);
        animator = GetComponent<Animator>();
        Enter();
    }

    private void Update()
    {
        if(GameManager.gamemanager.timeout == true)
        { 
            //Å¸ÀÓ¾Æ¿ô½Ã ÅðÀå(ÀÓ½Ã) ->
            Leave();
        }
    }

    public void Enter()
    {
        //¼Õ´Ô ÀÔÀå
        isEnter = true;
        isLeave = false;
    }
    public void Leave()
    {
        //¼Õ´Ô ÅðÀå
        isEnter = false;
        isLeave = true;
        animator.SetBool("Leave", true);
        Debug.Log(payment + "¹ú¾ú´Ù!");
    }

    public void Destroy()
    {
        Debug.Log("»èÁ¦");
        Destroy(this.gameObject);
    }
}
