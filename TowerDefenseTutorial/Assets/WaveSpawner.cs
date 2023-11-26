using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform ememyPrefab;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private void Update()
    {
        if (countdown <= 0f) //ī��Ʈ�ٿ��� 0 ���� �۾����� Spawn Wave ����
        {
            SpawnWave();
            countdown = timeBetweenWaves;//ī��Ʈ �ٿ��� �߰� �ð����� �ʱ�ȭ
        }

        //deltaTime//������ �������� �׸� �� ����� �ð�
        countdown -= Time.deltaTime; //�ð��� ��� ���δ�.
    }

    void SpawnWave()
    {
        Debug.Log("Wave Incoming!");
    }
}
