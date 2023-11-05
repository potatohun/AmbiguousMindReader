using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetProduct : MonoBehaviour
{
    [SerializeField]
    GameObject showcase;
    [SerializeField]
    int page;

    private int maxPage;

    void Start()
    {
        page = 1;
    }

    void Update()
    {
        maxPage = (showcase.transform.childCount / 3) + 1;

        for (int i = 0; i < showcase.transform.childCount; i++)
        {
            if (3*(page - 1) <= i && i < 3 * page)
            {
                showcase.transform.GetChild(i).gameObject.SetActive(true);
                continue;
            }
            showcase.transform.GetChild(i).gameObject.SetActive(false);
        }
        // Debug.Log($"page : {page}");
    }

    public void RightButtonClicked()
    {
        page++;
        if(page > maxPage)
        {
            page = 1;
        }
    }

    public void LeftButtonClicked()
    {
        page--;
        if(page == 0)
        {
            page = maxPage;
        }
    }
}
