using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static TextManager textmanager;

    public GameObject text;
    public Button[] button;
    public GameObject[] buttonText;

    public string[] str = new string[3];
    public bool trigger = true;

    public Customer customer;
    public CustomerSpawner customerSpawner;

    public Left left;
    public Right right;
    public string leftText = null;
    public string rightText = null;
    private float delay = 0.05f;
    public int hole = 3;
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


    void Update()
    {
        if (customer != null)
        {
            if (customer.isEnter == true && trigger == true)//
            {
                StartCoroutine(QuestionTextOpen());//
                AnswerTextOpen();
            }

            if (customer.isLeave == true)
            {
                QuestionTextClose();
                AnswerTextClose();
            }
        }
    }

    IEnumerator QuestionTextOpen()
    {
        trigger = false;
        text.SetActive(true);
        yield return null;

        StartCoroutine(LeftTextPrint(delay));
        yield return new WaitForSeconds(10);

    }
    IEnumerator LeftTextPrint(float d)
    {

        leftText = left.GetScr(customer.id);
        TransString(leftText);

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
    IEnumerator RightTextPrint(float d)
    {
        int count = 0;
        right.SetBtn();

        for (int i = 0; i < 3; i++)
        {

            string text = str[i];
            button[i].GetComponentInChildren<Text>().text = i + 1 + ". ";

            while (count != text.Length)
            {
                if (count < text.Length)
                {
                    button[i].GetComponentInChildren<Text>().text += text[count].ToString();
                    count++;
                }
                yield return new WaitForSeconds(d);
            }

            count = 0;
        }

        right.SetDingdangdong()
; ;    }

    void TransString(string text)
    {

        string[] transChar = new string[] { "░", "▒", "▓" };
        string[] splitStr = text.Split(' ');
        string changeStr;

        int range = splitStr.Length; int cRange = transChar.Length;

        int random; int cRandom;
        HashSet<int> set = new HashSet<int>();

        for (int i = 0; i < hole; i++) // hole이랑 어절의 갯수랑 좀 신경써야됨 //어절이 3개인데 hole3개면...
        {

            if (i > range - 2) //다 못가리게
                break;

            random = Random.Range(0, range);
            while (set.Contains(random) || splitStr[random].Length == 1) //random겹치거나 한글자면 다시돌려
                random = Random.Range(0, range);

            changeStr = "";
            set.Add(random);

            //     Debug.Log("바꾸기전" + splitStr[random]);
            for (int j = 0; j < splitStr[random].Length; j++)
            {
                cRandom = Random.Range(0, cRange);
                changeStr += transChar[cRandom];
            }
            splitStr[random] = changeStr;
            //   Debug.Log("바꾸기후" + splitStr[random]);

        }
        leftText = string.Join(' ', splitStr);
    }

    public void QuestionTextClose()
    {
        text.SetActive(false);
        text.GetComponent<Text>().text = "";
    }

    public void AnswerTextOpen()
    {
        for (int i = 0; i < 3; i++)
        {
            buttonText[i].SetActive(true);
            button[i].gameObject.SetActive(true);
        }
        StartCoroutine(RightTextPrint(delay));
    }


    public void AnswerTextClose()
    {
        for (int i = 0; i < 3; i++)
        {
            button[i].gameObject.SetActive(false);
            buttonText[i].GetComponent<Text>().text = "";
        }
        right.SetCheck();


    }
    public void FindCustomer(Customer customer)
    {
        this.customer = customer;
    }

    public void ButtonClick()
    {
        QuestionTextClose();
        GameObject clickbtn = EventSystem.current.currentSelectedGameObject;
        if (clickbtn.tag != null)
        {
            if (clickbtn.tag == "True")
            {
                GameManager.gamemanager.GoodEffect();
                customerSpawner.CustomerHappy();
                customer.isHappy = true;
            }
            else if (clickbtn.tag == "False")
            {
                GameManager.gamemanager.BadEffect();
                customerSpawner.CustomerAngry();
                customer.isAngry = true;
            }
            customer.Leave();
        }
    }
}