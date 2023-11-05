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

    string[] scr1 = new string[] { "1", "내눈이다.", "사랑해", ".." };
    string[] scr2 = new string[] { "3", "요즘 애인이 잘해주지?", "뭘쳐다봐", "요즘 애인이랑 안좋구나?" };
    string[] scr3 = new string[] { "1", "시험 망쳤니?", "정말 잘했구나.", "교수님이 널 아끼나봐" };
    string[] scr4 = new string[] { "3", "-1", "1", "0" };
    string[] scr5 = new string[] { "1", "자카르타", "네팔", "뉴델리" };
    string[] scr6 = new string[] { "3", "부두", "부추", "푸주" };
    string[] scr7 = new string[] { "1", "물을 조심해라.", "불을 조심해,,", "바람.." };
    string[] scr8 = new string[] { "2", "바다", "반지", "국밥" };
    string[] scr9 = new string[] { "1", "날 의심하는건가.", "날 좋아하나..?", "미안하다.." };
    string[] scr10 = new string[] { "3", "2!", "10", "20..?" };
    string[] scr11 = new string[] { "1", "그걸로 얼굴을 찍으면 아플걸", "FHD급 해상도", "키메라" };

    void Start()
    {
        dic.Add(1, scr1);
        dic.Add(2, scr2);
        dic.Add(3, scr3);
        dic.Add(4, scr4);
        dic.Add(5, scr5);
        dic.Add(6, scr6);
        dic.Add(7, scr7);
        dic.Add(8, scr8);
        dic.Add(9, scr9);
        dic.Add(10, scr10);
        dic.Add(11, scr11);
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
