using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public int payment;
    public int id;
    public bool isHappy;
    public bool isAngry;

    public bool isEnter;
    public bool isLeave;

    public Animator animator;
    public Image image;

    private void Awake()
    {
        Debug.Log("»ý¼º");
        id = 2;
        payment = Random.RandomRange(100, 1000);
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();

        TextManager.textmanager.trigger = true;
    }

    private void Update()
    {
        if(GameManager.gamemanager.timeout == true)
        { 
            //Å¸ÀÓ¾Æ¿ô½Ã ÅðÀå(ÀÓ½Ã) ->
            //Leave();
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
        if (isHappy)
        {
            GameManager.gamemanager.SetEarn(2 * payment);
            Debug.Log(2*payment + "¹ú¾ú´Ù!");
        }
        else if (isAngry)
        {
            GameManager.gamemanager.SetEarn(-1 * payment);
            Debug.Log(payment + "ÀÒ¾ú´Ù!");
        }
        else
        {
            GameManager.gamemanager.SetEarn(payment);
            Debug.Log(payment + "¹ú¾ú´Ù!");
        }
    }

    public void Destroy()
    {
        Debug.Log("»èÁ¦");
        Destroy(this.gameObject);
    }
}
