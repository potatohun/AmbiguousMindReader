using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

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
    private int profit;

    public Transform particle_transform;
    public GameObject good;
    public GameObject bad;

    public Image background;
    public bool rage_day;
    public float rage_day_percent;

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
        profit = 0;
        earn = PlayerPrefs.GetInt("Earn");
        earn_text.text = PlayerPrefs.GetInt("Earn").ToString();
        StartCoroutine(FadeIn());
        timeout = true;
        rage_day = false;

        //30���� Ȯ���� ������ ���� ON
        if (Random.value < rage_day_percent)
        {
            rage_day = true;
        }
        else
        {
            rage_day=false;
        }

        if (rage_day)
        {//������ ����
            Time.timeScale = 3f;
            background.color = new Color(255, 0, 0, 255);
        }
        else
        {//���
            Time.timeScale = 1f;
            background.color = new Color(255, 255, 255, 255);
        }

        //������ ��뿩�� ����
        time_item_use = System.Convert.ToBoolean(PlayerPrefs.GetInt("����"));
        customer_item_use = System.Convert.ToBoolean(PlayerPrefs.GetInt("����"));
        power_item_use = System.Convert.ToBoolean(PlayerPrefs.GetInt("���ɼ� ����"));
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
            if(timeout == false)
            {
                time -= Time.deltaTime;
            }
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

        timeout = false;
        fadeImage.gameObject.SetActive(false);
    }

    // ȭ���� ���̵� �ƿ��ϴ� Coroutine
    IEnumerator FadeOut()
    {
        Time.timeScale = 1f;
        rage_day = false;
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
        PlayerPrefs.SetInt("PrevBalance", earn - profit); //����
        PlayerPrefs.SetInt("Profit", profit); //���� (����� �׻� 0)
        PlayerPrefs.SetInt("Earn", earn);
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
        customerspawner.spawnInterval /= 2f;
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
    public void AddProfit(int pay) //���� ����
    {
        profit += pay;
    }
}
