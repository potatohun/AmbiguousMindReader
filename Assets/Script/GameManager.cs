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

    public Image fadeImage; // UI Image�� �����մϴ�.
    public Text fadetext;
    public float fadeDuration = 3.0f; // ���̵� ��/�ƿ� ���� �ð�

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
            Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(FadeIn());
        timeout = false;


        if (time_item_use)
        {
            //���� ��ð� ����
            Time_itemuse();
        }
        if (customer_item_use)
        {
            //���� ���̺� ȸ���� ����
            Customer_itemuse();
        }
        if (power_item_use)
        {
            //���ɼ� ������
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer_text.text = Mathf.FloorToInt(time).ToString();
        
        // Ÿ�̸Ӱ� ����Ǹ� ���ϴ� �۾��� �����ϰų� Ÿ�̸Ӹ� ���� �� �ֽ��ϴ�.
        if (time <= 0.0f)
        {
            timeout = true;
            time = 0.0f;
            Debug.Log("Ÿ�ӿ���!");
            StartCoroutine(FadeOut());
            //������ ���� �� �� �̵�
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
    // ȭ���� ���̵� ���ϴ� Coroutine
    IEnumerator FadeIn()
    {
        fadetext.text = PlayerPrefs.GetInt("Day").ToString() + "���� ����";
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

    // ȭ���� ���̵� �ƿ��ϴ� Coroutine
    IEnumerator FadeOut()
    {
        fadetext.text = PlayerPrefs.GetInt("Day").ToString() + "���� ����";
        //���� �ʱ�ȭ(�ӽ�) ���� ���� �߰��� �����
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
        //���ɼ� �ɷ� ����
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
