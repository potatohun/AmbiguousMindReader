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
        Debug.Log("����");
        id = 2;
        payment = Random.RandomRange(100, 1001);
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
        animator.SetInteger("EnterType", Random.RandomRange(0, 4));
        Debug.Log(animator.GetInteger("EnterType"));
        TextManager.textmanager.trigger = true;
    }

    private void Update()
    {
        if(GameManager.gamemanager.timeout == true)
        {
            Destroy();
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
        if (isHappy)
        {
            GameManager.gamemanager.SetEarn(2 * payment);
            Debug.Log(2*payment + "������!");
            GameManager.gamemanager.AddProfit(2 * payment);
        }
        else if (isAngry)
        {
            GameManager.gamemanager.SetEarn(-1 * payment);
            Debug.Log(payment + "�Ҿ���!");
            GameManager.gamemanager.AddProfit(-1 * payment);
        }
        else
        {
            GameManager.gamemanager.SetEarn(payment);
            Debug.Log(payment + "������!");
            GameManager.gamemanager.AddProfit(payment);
        }
    }

    public void Destroy()
    {
        Debug.Log("����");
        Destroy(this.gameObject);
    }
}
