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

    string bye = " �����̳� ";
    string scr1 = " ���Ĵٺ�? ";
    string scr2 = " ����ģ���� ���ķ�Դ� �ο���� �׳�� ���ķ縦 5������ �Ծ��. �׳��� �ǰ��� �����Ǿ� �𸣰ڰ� �Ӹ����ȵ��ư����� ";
    string scr3 = " �̹��� �б����� ������ �ƴµ� ���� ������ �ʹ� ���� ���Ծ�.. �����? ";
    string scr4 = " 10 ���ϱ� 20 ���� 30 ";
    string scr5 = " �ε��׽þ��� ������? ";
    string scr6 = " �̵� �������� �������� �� �־����? ";
    string scr7 = " �� ���� â�� ������� �Դµ�.. ����� ";
    string scr8 = " ���� ����ģ���� 100���ε� � ������ �ؾ� �����ұ�?? ";
    string scr9 = " �ϰ� �׷��� ���ϴٸ�? �� ���� ����. ���� ���� ������ �ϰ��ִ� �� ����? �ϰ� ����� ���� �ϴ� �� �ź��ϰڴ�. ";
    string scr10 = " �� ���ϱ� 2�� ���ϱ��? ";
    string scr11 = " ���� ī�޶� ���� ��°� �ִµ� �����ɷ� �� �� ������ �̻ڷ���..? ";

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