using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // 생성할 프리팹
    public float spawnInterval = 5.0f; // 생성 간격 (예: 2초)
    public Customer customer;
    private Transform canvasTransform;

    private void Start()
    {
        // 주기적으로 프리팹을 생성하기 위한 타이머 시작
        canvasTransform = GameObject.Find("Canvas").transform;
        InvokeRepeating("SpawnPrefab", 0.0f, spawnInterval);
    }

    // 프리팹을 생성하는 함수
    void SpawnPrefab()
    {
        if(customer == null)
        {
            // 프리팹을 생성하고 원하는 위치에 배치
            GameObject spawnedObject = Instantiate(prefabToSpawn, canvasTransform);
            // 원하는 위치와 회전 등을 설정
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
