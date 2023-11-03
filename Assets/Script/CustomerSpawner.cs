using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // ������ ������
    public float spawnInterval = 5.0f; // ���� ���� (��: 2��)
    public Customer customer;
    private Transform canvasTransform;

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
            SendCustomer();
        }
    }

    public void SendCustomer()
    {
        customer = GameObject.FindWithTag("Customer").GetComponent<Customer>();
        TextManager.textmanager.FindCustomer(customer);
    }
}
