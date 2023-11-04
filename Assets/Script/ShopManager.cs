using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    // string[] tempList = new string[] { "Sofa", "Light", "Table" ,"Lamp", "Chair", "Cabinet", "Flower"};
    List<string> shopList = new List<string>() { "조명", "의자", "독심술 서적" };
    List<string> itemList = new List<string>();
    [SerializeField]
    Text _text;
    [SerializeField]
    GameObject panel;
    [SerializeField]
    int price;
    [SerializeField]
    GameObject buySound;
    [SerializeField]
    GameObject textSound;
    [SerializeField]
    Text cost;
    [SerializeField]
    Text total;

    private int balance;
    private AudioSource audioSource;
    private AudioSource textaudio;

    public ReceiptText receiptText;

    // public GameObject shop;

    void Start()
    {
        balance = PlayerPrefs.GetInt("Earn");
        for (int i = 0; i < shopList.Count; i++)
        {
            PlayerPrefs.SetInt(shopList[i], 0);
        }
        audioSource = buySound.GetComponent<AudioSource>();
        textaudio = textSound.GetComponent<AudioSource>();
    }

    public void SetProduct()
    {
        /*GameObject IMSI = Instantiate(shop);
        IMSI.transform.parent = this.transform;//
        Transform itemName = IMSI.transform.GetChild(1);*/


        /*int randomIndex;

        for (int i = 0; i < 3; i++)
        {
            randomIndex = Random.Range(0, 4);
            if (!showCase.Contains(shopList[randomIndex]))
            {
                showCase.Add(shopList[randomIndex]);
                continue;
            }
            i--;
        }*/

    }

    public void OnButtonClicked(int price)
    {
        receiptText.num3 += price;

        Debug.Log("Button Click");
        string textContent = _text.text;
        Debug.Log("Text 내용: " + textContent);
        if (balance < price)
        {
            Debug.Log("Purchase Failed");
            return;
        }
        int extra = balance - price;

        Debug.Log("Extra : " + extra);

        audioSource.Play();

        ReceiptUpdate();
        Debug.Log($"남은 돈 : {extra}");
        PlayerPrefs.SetInt("Earn", extra);
        for (int i = 0; i < shopList.Count; i++)
        {
            if (shopList[i] == _text.text)
            {
                itemList.Add(shopList[i]);
            }
        }

        for (int i = 0; i < itemList.Count; i++)
        {
            PlayerPrefs.SetInt(itemList[i], 1);
        }

        int num = PlayerPrefs.GetInt("조명");
        int num1 = PlayerPrefs.GetInt("의자");
        int num2 = PlayerPrefs.GetInt("독심술 서적");

        Debug.Log($"{num}, {num1}, {num2}");

        panel.SetActive(true);
    }

    public void ReceiptUpdate()
    {
        float delay = 0.05f;
        Coroutine runningCoroutine = null;

        cost.text = receiptText.num3.ToString();
        runningCoroutine = StartCoroutine(textPrint(cost, delay));

        total.text = (int.Parse(total.text) - price).ToString();
        runningCoroutine = StartCoroutine(textPrint(total, delay));
    }

    IEnumerator textPrint(Text targetText, float d)
    {
        textaudio.Play();

        string text = targetText.text.ToString();
        targetText.text = " ";
        int count = 0;
        while (count != text.Length)
        {
            if (count < text.Length)
            {
                targetText.text += text[count].ToString();
                count++;
            }
            yield return new WaitForSeconds(d);
        }
    }

}