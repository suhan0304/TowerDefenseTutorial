using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint; //���� ���� ��ġ

    public float timeBetweenWaves = 5.5f; //���̺� ���� ��� �ð�
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;// ���̺� ��ȣ

    private void Update()
    {
        if (countdown <= 0f) //ī��Ʈ�ٿ��� 0 ���� �۾����� Spawn Wave ����
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;//ī��Ʈ �ٿ��� �߰� �ð����� �ʱ�ȭ
        }

        //deltaTime//������ �������� �׸� �� ����� �ð�
        countdown -= Time.deltaTime; //�ð��� ��� ���δ�.

        waveCountdownText.text = Mathf.Round(countdown).ToString(); //ī��Ʈ �ٿ��� �ݿø��� ���� ��Ʈ������ �ٲ㼭 UI�� �ؽ�Ʈ�� ����
    }

    IEnumerator SpawnWave() //�ڷ�ƾ
    {
        waveIndex++; //���̺갡 �ö����� ������

        for (int i = 0; i < waveIndex; i++) //���̺� ������ŭ ���� ����
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        //�̸� �����ص� ���� ����Ʈ���� ���͸� �����ؼ� ��ȯ
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
