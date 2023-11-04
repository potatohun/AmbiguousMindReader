using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    // string[] tempList = new string[] { "Sofa", "Light", "Table" ,"Lamp", "Chair", "Cabinet", "Flower"};
    List<string> shopList = new List<string>() {"조명", "의자" ,"독심술 서적"};
    List<string> showCase = new List<string>();
    List<string> itemList = new List<string>();
    [SerializeField]
    Text _text;
    [SerializeField]
    GameObject shopProduct;
    [SerializeField]
    int price;

    // public GameObject shop;

    void Start()
    {
        PlayerPrefs.SetInt("Wallet", 500);
        for (int i = 0; i < shopList.Count; i++)
        {
            PlayerPrefs.SetInt(shopList[i], 0);
        }
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

    public void OnButtonClicked()
    {
        Debug.Log("Button Click");
        string textContent = _text.text;
        Debug.Log("Text 내용: " + textContent);
        if(PlayerPrefs.GetInt("Wallet") < price)
        {
            Debug.Log("Purchase Failed");
            return;
        }
        int bal = PlayerPrefs.GetInt("Wallet") - price;
        Debug.Log($"남은 돈 : {bal}");
        PlayerPrefs.SetInt("Wallet", bal);
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

        Destroy(shopProduct);

    }
}

// 사용예시
/*PlayerPrefs.SetInt("MONEY", 5);
int n = PlayerPrefs.GetInt("MONEY");*/


// Debug.Log("")
/*PlayerPrefs.SetInt("Light", System.Convert.ToInt16(value));
bool isOwn = System.Convert.ToBoolean(PlayerPrefs.GetInt("Keyword"));*/


/*public void SaveData()
{
    for (int i = 0; i < levelCount; i++)
    {
        PlayerPrefs.SetInt("LevelList" + i, levels[i]);
    }
}
public void LoadData()
{
    for (int i = 0; i < levelCount; i++)
    {
        levels[i] = PlayerPrefs.GetInt("LevelList" + i);
    }
}*/