using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Left : MonoBehaviour
{
    public Dictionary<int, string[]> dic = new Dictionary<int, string[]>();
    public string[] str;

    string[] scr1 = new string[] { "저는 저년이 너무싫어요 ", " 저 개같은년이 문제에요 ", " 집에가고싶어요시발" };
    string[] scr2 = new string[] { "여자친구랑 탕후루먹다 싸웠어요 그녀는 탕후루를 5꼬지씩 먹어요. 그녀의 건강이 걱정되어 이야기를 했지만 그녀는 성질을 내기에 급급했어요", " 몰라", " 시발집에가고싶어요" };
    void Start()
    {
        dic.Add(1, scr1);
        dic.Add(2, scr2);
    }


    public string GetScr(int i)
    {

        if (dic.TryGetValue(i, out str))
        {
            int random = Random.Range(0, 3);
               return  str[random];
        }
        return null;
    }


}
