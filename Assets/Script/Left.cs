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

    string scr1 = "���� ������ �ʹ��Ⱦ�� ��г��۳�";
    string scr2 = "����ģ���� ���ķ�Դ� �ο���� �׳�� ���ķ縦 5������ �Ծ��. �׳��� �ǰ��� �����Ǿ� �𸣰ڰ� �Ӹ����ȵ��ư�����";
    string scr3 = "  �� ���������� �������� �� ����ģ���� ���İ���� ���� ����� ��� �ù�";

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