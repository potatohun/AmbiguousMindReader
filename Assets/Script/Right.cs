using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Right : MonoBehaviour
{
    public Dictionary<int, string[]> dic = new Dictionary<int, string[]>();
    public string[] str;

    String dingdangdong = "";
    int random = 0;
    public int[] check = { 0, 0, 0 };

    string[] scr1 = new string[] { "2", "������", "������", "����" };
    string[] scr2 = new string[] { "3", "������", "�˾Ƽ���", "���Ѹ�" };
    string[] scr3 = new string[] { "1", "���෡", "������", "�����" };


    void Start()
    {
        dic.Add(1, scr1);
        dic.Add(2, scr2);
        dic.Add(3, scr3);
    }

    public void SetCheck()
    {
        for (int i = 0; i < 3; i++)
            check[i] = 0;
    }
   
    public void SetBtn()
    {
        

        if (dic.TryGetValue(TextManager.textmanager.customer.id, out str))
        {
            dingdangdong = str[int.Parse(str[0])];

            for (int i = 0; i < 3; i++)
            {
                random = UnityEngine.Random.Range(1, 4);

                /* if (check[random-1]==1)
                  while(check[random-1] == 1)
                     random = UnityEngine.Random.Range(1, 4);
                 */

                do
                {
                    random = UnityEngine.Random.Range(1, 4);
                }
                while (check[random - 1] == 1);

                check[random - 1] = 1;

                TextManager.textmanager.button[i].tag = "False";
                TextManager.textmanager.str[i] = str[random];
            }
        }

    }
    public void SetDingdangdong()
    {
        for (int i = 0; i < 3; i++)
            if (dingdangdong.Equals(TextManager.textmanager.button[i].GetComponentInChildren<Text>().text.Substring(3)))
                TextManager.textmanager.button[i].tag = "True";
    }
}
