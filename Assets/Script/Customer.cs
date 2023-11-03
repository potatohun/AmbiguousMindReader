using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public int payment;
    public int id;
    public bool isHappy;
    public bool isAngry;

    public bool isEnter;
    public bool isLeave;

    public Animator animator;

    private void Awake()
    {
        Debug.Log("����");
        id = 2;
        payment = Random.RandomRange(100, 1000);
        animator = GetComponent<Animator>();
        TextManager.textmanager.trigger = true;
    }

    private void Update()
    {
        if(GameManager.gamemanager.timeout == true)
        { 
            //Ÿ�Ӿƿ��� ����(�ӽ�) ->
            Leave();
        }
    }

    public void Enter()
    {
        //�մ� ����
        isEnter = true;
        isLeave = false;
    }
    public void Leave()
    {
        //�մ� ����
        isEnter = false;
        isLeave = true;
        animator.SetBool("Leave", true);
        Debug.Log(payment + "������!");
    }

    public void Destroy()
    {
        Debug.Log("����");
        Destroy(this.gameObject);
    }
}
