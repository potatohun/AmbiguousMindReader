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

    string[] scr1 = new string[] { "���� ������ �ʹ��Ⱦ�� ", " �� ���������� �������� ", " ��������;��ù�" };
    string[] scr2 = new string[] { "����ģ���� ���ķ�Դ� �ο���� �׳�� ���ķ縦 5������ �Ծ��. �׳��� �ǰ��� �����Ǿ� �̾߱⸦ ������ �׳�� ������ ���⿡ �ޱ��߾��", " ����", " �ù���������;��" };
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
