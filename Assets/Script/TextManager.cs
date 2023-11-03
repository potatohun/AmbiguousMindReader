using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static TextManager textmanager;

    public GameObject text;
    public Button[] button;

    public Customer customer;

    void Awake()
    {
        if (textmanager == null)
        {
            textmanager = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (customer != null)
        {
            if (customer.isEnter == true)
            {
                QuestionTextOpen();
            }

            if (customer.isLeave == true)
            {
                QuestionTextClose();
            }
        }
    }

    public void QuestionTextOpen()
    {
        
        text.SetActive(true);
    }

    public void QuestionTextClose()
    {

        text.SetActive(false);
    }

    public void FindCustomer(Customer customer)
    {
        this.customer = customer;
    }

    public void ButtonClick()
    {
        QuestionTextClose();
        customer.Leave();
    }
}
