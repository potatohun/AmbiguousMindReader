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

   /* public string GetSCr(int i)
    {
        HashSet<int> set = new HashSet<int>();

        if (dic.TryGetValue(i, out str))
        {

            while (check[random] == 1)
                random = UnityEngine.Random.Range(1, 4);

            check[random] = 1;

            return str[random + 1];
        }
        else
            return null;

    }
   */

    public void SetCheck()
    {
        for (int i = 0; i < 3; i++)
            check[i] = 0;
    }
   
    public void SetBtn()
    {
        String dingdongdang="";

        if (dic.TryGetValue(TextManager.textmanager.customer.id, out str))
        {
            dingdongdang = str[int.Parse(str[0])];
            Debug.Log(dingdongdang); // �� ������ξ��ϰ�����

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
                TextManager.textmanager.button[i].GetComponentInChildren<Text>().text = str[random];
            }

            for (int i = 0; i < 3; i++)
            {
             
                if (TextManager.textmanager.button[i].GetComponentInChildren<Text>().text.Equals(dingdongdang))//�Ŵ����� ��Ʈ������ �� ����ϰ��Ҽ������Ű�����
                    TextManager.textmanager.button[i].tag = "True";

            }
        }

    }
}
