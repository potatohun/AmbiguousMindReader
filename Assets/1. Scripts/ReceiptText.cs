using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReceiptText : MonoBehaviour
{
    public Text prevBalance;
    public Text profit;
    public Text cost;
    public Text totalBalance;

    private List<string> textList;
    public List<Text> targetTextList;
    private float delay = 0.05f;

    public GameObject receiptAudio;
    private AudioSource audioSource;

    int num1;
    int num2;
    public int num3;
    public int num4;

    // Start is called before the first frame update
    void Start()
    {
        num1 = PlayerPrefs.GetInt("PrevBalance");
        num2 = PlayerPrefs.GetInt("Profit");
        num3 = 0;
        num4 = PlayerPrefs.GetInt("Earn");
        setReceiptBalance(); // main 씬에서 돈 데이터 받아오기

        textList = new List<string>();
        for (int i = 0; i < targetTextList.Count; i++)
        {
            textList.Add(targetTextList[i].text.ToString());
            //Debug.Log(textList[i]);
            targetTextList[i].text = " ";
        }

        audioSource = receiptAudio.GetComponent<AudioSource>();

        StartCoroutine(textPrint(delay)); //이미지 글자 따라라락

        
    }

    public void setReceiptBalance()
    {
        prevBalance.text = num1.ToString();
        profit.text = num2.ToString();
        cost.text = num3.ToString();
        totalBalance.text = (num1+num2-num3).ToString();
    }

    IEnumerator textPrint(float d)
    {
        int i = 0;
        while (i != targetTextList.Count)
        {
            audioSource.Play();

            string text = textList[i];
            int count = 0;
            while (count != text.Length)
            {
                if (count < text.Length)
                {
                    targetTextList[i].text += text[count].ToString();
                    count++;
                }

                yield return new WaitForSeconds(delay);
            }
            i++;
        }

        if (num4 < 0)
        {
            Invoke("loadGameOverScene", 2.5f);
            
        }

    }

    void loadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}