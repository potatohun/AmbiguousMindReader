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

    public Image fadeImage; // UI Image�� �����մϴ�.
    public float fadeDuration = 1.0f; // ���̵� ��/�ƿ� ���� �ð�
    void Awake()
    {
        if (gamemanager == null)
        {
            gamemanager = this;
        }
        else
        {
            Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�!");
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
        
        // Ÿ�̸Ӱ� ����Ǹ� ���ϴ� �۾��� �����ϰų� Ÿ�̸Ӹ� ���� �� �ֽ��ϴ�.
        if (time <= 0.0f)
        {
            timeout = true;
            time = 0.0f;
            Debug.Log("Ÿ�ӿ���!");
            StartCoroutine(FadeOut());
            //������ ���� �� �� �̵�
            //SceneManager.LoadScene("Shop");
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
    // ȭ���� ���̵� ���ϴ� Coroutine
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

    // ȭ���� ���̵� �ƿ��ϴ� Coroutine
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
