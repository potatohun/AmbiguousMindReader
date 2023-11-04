using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiptText : MonoBehaviour
{
    public Text prevBalance;
    public Text profit;
    public Text cost;
    public Text totalBalance;
    
    //test
    int numPB = 1000; //String¿∏∑Œ πŸ≤‹¡ˆ ∞ÌπŒ «ÿ∫∏±‚
    int numP = 2000;
    int numC = 3000;
    int numTB = 4000;

    /*
    int numPB = PlayerPrefs.GetInt(""); //String¿∏∑Œ πŸ≤‹¡ˆ ∞ÌπŒ «ÿ∫∏±‚
    int numP = PlayerPrefs.GetInt("");
    int numC = PlayerPrefs.GetInt("");
    int numTB = PlayerPrefs.GetInt(""); */

    private List<string> textList;
    public List<Text> targetTextList;
    private float delay = 0.05f;

    public GameObject receiptAudio;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //numTB = numPB + numP - numC;
        prevBalance.text = numPB.ToString();
        profit.text = numP.ToString();
        cost.text = numC.ToString();
        totalBalance.text = numTB.ToString();

        textList = new List<string>();
        for (int i = 0; i < targetTextList.Count; i++)
        {
            textList.Add(targetTextList[i].text.ToString());
            Debug.Log(textList[i]);
            targetTextList[i].text = " ";
        }

        audioSource = receiptAudio.GetComponent<AudioSource>();

        StartCoroutine(textPrint(delay));
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

    }
}
