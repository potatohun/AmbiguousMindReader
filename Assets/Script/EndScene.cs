using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndScene: MonoBehaviour
{
    public void ClickFinishButton()
    {
        SceneManager.LoadScene("MainGame");

    }
}
