using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Left : MonoBehaviour
{
    public Dictionary<int, string> dic = new Dictionary<int, string>();
    public string str;

    string scr1 = "저는 저년이 너무싫어요 기분나쁜년";
    string scr2 = "여자친구랑 탕후루먹다 싸웠어요 그녀는 탕후루를 5꼬지씩 먹어요. 그녀의 건강이 걱정되어 모르겠고 머리가안돌아가이제";
    string scr3 = "  저 개같은년이 문제에요 제 남자친구를 훔쳐갔어요 집에 가고싶 어요 시발";

    void Start()
    {
        dic.Add(1, scr1);
        dic.Add(2, scr2);
        dic.Add(3, scr3);
    }
    public string GetScr(int i)
    {
        if (dic.TryGetValue(i, out str))
            return str;
        return null;
    }

}