using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public void NewStartBtn()
    {
        PlayerPrefs.SetInt("Day", 1);
        PlayerPrefs.SetInt("PrevBalance", 0);
        PlayerPrefs.SetInt("Profit", 0);
        PlayerPrefs.SetInt("Earn", 0);
        PlayerPrefs.SetInt("조명", 0);
        PlayerPrefs.SetInt("의자", 0);
        PlayerPrefs.SetInt("독심술 서적", 0);
        PlayerPrefs.SetInt("잡지", 0);
        PlayerPrefs.SetInt("시계", 0);
        SceneManager.LoadScene("Prologue");
    }
    public void ContinueBtn()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
}
