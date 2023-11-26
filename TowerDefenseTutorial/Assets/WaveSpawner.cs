using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint; //���� ���� ��ġ

    public float timeBetweenWaves = 5f; //���̺� ���� ��� �ð�
    private float countdown = 2f;

    private int waveNumber = 1;// ���̺� ��ȣ

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
        for (int i = 0; i < waveNumber; i++) //���̺� ������ŭ ���� ����
        {
            SpawnEnemy();
        }
        waveNumber++; //���̺갡 �ö����� ������
    }

    void SpawnEnemy()
    {
        //�̸� �����ص� ���� ����Ʈ���� ���͸� �����ؼ� ��ȯ
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
