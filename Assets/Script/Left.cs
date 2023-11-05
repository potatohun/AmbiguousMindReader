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

    string bye = " 돌팔이네 ";
    string scr1 = " 뭘쳐다봐? ";
    string scr2 = " 여자친구랑 탕후루먹다 싸웠어요 그녀는 탕후루를 5꼬지씩 먹어요. 그녀의 건강이 걱정되어 모르겠고 머리가안돌아가이제 ";
    string scr3 = " 이번에 학교에서 시험을 쳤는데 시험 점수가 너무 낮게 나왔어.. 어떡하지? ";
    string scr4 = " 10 더하기 20 빼기 30 ";
    string scr5 = " 인도네시아의 수도는? ";
    string scr6 = " 이따 집에가서 마라탕에 뭐 넣어먹지? ";
    string scr7 = " 아 집에 창문 열어놓고 왔는데.. 어떡하지 ";
    string scr8 = " 내일 여자친구랑 100일인데 어떤 선물을 해야 좋아할까?? ";
    string scr9 = " 니가 그렇게 용하다며? 내 눈을 봐바. 내가 무슨 생각을 하고있는 것 같지? 니가 뭐라고 말을 하던 난 거부하겠다. ";
    string scr10 = " 십 곱하기 2는 얼마일까요? ";
    string scr11 = " 요즘 카메라가 맘에 드는게 있는데 좋은걸로 내 얼굴 찍으면 이쁘려나..? ";

    void Start()
    {
        dic.Add(-1, bye);
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
    public string GetScr(int i)
    {
        if (dic.TryGetValue(i, out str))
            return str;
        return null;
    }

}