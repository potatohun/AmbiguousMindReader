using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gamemanager;
    public CustomerSpawner customerspawner;
    public Text timer_text;
    public Text earn_text;

    public float time;
    public bool timeout;

    public Image fadeImage; // UI Image를 연결합니다.
    public Text fadetext;
    public float fadeDuration = 3.0f; // 페이드 인/아웃 지속 시간

    public int earn;

    public Transform particle_transform;
    public GameObject good;
    public GameObject bad;

    public bool time_item_use;
    public bool customer_item_use;
    public bool power_item_use;
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


        if (time_item_use)
        {
            //매장 운영시간 증가
            Time_itemuse();
        }
        if (customer_item_use)
        {
            //매장 테이블 회전율 증가
            Customer_itemuse();
        }
        if (power_item_use)
        {
            //독심술 레벨업
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer_text.text = Mathf.FloorToInt(time).ToString();
        
        // 타이머가 종료되면 원하는 작업을 수행하거나 타이머를 멈출 수 있습니다.
        if (time <= 0.0f)
        {
            timeout = true;
            time = 0.0f;
            Debug.Log("타임오버!");
            StartCoroutine(FadeOut());
            //데이터 저장 후 씬 이동
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
    // 화면을 페이드 인하는 Coroutine
    IEnumerator FadeIn()
    {
        fadetext.text = PlayerPrefs.GetInt("Day").ToString() + "일차 시작";
        fadeImage.gameObject.SetActive(true);

        Color imagecolor = fadeImage.color;
        Color textcolor = fadetext.color;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;
            imagecolor.a = 1f - normalizedTime;
            textcolor.a = 1f - normalizedTime;
            fadeImage.color = imagecolor;
            fadetext.color = textcolor;
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
    }

    // 화면을 페이드 아웃하는 Coroutine
    IEnumerator FadeOut()
    {
        fadetext.text = PlayerPrefs.GetInt("Day").ToString() + "일차 종료";
        //수입 초기화(임시) 남은 돈도 추가해 줘야함
        //
        fadeImage.gameObject.SetActive(true);

        Color imagecolor = fadeImage.color;
        Color textcolor = fadetext.color;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;
            imagecolor.a = normalizedTime;
            textcolor.a = normalizedTime;
            fadeImage.color = imagecolor;
            fadetext.color = textcolor;
            yield return null;
        }
        PlayerPrefs.SetInt("Day", PlayerPrefs.GetInt("Day") + 1);
        SceneManager.LoadScene("Shop");
    }

    public void SetEarn(int earn)
    {
        this.earn += earn;
        earn_text.text = this.earn.ToString();
    }

    public void Time_itemuse()
    {
        time *= 2;
    }

    public void Customer_itemuse()
    {
        customerspawner.spawnInterval /= 2;
    }

    public void Power_itemuse()
    {
        //독심술 능력 증가
    }

    public void GoodEffect()
    {
        GameObject particlesys = Instantiate(good, particle_transform.position, Quaternion.identity);
        particlesys.GetComponent<ParticleSystem>().Play();
    }
    public void BadEffect()
    {
        GameObject particlesys = Instantiate(bad, particle_transform.position, Quaternion.identity);
        particlesys.GetComponent<ParticleSystem>().Play();
    }
}
