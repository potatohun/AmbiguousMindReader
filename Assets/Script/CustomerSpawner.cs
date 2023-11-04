using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // ������ ������
    public float spawnInterval;
    public Customer customer;
    private Transform canvasTransform;
    public Sprite[] normal_facelist;
    public Sprite[] angry_facelist;
    public Sprite[] happy_facelist;
    public Sprite[] veryangry_facelist;
    public Image face;

    private void Start()
    {
        // �ֱ������� �������� �����ϱ� ���� Ÿ�̸� ����
        canvasTransform = GameObject.Find("Canvas").transform;
        InvokeRepeating("SpawnPrefab", 0.0f, spawnInterval);
    }

    // �������� �����ϴ� �Լ�
    void SpawnPrefab()
    {
        if(customer == null)
        {
            // �������� �����ϰ� ���ϴ� ��ġ�� ��ġ
            GameObject spawnedObject = Instantiate(prefabToSpawn, canvasTransform);
            // ���ϴ� ��ġ�� ȸ�� ���� ����
            spawnedObject.transform.position = new Vector3(-1160f, 160f, 0f);
            SpawnCustomer();
        }
    }

    public void SpawnCustomer()
    {
        //�մ� ����
        customer = GameObject.FindWithTag("Customer").GetComponent<Customer>();
        face = GameObject.FindWithTag("Face").GetComponent<Image>();
        face.sprite = normal_facelist[Random.Range(0, normal_facelist.Length)];
        TextManager.textmanager.FindCustomer(customer);
    }
}
