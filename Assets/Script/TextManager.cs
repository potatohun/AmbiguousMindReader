using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static TextManager textmanager;

    public GameObject text;
    public Button[] button;

    public bool trigger = true;

    public Customer customer;
    public Left left;
    public string leftText = null;
    private float delay = 0.05f;

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
        if (customer.isEnter == true && trigger == true)//
        {
            StartCoroutine(QuestionTextOpen());//
        }

        if (customer.isLeave == true)
        {
            QuestionTextClose();
        }
    }

    IEnumerator QuestionTextOpen()
    {
        trigger = false;
        text.SetActive(true);
        yield return null;

        StartCoroutine(textPrint(delay));
        yield return new WaitForSeconds(10);

    }
    IEnumerator textPrint(float d)
    {

        leftText = left.GetScr(customer.id);

        Debug.Log(leftText);
        int count = 0;

        while (count != leftText.Length)
        {
            if (count < leftText.Length)
            {
                text.GetComponent<Text>().text += leftText[count].ToString();
                count++;
            }
            yield return new WaitForSeconds(d);
        }
    }

    public void QuestionTextClose()
    {
        text.SetActive(false);
        text.GetComponent<Text>().text = "";
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
