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
    public float lifetime;

    public bool isEnter;
    public bool isLeave;
    public bool lifetime_over;

    public Animator animator;
    public Image image;
    public Text text;

    private void Awake()
    {
        Debug.Log("����");
        id = 2;
        if (PlayerPrefs.GetInt("����") == 1)
        {
            //���� ������ ��� O
            payment = Random.RandomRange(200,2001);
        }
        else
        {
            //���� ������ ��� X
            payment = Random.RandomRange(100, 1001);
        }
        
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
        animator.SetInteger("EnterType", Random.RandomRange(0, 4));
        Debug.Log(animator.GetInteger("EnterType"));
        TextManager.textmanager.trigger = true;
        text.text = payment.ToString();
    }

    private void Update()
    {
        if (GameManager.gamemanager.timeout == true)
        {
            Destroy();
        }
    }

    public void Enter()
    {
        //�մ� ����
        isEnter = true;
        isLeave = false;

        float waittime = 7.0f;
        if (PlayerPrefs.GetInt("�ð�") == 1)
        {
            waittime = 10.0f;
        }
        else
        {
            waittime = 7.0f;
        }
        Invoke("TimeOut", waittime);
    }
    public void Leave()
    {
        //�մ� ����
        isEnter = false;
        isLeave = true;
        animator.SetBool("Leave", true);
        if (isHappy)
        {
            GameManager.gamemanager.SetEarn(payment);
            Debug.Log(payment + "������!");
            GameManager.gamemanager.AddProfit(payment);
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

    public void TimeOut()
    {
        if (!isLeave)
        {
            GameManager.gamemanager.BadEffect();
            GameManager.gamemanager.customerspawner.CustomerAngry();
            isAngry = true;
            Leave();
        }
    }
}
