using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gamemanager;
    public Text text;

    public float time;
    public bool timeout;

    public Image fadeImage; // UI Image를 연결합니다.
    public float fadeDuration = 1.0f; // 페이드 인/아웃 지속 시간
    void Awake()
    {
        if (gamemanager == null)
        {
            gamemanager = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(FadeIn());
        timeout = false;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Mathf.FloorToInt(time).ToString();
        
        // 타이머가 종료되면 원하는 작업을 수행하거나 타이머를 멈출 수 있습니다.
        if (time <= 0.0f)
        {
            timeout = true;
            time = 0.0f;
            Debug.Log("타임오버!");
            StartCoroutine(FadeOut());
            //데이터 저장 후 씬 이동
            //SceneManager.LoadScene("Shop");
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
    // 화면을 페이드 인하는 Coroutine
    IEnumerator FadeIn()
    {
        fadeImage.gameObject.SetActive(true);

        Color color = fadeImage.color;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;
            color.a = 1f - normalizedTime;
            fadeImage.color = color;
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
    }

    // 화면을 페이드 아웃하는 Coroutine
    IEnumerator FadeOut()
    {
        fadeImage.gameObject.SetActive(true);

        Color color = fadeImage.color;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;
            color.a = normalizedTime;
            fadeImage.color = color;
            yield return null;
        }
    }
}
